using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class IndividualStocksControllerTests
{
    private Mock<DbSet<IndividualStockDto>> _mockSet;
    private Mock<StockContext> _context;

    public IndividualStocksControllerTests()
    {
        // Data
        var individualStockDtos = new List<IndividualStockDto>
        {
            new() { Id = 1, Symbol = "ABC", Date = DateTimeOffset.Now, },
            new() { Id = 2, Symbol = "ABC", Date = DateTimeOffset.Now, },
            new() { Id = 3, Symbol = "ABC", Date = DateTimeOffset.Now, }
        };
        var subscriptionsDtos = new List<SubscriptionsDto>
        {
            new() { Id = 1, Description = "ABC"},
            new() { Id = 2, Description = "ABC" },
            new() { Id = 3, Description = "ABC" },
        };
        var cashFlowStatementDtos = new List<CashFlowStatementDto>
        {
            new() { Id = 1, Symbol = "ABC" },
            new() { Id = 2, Symbol = "ABC"  },
            new() { Id = 3, Symbol = "ABC"  },
        };

        //Setup DbSetMock
        var individualStocksDbSet = SetupDbSet(new Mock<DbSet<IndividualStockDto>>(), individualStockDtos);
        var subscriptionsDbSet = SetupDbSet(new Mock<DbSet<SubscriptionsDto>>(), subscriptionsDtos);
        var cashFlowStatementDbSet = SetupDbSet(new Mock<DbSet<CashFlowStatementDto>>(), cashFlowStatementDtos);

        //Setup Context
        _context = new Mock<StockContext>();
        _context.Setup(x => x.IndividualStocks).Returns(individualStocksDbSet.Object);
        _context.Setup(x => x.Subscriptions).Returns(subscriptionsDbSet.Object);
        _context.Setup(x => x.CashFlowStatement).Returns(cashFlowStatementDbSet.Object);
    }

    private Mock<DbSet<TEntity>> SetupDbSet<TEntity>(Mock<DbSet<TEntity>> mockset, List<TEntity> individualStockDtos)
        where TEntity : class
    {
        mockset.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(individualStockDtos.AsQueryable().Provider);
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

    [Fact]
    public void HomeControllerWhenIndividualStocksCalledReturnsResponse()
    {
        var service = new HomeController(
            null, 
            null, 
            null, 
            null, 
            new SubscriptionsRepository(_context.Object));
        var individualStock = service.IndividualStock("ABC", new StockInfoRequest()) as ViewResult;

        Assert.Equal(3,
            (individualStock?.Model as IndividualStockResponseModel<IndividualStockDto>)
            .StockSubscriptions
            .Count());
    }
}