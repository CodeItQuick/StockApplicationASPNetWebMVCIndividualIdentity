using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;
using Stripe;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _config;
        private readonly IExternalSubscriptionService _externalSubscriptionListService;
        private readonly IStockIndexService _stockIndexService;
        private readonly IShortListStockService _shortListStockService;
        private readonly ISubscriptionService _subscriptionsService;
        private SubscriptionService _subscriptionService;

        public HomeController(ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration? config,
            IExternalSubscriptionService externalSubscriptionListService,
            IStockIndexService stockIndexService, 
            IShortListStockService shortListStockService,
            ISubscriptionService subscriptionService)
        {
            _logger = logger;
            _userManager = userManager;
            _config = config;
            _externalSubscriptionListService = externalSubscriptionListService;
            _subscriptionsService = subscriptionService;
            _stockIndexService = stockIndexService;
            _shortListStockService = shortListStockService;
            
        }

        public ActionResult Index(
            StockInfoRequest stockInfoRequest,
            int? pageNumber)
        {
            // DB/Application
            var stockInfoDatums = _stockIndexService.DisplayAllStocks(
                stockInfoRequest.pageNumber ?? pageNumber ?? 0);
            var numPages = _stockIndexService.DisplayAllStocksCount();
            // Display/Adapter
            var model = new IndexResponseModel<StocksAdapter>()
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < numPages,
                StockInfoDatums = stockInfoDatums,
                PageIndex = stockInfoRequest.pageNumber ?? 0,
                NumPages = numPages
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult FindPage( 
            string letter,
            int? pageNumber)
        {
            // DB/Application
            var stockInfoDatums = _stockIndexService.DisplayAllStocksToPage(letter);
            return Redirect($"Index/?pageNumber={stockInfoDatums.Page}");
        }

        [Route("/Shortlist")]
        [HttpGet]
        public IActionResult Shortlist(
            StockInfoRequest? stockInfoRequest)
        {
            if (User.Identity == null)
            {
                throw new NullReferenceException(nameof(User.Identity));
            }

            var username = User.Identity.Name;
            // DB/Application
            List<StocksAdapter> stockInfoDatums;
            if (username != null)
            {
                stockInfoDatums = _shortListStockService.ShortlistedStocks(
                    stockInfoRequest?.pageNumber ?? 0, username);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            // Stripe check subscriptions
            
            StripeList<Subscription> subscriptions = _externalSubscriptionListService.Retrieve();
            
            var stockInfoView = StockInfoView.Of(stockInfoDatums, subscriptions);

            // Display/Adapter
            var model = new IndexResponseModel<StocksAdapter>
            {
                HasPreviousPage = stockInfoRequest?.pageNumber >= 1,
                HasNextPage = (stockInfoRequest?.pageNumber ?? 0) < stockInfoDatums.Count / 10,
                StockInfoDatums = stockInfoView.StockInfoDatums,
                PageIndex = stockInfoRequest?.pageNumber ?? 0
            };
            return View(model);
        }

        [Route("/IndividualStock/{ticker}")]
        [HttpGet]
        public IActionResult IndividualStock(
            string ticker,
            StockInfoRequest? stockInfoRequest)
        {
            // DB/Application
            var stockInfoDatums = _shortListStockService.RetrieveIndividualStock(ticker);
            var retrieveIndividualStocks = _shortListStockService.RetrieveCashFlowStatements(ticker);
            var stockSubscriptions = _subscriptionsService.Retrieve();
            // Display/Adapter
            var model = new IndividualStockResponseModel<IndividualStockDto>()
            {
                IndividualStockEarningsView = stockInfoDatums,
                StockSubscriptions = stockSubscriptions.Where(x => x.Description != null && x.Description.Contains(ticker)),
                CashFlowDto = retrieveIndividualStocks.ToList()
            };
            return View(model);
        }

        [Route("/Settings")]
        [HttpGet]
        public IActionResult Settings(
            StockInfoRequest? stockInfoRequest)
        {
            return View();
        }

        // TODO: Wrap with tests
        [Route("/Settings/RetrieveIncomeStatement/{ticker}")]
        [HttpPost]
        public IActionResult RetrieveIncomeStatementData(string ticker)
        {

            var response = client
                .GetAsync(
                    $"https://financialmodelingprep.com/api/v3/income-statement/{ticker}?limit=5&apikey={_config["FMP:ApiKey"]}")
                .Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            
            var jsonResponse = JsonConvert.DeserializeObject<List<IncomeStatementDto>>(responseString);

            if (jsonResponse != null)
            {
                    _shortListStockService.AddToIncomeStatements(jsonResponse);
            }

            return RedirectToAction("Shortlist");
        }


        // TODO: Wrap with tests
        [Route("/Settings/RetrieveKeyMetricData/{ticker}")]
        [HttpPost]
        public IActionResult RetrieveKeyMetricData(string ticker)
        {

            var response = client
                .GetAsync(
                    $"https://financialmodelingprep.com/api/v3/key-metrics/{ticker}?limit=10&apikey={_config["FMP:ApiKey"]}")
                .Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            
            var jsonResponse = JsonConvert.DeserializeObject<List<KeyMetricsDto>>(responseString);

            if (jsonResponse != null)
            {
                _shortListStockService.AddToKeyMetrics(jsonResponse);
            }

            return RedirectToAction("Shortlist");
        }

        // TODO: Wrap with tests
        [Route("/Settings/RetrieveRatiosTtm/{ticker}")]
        [HttpPost]
        public IActionResult RetrieveRatiosTtmData(string ticker)
        {

            var response = client
                .GetAsync(
                    $"https://financialmodelingprep.com/api/v3/ratios/{ticker}?limit=9&apikey={_config["FMP:ApiKey"]}")
                .Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            
            var jsonResponse = JsonConvert.DeserializeObject<List<RatiosDto>>(responseString);
            if (jsonResponse == null) return RedirectToAction("Index");
            jsonResponse?.ForEach(ratios => ratios.Symbol = ticker);
            _shortListStockService.AddToRatiosTtm(jsonResponse);

            return RedirectToAction("Shortlist");
        }

        // TODO: Wrap with tests
        [Route("/Settings/RetrieveCashFlowStatement/{ticker}")]
        [HttpPost]
        public IActionResult RetrieveCashFlowStatementData(string ticker)
        {

            var response = client
                .GetAsync(
                    $"https://financialmodelingprep.com/api/v3/cash-flow-statement/{ticker}?limit=10&apikey={_config["FMP:ApiKey"]}")
                .Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            
            var jsonResponse = JsonConvert.DeserializeObject<List<CashFlowStatementDto>>(responseString);

            if (jsonResponse != null)
            {
                _shortListStockService.AddToCashFlowStatement(jsonResponse);
            }

            return RedirectToAction("Shortlist");
        }
        
        // TODO: Wrap with tests
        [Route("/Settings/RetrieveCashFlowStatementIndex/{ticker}")]
        [HttpPost]
        public IActionResult RetrieveCashFlowStatementDataIndex(string ticker, int index)
        {

            var response = client
                .GetAsync(
                    $"https://financialmodelingprep.com/api/v3/cash-flow-statement/{ticker}?limit=10&apikey={_config["FMP:ApiKey"]}")
                .Result;

            var responseString = response.Content.ReadAsStringAsync().Result;
            
            var jsonResponse = JsonConvert.DeserializeObject<List<CashFlowStatementDto>>(responseString);

            if (jsonResponse == null) return RedirectToAction("Index", new { pageNumber = index });
            try
            {
                _shortListStockService.AddToCashFlowStatement(jsonResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", new { pageNumber = index });
        }

        [Route("/Shortlist/Add/{ticker}/{stockId:long}")]
        [HttpPost]
        public IActionResult AddShortlist(string ticker, long stockId, int index)
        {
            if (User.Identity == null)
            {
                throw new NullReferenceException(nameof(User.Identity));
            }

            var findFirstValue = User.Identity.Name;
            if (findFirstValue != null)
            {
                _shortListStockService.AddToShortlist(new ShortlistDto()
                {
                    Ticker = ticker,
                    StockInfoDataId = stockId,
                    UserId = findFirstValue
                });
            }
            //FIXME: Should display shortlist
            return Redirect($"Index/?pageNumber={index}");
        }

        [Route("/Shortlist/Remove/{ticker}")]
        [HttpPost]
        public IActionResult DeleteShortlist(string ticker)
        {
            var currentUser = User.Identity?.Name;
            if (currentUser != null)
            {
                _shortListStockService.DeleteFromShortlist(ticker, currentUser);
            }
            return Redirect("/Shortlist");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

public class ExternalSubscriptionService : IExternalSubscriptionService
{
    private readonly SubscriptionService _subscriptionService;

    public ExternalSubscriptionService(
        IConfiguration? config)
    {
        StripeConfiguration.ApiKey = config?["StripeAPIKey"];
            
        _subscriptionService = new SubscriptionService();
    }

    public StripeList<Subscription> Retrieve()
    {
        return _subscriptionService.List(new SubscriptionListOptions());
    }
}


public interface IExternalSubscriptionService
{
    public StripeList<Subscription> Retrieve();
}