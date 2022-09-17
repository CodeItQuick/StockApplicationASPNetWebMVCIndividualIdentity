using System.Linq.Expressions;
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
    [Fact]
    public void GivenShortListedStocksCanHandleEmptyListOfStocks()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork.Setup(r => 
                r.ShortlistStockInfoDataViewRepository.Get(null, null, null))
            .Returns(new List<ShortlistStockInfoDataView>());
        unitOfWork.Setup(r =>
            r.StockRepository.Get(null, null, null));
        var service = new ShortlistStockInfoDataService(unitOfWork.Object);
        
        var allStocks = service
            .ShortlistedStocks(1);
        
        Assert.Equal(new List<StocksAdapter>(), allStocks.ToList());
        unitOfWork.Verify(r => 
            r.ShortlistStockInfoDataViewRepository.Get(null, null, ""),
            Times.Once);
        unitOfWork.Verify(r => 
            r.StockRepository.Get(null, null, ""),
            Times.Once);
        unitOfWork.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void CanProduceMultipleStocksInShortlist()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        unitOfWork.Setup(r => 
                r.ShortlistStockInfoDataViewRepository
                    .Get(null, null, ""))
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
        unitOfWork.Setup(r =>
            r.StockRepository.Get(null, null, ""))
            .Returns(new List<StockInfoDatumDTO>()
            {
                new()
                {
                    Id = 1,
                    Ticker = "MSFT",
                    PeRatio = 0.12m,
                    PbRatio = 0.13m,
                    Eps = 0.14m,
                    DivYield = 0.15m,
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
        var service = new ShortlistStockInfoDataService(unitOfWork.Object);
        
        var allStocks = service
            .ShortlistedStocks(0);
        
        Assert.Equal(3, allStocks.ToList().Count);
        Assert.Equal(0.12m, allStocks.ToList().First().stockAttribute?["PeRatio"]);
        Assert.Equal(0.13m, allStocks.ToList().First().stockAttribute?["PbRatio"]);
        Assert.Equal(0.14m, allStocks.ToList().First().stockAttribute?["Eps"]);
        Assert.Equal(0.15m, allStocks.ToList().First().stockAttribute?["DivYield"]);
        unitOfWork.Verify(r => 
            r.ShortlistStockInfoDataViewRepository.Get(null, null, ""));
        unitOfWork.Verify(r => 
            r.StockRepository.Get(null, null, ""));
        unitOfWork.VerifyNoOtherCalls();
        
    }
    [Fact]
    public void CanAddToShortlistRepository()
    {
        var repository = new Mock<IUnitOfWork>();
        ShortlistDto shortListDTO = new ShortlistDto()
        {
            Ticker = "new ticker"
        };
        repository.Setup(r => 
                r.ShortListRepository.Add(shortListDTO));
        repository.Setup(r => r.SaveChanges());
        var service = new ShortlistService(repository.Object);

        service.AddToShortlist(shortListDTO);

        repository.Verify(r => 
            r.ShortListRepository.Add(shortListDTO));
        repository.Verify(r => 
            r.SaveChanges());
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
            }
        };
        var allStocks = new List<StockInfoDatumDTO>()
        {
            new StockInfoDatumDTO()
            {
                Id = 1,
                Ticker = "HPR",
                PbRatio = 0.20m,
                PeRatio = -0.04m,
                Eps = -0.24m,
                DivYield = 2.04m,
            }
        };

        var stocksAdapters = ShortListAdapterConverter
            .Convert(shortlistStockInfoDataViews, allStocks);
        
        Assert.Single(stocksAdapters);
        Assert.Equal("HPR",stocksAdapters.Single().Ticker);
        Assert.Equal(1,stocksAdapters.Single().Id);
        Assert.Equal(0.20m,stocksAdapters.Single().stockAttribute["PbRatio"]);
        Assert.Equal(-0.04m,stocksAdapters.Single().stockAttribute["PeRatio"]);
        Assert.Equal(-0.24m,stocksAdapters.Single().stockAttribute["Eps"]);
        Assert.Equal(2.04m,stocksAdapters.Single().stockAttribute["DivYield"]);
    }
}