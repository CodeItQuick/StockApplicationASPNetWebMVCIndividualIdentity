﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StockService _stockService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _stockService = new StockService();
        }

        public IActionResult Index(
            StockInfoRequest stockInfoRequest)
        {
            // DB/Application
            var stockInfoDatums = _stockService.DisplayAllStocks(
                stockInfoRequest.pageNumber ?? 0);
            // Display/Adapter
            var model = new IndexResponseModel()
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums.ToList(),
                PageIndex = stockInfoRequest.pageNumber ?? 0
            };
            return View(model);
        }

        public IActionResult Shortlist(
            StockInfoRequest stockInfoRequest)
        {
            // DB/Application
            var stockInfoDatums = _stockService.ShortlistedStocks(
                stockInfoRequest.pageNumber ?? 0);
            // Display/Adapter
            var model = new IndexResponseModel()
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums.ToList(),
                PageIndex = stockInfoRequest.pageNumber ?? 0
            };
            return View(model);
        }
        [Route("/Shortlist/Add/{id}")]
        [HttpPut]
        public IActionResult AddShortlist(
            StockInfoRequest stockInfoRequest,
            string id)
        {
            // DB/Application
            var stockInfoDatums = _stockService
                .AddToShortlist(id, stockInfoRequest.pageNumber);
            // Display/Adapter
            var model = new IndexResponseModel()
            {
                HasPreviousPage = stockInfoRequest.pageNumber >= 1,
                HasNextPage = (stockInfoRequest.pageNumber ?? 0) < 10, // FIXME: pretending there are 10 pages for now
                StockInfoDatums = stockInfoDatums.ToList(),
                PageIndex = stockInfoRequest.pageNumber ?? 0
            };
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