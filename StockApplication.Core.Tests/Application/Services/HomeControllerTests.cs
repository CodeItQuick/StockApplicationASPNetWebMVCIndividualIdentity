using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Protocol;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using Stripe;

namespace StockApplication.Core.Tests.Application;

// FIXME: No test in this file
public class HomeControllerTests
{
    private Mock<StockContext> _context;
    private Mock<Stripe.SubscriptionService> _subscriptionService = new();

    public HomeControllerTests()
    {
        // Data
        var shortlistStockDtos = new List<ShortlistStockInfoDataView>
        {
            new() { Id = 1, Ticker = "ABC", UserId = "username" },
            new() { Id = 2, Ticker = "CDE", UserId = "username" },
            new() { Id = 3, Ticker = "FGH", UserId = "username" }
        };
        var stockInfoDatumDtos = new List<StockInfoDatumDTO>
        {
            new() { Id = 1, Ticker = "ABC" },
            new() { Id = 2, Ticker = "EFG" },
            new() { Id = 3, Ticker = "HIJ" },
        };
        List<CashFlowStatementDto> cashFlowStatementDtos = new ()
        {
            new CashFlowStatementDto { Id = 1, Symbol = "ABC", FreeCashFlow = 1000 },
            new CashFlowStatementDto { Id = 2, Symbol = "ABC", FreeCashFlow = 2000 },
            new CashFlowStatementDto { Id = 3, Symbol = "ABC", FreeCashFlow = 3000 },
            new CashFlowStatementDto { Id = 4, Symbol = "ABC", FreeCashFlow = 4000 },
            new CashFlowStatementDto { Id = 5, Symbol = "ABC", FreeCashFlow = 5000 },
            new CashFlowStatementDto { Id = 6, Symbol = "ABC", FreeCashFlow = 6000 },
            new CashFlowStatementDto { Id = 7, Symbol = "ABC", FreeCashFlow = 7000 },
            new CashFlowStatementDto { Id = 8, Symbol = "ABC", FreeCashFlow = 8000 },
            new CashFlowStatementDto { Id = 9, Symbol = "ABC", FreeCashFlow = 9000 },
            new CashFlowStatementDto { Id = 10, Symbol = "ABC", FreeCashFlow = 10000 },
        };

        //Setup DbSetMock
        var shortlistStockDbSet = SetupDbSet(new Mock<DbSet<ShortlistStockInfoDataView>>(), shortlistStockDtos);
        var stockInfoDatumDbSet = SetupDbSet(new Mock<DbSet<StockInfoDatumDTO>>(), stockInfoDatumDtos);
        var cashFlowStatementDbSet = SetupDbSet(new Mock<DbSet<CashFlowStatementDto>>(), cashFlowStatementDtos);

        //Setup Context
        _context = new Mock<StockContext>();
        _context.Setup(x => x.ShortlistStockInfoDataView).Returns(shortlistStockDbSet.Object);
        _context.Setup(x => x.StockRepository).Returns(stockInfoDatumDbSet.Object);
        _context.Setup(x => x.CashFlowStatement).Returns(cashFlowStatementDbSet.Object);
    }

    private Mock<DbSet<TEntity>> SetupDbSet<TEntity>(Mock<DbSet<TEntity>> mockset, List<TEntity> individualStockDtos)
        where TEntity : class
    {
        mockset.As<IQueryable<TEntity>>().Setup(m => m.Provider)
            .Returns(individualStockDtos.AsQueryable().Provider);
        mockset.As<IQueryable<TEntity>>().Setup(m => m.Expression)
            .Returns(individualStockDtos.AsQueryable().Expression);
        mockset.As<IQueryable<TEntity>>().Setup(m => m.ElementType)
            .Returns(individualStockDtos.AsQueryable().ElementType);
        mockset.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator())
            .Returns(() => individualStockDtos.AsQueryable().GetEnumerator());
        mockset.Setup(d =>
                d.Add(It.IsAny<TEntity>()))
            .Callback<TEntity>((s) => individualStockDtos.Add(s));
        mockset.Setup(d =>
                d.AddRange(It.IsAny<IEnumerable<TEntity>>()))
            .Callback<IEnumerable<TEntity>>((s) => individualStockDtos.AddRange(s));
        return mockset;
    }

}