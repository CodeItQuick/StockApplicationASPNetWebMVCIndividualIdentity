using System.Linq.Expressions;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class ShortlistStockInfoDataServiceTests
{
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
            .ShortlistedStocks(1, "mock_user_one");
        
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
                    Ticker = "MSFT",
                    UserId = "mock_user_one"
                },
                new()
                {
                    Id = 2,
                    Ticker = "AAPL",
                    UserId = "mock_user_one"
                },
                new()
                {
                    Id = 3,
                    Ticker = "COKE",
                    UserId = "mock_user_one"
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
            .ShortlistedStocks(0, "mock_user_one");
        
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
        Assert.Equal(0.20m,stocksAdapters.Single().stockAttribute?["PbRatio"]);
        Assert.Equal(-0.04m,stocksAdapters.Single().stockAttribute?["PeRatio"]);
        Assert.Equal(-0.24m,stocksAdapters.Single().stockAttribute?["Eps"]);
        Assert.Equal(2.04m,stocksAdapters.Single().stockAttribute?["DivYield"]);
    }
}