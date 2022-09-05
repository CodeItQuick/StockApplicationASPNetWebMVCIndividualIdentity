using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class ApplicationTests
{
    [Fact]
    public void GivenAnIndexCanHandleEmptyListOfStocks()
    {
        // construct mock repository
        var repository = new Mock<IStockDataRepository>();
        repository.Setup(r => 
            r.Get(null, null, ""))
            .Returns(new List<StockInfoDatumDTO>());
        var service = new StockService(repository.Object);
        
        // display the stocks from the service
        var allStocks = service.DisplayAllStocks(1);
        
        // check the return value + that we got all the repository calls
        Assert.Equal(new List<StockAdapterDTO>(), allStocks);
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void GivenAnIndexCanHandleListOfStocks()
    {
        var repository = new Mock<IStockDataRepository>();
        var stockInfoDatumDtos = new List<StockInfoDatumDTO>()
        {
            new()
            {
                Symbol = "DummySymbol",
                PeRatio = new decimal(0.25),
            }
        };
        repository.Setup(r => 
                r.Get(null, null, ""))
            .Returns(stockInfoDatumDtos);
        var service = new StockService(repository.Object);
        
        var allStocks = service.DisplayAllStocks(0).ToList();
        
        Assert.Single(allStocks);
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void GivenShortListedStocksCanHandleEmptyListOfStocks()
    {
        var repository = new Mock<IShortListRepository>();
        repository.Setup(r => 
                r.Get(null, null, ""))
            .Returns(new List<ShortListDTO>());
        var service = new StockService(repository.Object);
        
        var allStocks = service
            .ShortlistedStocks(1);
        
        Assert.Equal(new List<StockAdapterDTO>(), allStocks);
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
}