using System.Linq.Expressions;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class StockIndexServiceTests
{
    [Fact]
    public void GivenAnIndexCanHandleEmptyListOfStocks()
    {
        // construct mock repository
        var repository = new Mock<IUnitOfWork>();
        repository.Setup(r => 
            r.StockRepository.Get(null, null, ""))
            .Returns(new List<StockInfoDatumDTO>());
        var service = new StockIndexService(repository.Object);
        
        // display the stocks from the service
        var allStocks = service.DisplayAllStocks(1);
        
        // check the return value + that we got all the repository calls
        Assert.Equal(new List<StocksAdapter>(), allStocks);
        repository.Verify(r => 
            r.StockRepository.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
    }
    [Fact]
    public void GivenAnIndexCanHandleListOfStocks()
    {
        var repository = new Mock<IUnitOfWork>();
        var stockInfoDatumDtos = new List<StockInfoDatumDTO>()
        {
            new()
            {
                Ticker = "DummySymbol",
                PeRatio = new decimal(0.25),
            }
        };
        repository.Setup(r => 
                r.StockRepository.Get(null, null, ""))
            .Returns(stockInfoDatumDtos);
        var service = new StockIndexService(repository.Object);
        
        var allStocks = service.DisplayAllStocks(0).ToList();
        
        Assert.Single(allStocks);
        repository.Verify(r => 
            r.StockRepository.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
}