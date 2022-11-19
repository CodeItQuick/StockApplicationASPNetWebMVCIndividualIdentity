﻿using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly StockIndexService _stockIndexService;
        private readonly ShortlistStockInfoDataService _shortlistStockInfoDataService;
        private readonly ShortlistService _shortlistService;
        private static readonly HttpClient client = new HttpClient();
        private readonly IncomeStatementService _incomeStatementService;
        private readonly KeyMetricsService _keyMetricsService;
        private readonly RatiosTtmService _ratiosTtmService;
        private readonly CashFlowStatementService _cashFlowStatementService;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager, 
            IConfiguration config)
        {
            _logger = logger;
            _userManager = userManager;
            _config = config;
            _stockIndexService = new StockIndexService(new UnitOfWork());
            _shortlistStockInfoDataService = new ShortlistStockInfoDataService(new UnitOfWork());
            _shortlistService = new ShortlistService(new UnitOfWork());
            _incomeStatementService = new IncomeStatementService(new UnitOfWork());
            _keyMetricsService = new KeyMetricsService(new UnitOfWork());
            _ratiosTtmService = new RatiosTtmService(new UnitOfWork());
            _cashFlowStatementService = new CashFlowStatementService(new UnitOfWork());
        }

        public IActionResult Index(
            StockInfoRequest stockInfoRequest,
            int? pageNumber)
        {
            // DB/Application
            var stockInfoDatums = _stockIndexService.DisplayAllStocks(
                stockInfoRequest.pageNumber ?? pageNumber ?? 0);
            // Display/Adapter
            var model = new IndexResponseModel<StocksAdapter>()
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums,
                PageIndex = stockInfoRequest.pageNumber ?? 0
            };
            return View(model);
        }

        [Route("/Shortlist")]
        [HttpGet]
        public IActionResult Shortlist(
            StockInfoRequest? stockInfoRequest)
        {
            // DB/Application
            var stockInfoDatums = _shortlistStockInfoDataService.ShortlistedStocks(
                stockInfoRequest?.pageNumber ?? 0);
            // Display/Adapter
            var model = new IndexResponseModel<StocksAdapter>
            {
                HasPreviousPage = stockInfoRequest?.pageNumber >= 1,
                HasNextPage = (stockInfoRequest?.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums,
                PageIndex = stockInfoRequest?.pageNumber ?? 0
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
                    _incomeStatementService.AddToIncomeStatements(jsonResponse);
            }

            return RedirectToAction("Index");
        }
        

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
                _keyMetricsService.AddToKeyMetrics(jsonResponse);
            }

            return RedirectToAction("Index");
        }
        
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
            _ratiosTtmService.AddToRatiosTtm(jsonResponse);

            return RedirectToAction("Index");
        }
        
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
                _cashFlowStatementService.AddToCashFlowStatement(jsonResponse);
            }

            return RedirectToAction("Index");
        }
        
        [Route("/Shortlist/Add/{ticker}/{stockid:long}")]
        [HttpPost]
        public IActionResult AddShortlist(string ticker, long stockid)
        {
            if (User.Identity == null)
            {
                throw new NullReferenceException(nameof(User.Identity));
            }

            var findFirstValue = User.Identity.Name;
            _shortlistService.AddToShortlist(new ShortlistDto()
            {
                Ticker = ticker,
                StockInfoDataId = stockid,
                UserId = findFirstValue
            });
            //FIXME: Should display shortlist
            return Redirect("/?pageNumber=0");
        }

        [Route("/Shortlist/Remove/{ticker}")]
        [HttpPost]
        public IActionResult DeleteShortlist(string ticker)
        {
            string currentUser = User.Identity.Name;
            _shortlistService.DeleteFromShortlist(ticker, currentUser);
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