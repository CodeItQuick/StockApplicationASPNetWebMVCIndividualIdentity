using System.Security.Claims;
using System.Security.Principal;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
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
        _controller = new HomeController(
            null, 
            null, 
            _unitOfWork, 
            null, 
            null,
            _subscriptionService.Object, 
            new IndividualStockRepository(new StockContext()), 
            new SubscriptionsRepository(new StockContext()), new CashFlowStatementRepository(new StockContext()));
        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new GenericIdentity("test_user_1"))
            }
        };
    }

    [Fact]
    public void WhenAddingToTheShortlistSuccessfullyAddsResults()
    {
        _controller.AddShortlist( "ABC", 1L);
        
        Assert.Equal(4, _unitOfWork.ShortListRepository.GetAll().Count());
    }
    
    
}