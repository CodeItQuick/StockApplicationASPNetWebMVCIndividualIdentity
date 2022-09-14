using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StockIndexService _stockIndexService;
        private readonly ShortListService _shortListService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _stockIndexService = new StockIndexService();
            _shortListService = new ShortListService();
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
            var stockInfoDatums = _shortListService.ShortlistedStocks(
                stockInfoRequest?.pageNumber ?? 0);
            // Display/Adapter
            var model = new IndexResponseModel<StocksAdapter>
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums,
                PageIndex = stockInfoRequest.pageNumber ?? 0
            };
            return View(model);
        }
        [Route("/Shortlist/Add/{ticker}/{stockid:long}")]
        [HttpPost]
        public IActionResult AddShortlist(string ticker, long stockid)
        {
            _shortListService.AddToShortlist(new ShortListDTO()
            {
                Ticker = ticker,
                Id = stockid,
                UserId = 1
            });
            //FIXME: Should display shortlist
            return Redirect("/?pageNumber=1");
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