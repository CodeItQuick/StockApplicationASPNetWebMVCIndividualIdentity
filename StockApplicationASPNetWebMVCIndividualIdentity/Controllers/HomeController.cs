using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Models;
using System.Diagnostics;
using StockApplicationASPNetWebMVCIndividualIdentity.Data;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly stockContext _stockContext;

        public HomeController(ILogger<HomeController> logger, stockContext stockContext)
        {
            _logger = logger;
            _stockContext = stockContext;
        }

        public IActionResult Index(
            StockInfoRequest stockInfoRequest)
        {
                var stockInfoDatums = _stockContext.StockInfoData
                    .ToList();
                var model = new IndexResponseModel()
                {
                    HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                    HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                    stockInfoDatums = stockInfoDatums.Skip(stockInfoRequest.pageNumber * 20 ?? 0).Take(20).ToList(),
                    PageIndex = stockInfoRequest.pageNumber ?? 0
                };
                return View(model);
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