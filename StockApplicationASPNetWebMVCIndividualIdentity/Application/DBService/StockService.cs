using StockApplication.Core.Tests;
using StockApplication.Core.Tests.Application;
using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockService
{
    public IShortListRepository ShortListRepository { get; }
    private readonly IStockDataRepository? _stockDataRepository;
    private IStockDataRepository _shortListRepository;

    public StockService()
    {
        
    }

    public StockService(IStockDataRepository stockDataRepository)
    {
        _stockDataRepository = stockDataRepository;
    }
    public StockService(IShortListRepository shortListRepository)
    {
        ShortListRepository = shortListRepository;
    }

    public IEnumerable<StockAdapterDTO> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _stockDataRepository ?? unitOfWork.StockRepository;
        var stockInfo = stockDataRepository.Get();
        var stockList = new IndexStock("W5000");

        // Map from database to domain
        var mappedStocks = stockInfo.Select(stockData =>
        {
            if (stockData is not { PeRatio: { }, Symbol: { } })
            {
                return new Stock("undefined");
            }
            var defaultAttributes = StockAttributeDecimals(stockData);

            return new Stock(stockData.Symbol, defaultAttributes);

        }); 
        
        // construct the domain through the "populate" method
        stockList.Populate(mappedStocks);
        
        // retrieve the index with the requested? attributes
        // Possible extensions:
        // 1. Default set of ratios/numbers
        // 2. User adjustment set of attributes
        var displayAllStocks = stockList.RetrieveIndex(pageNumber)
            .Select(r => new StockAdapterDTO() // Map to the Adapter
            {
                Symbol = r.Ticker(),
                PeRatio = r.RetrieveAttributeFor("PeRatio")!.Value,
                PbRatio = r.RetrieveAttributeFor("PbRatio")!.Value,
                CashFlowToSales = r.RetrieveAttributeFor("CashFlowToSales")!.Value,
                Roe = r.RetrieveAttributeFor("Roe")!.Value,
                BvS = r.RetrieveAttributeFor("BvS")!.Value,
                DivYield = r.RetrieveAttributeFor("DivYield")!.Value,
            });
        return displayAllStocks;
    }

    private static List<StockAttributeDecimal> StockAttributeDecimals(StockInfoDatumDTO stockData)
    {
        var defaultAttributes = new List<StockAttributeDecimal>()
        {
            new("PeRatio", stockData?.PeRatio ?? 0),
            new("PbRatio", stockData?.PbRatio ?? 0),
            new("CashFlowToSales", stockData?.CashFlowToSales ?? 0),
            new("Roe", stockData?.Roe ?? 0),
            new("BvS", stockData?.BvS ?? 0),
            new("DivYield", stockData?.DivYield ?? 0),
        };
        return defaultAttributes;
    }

    public IEnumerable<StockAdapterDTO> ShortlistedStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        var stockInfo = stockDataRepository.Get();
        var shortList = new ShortList();
        var mappedStocks = stockInfo.Select(stockData =>
        {
            if (stockData is not { PeRatio: { }, Symbol: { } })
            {
                return new Stock("undefined");
            }
            var defaultAttributes = StockAttributeDecimals(stockData);

            return new Stock(stockData.Symbol, defaultAttributes);

        }); 
        shortList.Populate(mappedStocks);

        var displayAllStocks = shortList.RetrieveStocks(pageNumber)
            .Select(r => new StockAdapterDTO()
            {
                Symbol = r.Ticker(),
                PeRatio = r.RetrieveAttributeFor("PeRatio")!.Value,
                PbRatio = r.RetrieveAttributeFor("PbRatio")!.Value,
                CashFlowToSales = r.RetrieveAttributeFor("CashFlowToSales")!.Value,
                Roe = r.RetrieveAttributeFor("Roe")!.Value,
                BvS = r.RetrieveAttributeFor("BvS")!.Value,
                DivYield = r.RetrieveAttributeFor("DivYield")!.Value,
            });
        return displayAllStocks;
    }

    public IEnumerable<StockAdapterDTO> AddToShortlist(string id, int? pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _stockDataRepository ?? unitOfWork.StockRepository;
        var stockInfo = stockDataRepository.Get();
        var shortList = new ShortList();

        var mappedStocks = stockInfo.Select(stockData =>
        {
            if (stockData is not { PeRatio: { }, Symbol: { } })
            {
                return new Stock("undefined");
            }
            var defaultAttributes = StockAttributeDecimals(stockData);

            return new Stock(stockData.Symbol, defaultAttributes);

        }); 
        shortList.Populate(mappedStocks);
        
        var displayAllStocks = shortList.RetrieveStocks(pageNumber ?? 0)
            .Select(r => new StockAdapterDTO()
            {
                Symbol = r.Ticker(),
                PeRatio = r.RetrieveAttributeFor("PeRatio")!.Value,
                PbRatio = r.RetrieveAttributeFor("PbRatio")!.Value,
                CashFlowToSales = r.RetrieveAttributeFor("CashFlowToSales")!.Value,
                Roe = r.RetrieveAttributeFor("Roe")!.Value,
                BvS = r.RetrieveAttributeFor("BvS")!.Value,
                DivYield = r.RetrieveAttributeFor("DivYield")!.Value,
            });
        return displayAllStocks;
    }
}