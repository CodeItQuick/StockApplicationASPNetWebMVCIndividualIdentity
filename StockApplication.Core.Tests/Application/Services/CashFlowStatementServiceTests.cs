using AutoFixture.Xunit2;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class CashFlowStatementServiceTests
{
    private Mock<DbSet<IndividualStockDto>> _mockSet;
    private Mock<StockContext> _context;

    public CashFlowStatementServiceTests()
    {
        // Data
        var cashFlowStatementDtos = new List<CashFlowStatementDto>
        {
            new() { Id = 1, Symbol = "ABC" },
            new() { Id = 2, Symbol = "ABC"  },
            new() { Id = 3, Symbol = "ABC"  },
        };

        //Setup DbSetMock
        var cashFlowStatementDbSet = SetupDbSet(new Mock<DbSet<CashFlowStatementDto>>(), cashFlowStatementDtos);

        //Setup Context
        _context = new Mock<StockContext>();
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
    [Theory, AutoData]
    public void CanAddRangeToCashFlowStatementRepositoryUsingDbContextMock(CashFlowStatementDto entry)
    {
        var service = new CashFlowStatementService(new CashFlowStatementRepository(_context.Object));
        entry.Id = 4;

        service.AddToCashFlowStatement(new List<CashFlowStatementDto>() { entry });

        Assert.Equal(4, _context.Object.CashFlowStatement?.Count());

    }
    [Theory, AutoData]
    public void CanRetrieveCashFlowStatementRepositoryUsingDbContextMock(CashFlowStatementDto entry)
    {
        var service = new CashFlowStatementService(new CashFlowStatementRepository(_context.Object));
        entry.Id = 4;

        var cashFlowStatementDtos = service.RetrieveIndividualStocks("ABC");

        Assert.Equal(3, cashFlowStatementDtos?.Count());

    }

}