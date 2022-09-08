using StockApplication.Core.Tests;
using StockApplication.Core.Tests.Application;
using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;
using static System.Decimal;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockService
{
    private readonly IStockDataRepository? _stockDataRepository;
    private readonly IShortListRepository? _shortListRepository;

    public StockService()
    {
        
    }

    public StockService(IStockDataRepository stockDataRepository)
    {
        _stockDataRepository = stockDataRepository;
    }
    public StockService(IShortListRepository shortListRepository)
    {
        _shortListRepository = shortListRepository;
    }

    public List<StocksAdapter> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _stockDataRepository ?? unitOfWork.StockRepository;
        var stockInfo = stockDataRepository
            .Get()
            .Skip(pageNumber).Take(20);

        var stocksList = stockInfo.Select(r =>
        {
            var stock = new Stock(r.Symbol ?? "undefined");
            stock.AddDefaultAttributes(
                r.Roe ?? Zero,
                r.PeRatio ?? Zero,
                Parse(r.MarketCap.ToString() ?? "0"),
                r.Eps ?? Zero
            );
            
            StocksAdapter stockAdapterData = new StocksAdapter();
            stockAdapterData.stockAttribute = stock.Attributes();
            return stockAdapterData;
        });

        return stocksList.ToList();
    }

    public List<ShortListDTO> ShortlistedStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        var stockInfo = shortListRepository.Get()
            .Skip(pageNumber).Take(20).ToList();

        List<StocksAdapter> shortlistStocks = new List<StocksAdapter>();
        foreach (var shortListDto in stockInfo)
        {
            if (shortListDto.Symbol != null)
            {
                StocksAdapter stockAdapter = new StocksAdapter();
                stockAdapter.Ticker = shortListDto.Symbol ?? "";
                shortListDto.GetType().GetProperties().ToList().ForEach(r =>
                {
                    if (stockAdapter.stockAttribute != null && r.PropertyType == typeof(decimal))
                    {
                        stockAdapter.stockAttribute.Add(r.ToString(), 
                            r.GetValue(shortListDto, null) is decimal ? 
                                (decimal)(r.GetValue(shortListDto, null) ?? 
                                          Zero) : 0);
                    };
                });
                shortlistStocks.Add(stockAdapter);
            }
            
        }
        
        return stockInfo.ToList();
    }

    public IEnumerable<StockAdapterDTO> AddToShortlist(string id, int? pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        var stockInfo = shortListRepository.Get();
        var shortList = new ShortList();

        var mappedStocks = stockInfo.Select(stockData =>
        {
            if (stockData is not { Symbol: { } })
            {
                return new Stock("undefined");
            }
            var defaultAttributes = StockAttributeDecimalsForShortlist(stockData);

            return new Stock(stockData.Symbol, defaultAttributes);

        }); 
        shortList.Populate(mappedStocks);
        
        var displayAllStocks = shortList.RetrieveStocks(pageNumber ?? 0)
            .Select(r => new StockAdapterDTO()
            {
                Symbol = r.Ticker(),
            });
        return displayAllStocks;
    }
    private static List<StockAttributeDecimal> StockAttributeDecimalsForShortlist(ShortListDTO stockData)
    {
        var defaultAttributes = new List<StockAttributeDecimal>()
        {
        };
        return defaultAttributes;
    }
}

public class StocksAdapter
{
    public string Ticker { get; set; }
    public Dictionary<string, decimal>? stockAttribute { get; set; } = new Dictionary<string, decimal>();
}