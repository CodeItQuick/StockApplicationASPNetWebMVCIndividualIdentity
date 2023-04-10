using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Protocol;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;
using Stripe;

namespace StockApplication.Core.Tests.Application;

public class HomeControllerTests : IClassFixture<HomeControllerFixtures>
{
    private readonly HomeControllerFixtures _fixture;
    private readonly HomeController _controller;

    public HomeControllerTests(HomeControllerFixtures fixture)
    {
        fixture.SeedDatabase();
        _fixture = fixture;
        _controller = new HomeController(
            null,
              null,
            null,
            new Mock<IExternalSubscriptionService>().Object,
            new StockIndexService(new StockIndexRepository(_fixture.StockContextDb)), 
            new ShortListStockService(_fixture.StockContextDb), 
            new SubscriptionsService(_fixture.StockContextDb));
        
        var claimsIdentity = new ClaimsIdentity(
            new List<Claim>() { new(ClaimTypes.Name, "test_username") }, 
            "TestAuthType");
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(claimsIdentity)
            }
        };
    }

    [Fact]
    public void IndexReturnsFirstPageWithResults()
    {
        var stockInfoRequest = new StockInfoRequest();

        var actionResult = _controller.Index(stockInfoRequest, 0) as ViewResult;

        var indexResponseModel = (actionResult?.Model as IndexResponseModel<StocksAdapter>);
        Assert.NotNull(actionResult);
        Assert.Equal(0, indexResponseModel?.PageIndex);
        Assert.Equal(2, indexResponseModel?.NumPages);
        Assert.Equal(20, indexResponseModel?.StockInfoDatums.Count);
    }

    [Fact]
    public void FindPageGivesSpecifiedPage()
    {
        var actionResult = _controller.FindPage("K", 1) as RedirectResult;

        Assert.NotNull(actionResult);
        Assert.Equal("Index/?pageNumber=1", actionResult?.Url);
    }

    [Fact]
    public void ShortlistReturnsFirstPageWithResults()
    {
        var stockInfoRequest = new StockInfoRequest();

        var actionResult = _controller.Shortlist(stockInfoRequest) as ViewResult;

        var indexResponseModel = (actionResult?.Model as IndexResponseModel<StocksAdapter>);
        Assert.NotNull(actionResult);
        Assert.Equal(0, indexResponseModel?.PageIndex);
        Assert.Equal(1, indexResponseModel?.NumPages);
        Assert.Equal(1, indexResponseModel?.StockInfoDatums.Count);
    }
    [Fact]
    public void IndividualStocksReturnsFirstPageWithResults()
    {

        var actionResult = _controller.IndividualStock("ABC", null) as ViewResult;

        var indexResponseModel = (actionResult?.Model as IndividualStockResponseModel<IndividualStockDto>);
        Assert.NotNull(actionResult);
        Assert.Equal(1, indexResponseModel?.IndividualStockEarningsView?.Count());
        Assert.Equal(0, indexResponseModel?.StockSubscriptions.Count());
        Assert.Equal(10, indexResponseModel?.CashFlowDto.Count);
    }
    [Fact]
    public void AddToShortlistReturnsProperPage()
    {

        var actionResult = _controller.AddShortlist("ABC", 1, 1) as RedirectResult;

        Assert.NotNull(actionResult);
        Assert.Equal("Index/?pageNumber=1", actionResult?.Url);
    }
    [Fact]
    public void RemoveFromShortlistReturnsProperPage()
    {

        var actionResult = _controller.DeleteShortlist("ABC") as RedirectResult;

        Assert.NotNull(actionResult);
        Assert.Equal("/Shortlist", actionResult?.Url);
    }
    [Fact]
    public void SettingsPageWithResults()
    {

        var actionResult = _controller.Settings(null) as ViewResult;

        Assert.NotNull(actionResult);
    }
    [Fact]
    public void PrivacyPageWithResults()
    {

        var actionResult = _controller.Privacy() as ViewResult;

        Assert.NotNull(actionResult);
    }
}

