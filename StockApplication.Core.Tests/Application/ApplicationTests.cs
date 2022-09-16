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
        var service = new StockIndexService(repository.Object);
        
        // display the stocks from the service
        var allStocks = service.DisplayAllStocks(1);
        
        // check the return value + that we got all the repository calls
        Assert.Equal(new List<StocksAdapter>(), allStocks);
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
                Ticker = "DummySymbol",
                PeRatio = new decimal(0.25),
            }
        };
        repository.Setup(r => 
                r.Get(null, null, ""))
            .Returns(stockInfoDatumDtos);
        var service = new StockIndexService(repository.Object);
        
        var allStocks = service.DisplayAllStocks(0).ToList();
        
        Assert.Single(allStocks);
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void GivenShortListedStocksCanHandleEmptyListOfStocks()
    {
        var repository = new Mock<IShortlistStockInfoDataViewRepository>();
        repository.Setup(r => 
                r.Get(null, null, ""))
            .Returns(new List<ShortlistStockInfoDataView>());
        var service = new ShortlistStockInfoDataService(repository.Object);
        
        var allStocks = service
            .ShortlistedStocks(1);
        
        Assert.Equal(new List<StocksAdapter>(), allStocks.ToList());
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void CanProduceMultipleStocksInShortlist()
    {
        var repository = new Mock<IShortlistStockInfoDataViewRepository>();
        repository.Setup(r => 
                r.Get(null, null, ""))
            .Returns(new List<ShortlistStockInfoDataView>()
            {
                new()
                {
                    Id = 1,
                    Ticker = "MSFT"
                },
                new()
                {
                    Id = 2,
                    Ticker = "AAPL"
                },
                new()
                {
                    Id = 3,
                    Ticker = "COKE"
                },
            });
        var service = new ShortlistStockInfoDataService(repository.Object);
        
        var allStocks = service
            .ShortlistedStocks(0);
        
        Assert.Equal(3, allStocks.ToList().Count);
        repository.Verify(r => 
            r.Get(null, null, ""));
        repository.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void CanAddToShortlistRepository()
    {
        var repository = new Mock<IShortListRepository>();
        ShortlistDto shortListDTO = new ShortlistDto()
        {
            Ticker = "new ticker"
        };
        repository.Setup(r => 
                r.Add(shortListDTO));
        var service = new ShortlistService(repository.Object);

        service.AddToShortlist(shortListDTO);

        repository.Verify(r => 
            r.Add(shortListDTO));
        repository.VerifyNoOtherCalls();
        
    }

    [Fact]
    public void ShortListAdapterCanConvertToStocksAdapter()
    {
        var shortlistStockInfoDataViews = new List<ShortlistStockInfoDataView>()
        {
            new ShortlistStockInfoDataView()
            {
                Id = 1,
                TickerId = 1,
                Ticker = "HPR",
                UserId = 1,
                Eps = -274.65m,
                PeRatio = -0.04m,
                MarketCap = 4600000.00m,
                Roe = 250.0m
            }
        };

        var stocksAdapters = ShortListAdapterConverter
            .Convert(shortlistStockInfoDataViews);
        
        Assert.Single(stocksAdapters);
        Assert.Equal("HPR",stocksAdapters.Single().Ticker);
        Assert.Equal(1,stocksAdapters.Single().Id);
        Assert.Equal(4600000.00m,stocksAdapters.Single().MarketCap);
        Assert.Equal(-0.04m,stocksAdapters.Single().PeRatio);
        Assert.Equal(250.0m,stocksAdapters.Single().Roe);
        Assert.Equal(-274.65m,stocksAdapters.Single().Eps);
    }
}