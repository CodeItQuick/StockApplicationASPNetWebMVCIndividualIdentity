using System.Security.Claims;
using System.Security.Principal;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using Stripe;

namespace StockApplication.Core.Tests.Adapter;

public class HomeControllerMockingTests
{
    private HomeController _controller;
    private UnitOfWork _unitOfWork;
    private Mock<SubscriptionService> _subscriptionService;

    public HomeControllerMockingTests()
    {
        var databaseMethods = new DatabaseMethods();
        _unitOfWork = databaseMethods.CreateTestUnitOfWork();
        _subscriptionService = new Mock<SubscriptionService>();
        _controller = new HomeController(null, null, _unitOfWork, null, _subscriptionService.Object, null);
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new GenericIdentity("test_user_1"))
            }
        };
    }

    [Fact]
    public void WhenQueryingFirstPageReturnsThreeDefaultResults()
    {
        var actionResult = _controller.Index(new StockInfoRequest()
        {
            currentFilter = "",
            pageNumber = 0,
            searchString = "",
            sortOrder = "ASC"
        }, 0) as ViewResult;
        
        Assert.NotNull(actionResult?.Model as IndexResponseModel<StocksAdapter>);
        Assert.Equal(0, (actionResult?.Model as IndexResponseModel<StocksAdapter>)?.PageIndex);
        Assert.Equal(3, (actionResult?.Model as IndexResponseModel<StocksAdapter>)?.StockInfoDatums.Count());
    }
    
    [Fact]
    public void WhenQueryingShortlistReturnsThreeDefaultResults()
    {
        _subscriptionService.Setup(x => 
                x.List(It.IsAny<SubscriptionListOptions>(), 
                    It.IsAny<RequestOptions>()))
            .Returns(new StripeList<Subscription>()
            {
                Data = new EditableList<Subscription>()
                {
                    new()
                    {
                        Description = "Test Description - ZZZ Non-Matching Ticker"
                    }
                }
            });
        
        var actionResult = _controller.Shortlist(new StockInfoRequest()
        {
            currentFilter = "",
            pageNumber = 0,
            searchString = "",
            sortOrder = "ASC"
        }) as ViewResult;
        Assert.NotNull(actionResult?.Model as IndexResponseModel<StocksAdapter>);
        Assert.Equal(0, (actionResult?.Model as IndexResponseModel<StocksAdapter>)?.PageIndex);
        Assert.Equal(3, (actionResult?.Model as IndexResponseModel<StocksAdapter>)?.StockInfoDatums.Count());
    }
    
    [Fact]
    public void WhenQueryingIndividualStockReturnsThreeDefaultResults()
    {
        var actionResult = _controller.IndividualStock( "ABC", new StockInfoRequest()
        {
            currentFilter = "",
            pageNumber = 0,
            searchString = "",
            sortOrder = "ASC"
        }) as ViewResult;
        
        Assert.NotNull(actionResult?.Model as IndividualStockResponseModel<IndividualStockDto>);
        Assert.Equal(3, 
            (actionResult?.Model 
                as IndividualStockResponseModel<IndividualStockDto>)
            ?.IndividualStockEarningsView.Count());
    }
    [Fact]
    public void WhenAddingToTheShortlistSuccessfullyAddsResults()
    {
        _controller.AddShortlist( "ABC", 1L);
        
        Assert.Equal(4, _unitOfWork.ShortListRepository.GetAll().Count());
    }
    
    
}