public abstract class HomeControllerFixtures
{
    // Data
    private readonly List<IndividualStockDto> _individualStock = new()
    {
        new IndividualStockDto() { Symbol = "ABC" }
    };
    private readonly List<ShortlistDto> _shortlist = new()
    {
        new ShortlistDto() { Ticker = "ABC", UserId = "test_username", StockInfoDataId = 1 }
    };

    private readonly List<StockInfoDatumDTO> _stockInfoDatum = new()
    {
        new StockInfoDatumDTO { Id = 1, Ticker = "ABC" },
        new StockInfoDatumDTO { Id = 2, Ticker = "BBB" },
        new StockInfoDatumDTO { Id = 3, Ticker = "CCC" },
        new StockInfoDatumDTO { Id = 4, Ticker = "DDD" },
        new StockInfoDatumDTO { Id = 5, Ticker = "DDE" },
        new StockInfoDatumDTO { Id = 6, Ticker = "DDF" },
        new StockInfoDatumDTO { Id = 7, Ticker = "DDG" },
        new StockInfoDatumDTO { Id = 8, Ticker = "DDH" },
        new StockInfoDatumDTO { Id = 9, Ticker = "DDI" },
        new StockInfoDatumDTO { Id = 10, Ticker = "EFG" },
        new StockInfoDatumDTO { Id = 11, Ticker = "EFH" },
        new StockInfoDatumDTO { Id = 12, Ticker = "HIJ" },
        new StockInfoDatumDTO { Id = 13, Ticker = "JKL" },
        new StockInfoDatumDTO { Id = 14, Ticker = "JKM" },
        new StockInfoDatumDTO { Id = 15, Ticker = "JKN" },
        new StockInfoDatumDTO { Id = 16, Ticker = "JKO" },
        new StockInfoDatumDTO { Id = 17, Ticker = "JKP" },
        new StockInfoDatumDTO { Id = 18, Ticker = "JKQ" },
        new StockInfoDatumDTO { Id = 19, Ticker = "JKR" },
        new StockInfoDatumDTO { Id = 20, Ticker = "JKS" },
        new StockInfoDatumDTO { Id = 21, Ticker = "KLM" },
    };

    private readonly List<CashFlowStatementDto> _cashFlowStatement = new()
    {
        new CashFlowStatementDto
        {
            Id = 1, Symbol = "ABC", FreeCashFlow = 1000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 2, Symbol = "ABC", FreeCashFlow = 2000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 3, Symbol = "ABC", FreeCashFlow = 3000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 4, Symbol = "ABC", FreeCashFlow = 4000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 5, Symbol = "ABC", FreeCashFlow = 5000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 6, Symbol = "ABC", FreeCashFlow = 6000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 7, Symbol = "ABC", FreeCashFlow = 7000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 8, Symbol = "ABC", FreeCashFlow = 8000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 9, Symbol = "ABC", FreeCashFlow = 9000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
        new CashFlowStatementDto
        {
            Id = 10, Symbol = "ABC", FreeCashFlow = 10000, Date = DateTimeOffset.Now, ReportedCurrency = "USD",
            Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023",
            Period = "1", Link = "123", FinalLink = "123"
        },
    };

    public StockContext? StockContextDb;
    private SqliteConnection? _connection;

    public void SeedDatabase()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<StockContext>().UseSqlite(_connection).Options;

        StockContextDb = new StockContext(options);
        StockContextDb.Database.EnsureCreated();

        StockContextDb.IndividualStocks?.AddRange(_individualStock);
        StockContextDb.Shortlists?.AddRange(_shortlist);
        StockContextDb.StockRepository.AddRange(_stockInfoDatum);
        StockContextDb.CashFlowStatement?.AddRange(_cashFlowStatement);
        StockContextDb.Subscriptions?.AddRange(new []{ new SubscriptionsDto() });
        StockContextDb.SaveChanges();
    }
}