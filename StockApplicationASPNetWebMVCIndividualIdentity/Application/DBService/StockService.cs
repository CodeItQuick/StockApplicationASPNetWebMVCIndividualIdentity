using System.Globalization;
using StockApplication.Core.Tests;
using StockApplication.Core.Tests.Application;
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
            var stock = new Stock(r.Ticker ?? "undefined");
            stock.AddDefaultAttributes(
                r.Roe ?? Zero,
                r.PeRatio ?? Zero,
                Parse((r.MarketCap != null ? r.MarketCap.ToString() : "0.0") ?? "0.0"),
                r.Eps ?? Zero
            );
            
            StocksAdapter stockAdapterData = new StocksAdapter();
            stockAdapterData.Ticker = stock.Ticker();
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
            if (shortListDto.Ticker != null)
            {
                StocksAdapter stockAdapter = new StocksAdapter();
                stockAdapter.Ticker = shortListDto.Ticker ?? "";
                stockAdapter.Id = shortListDto.Id;
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

    public void AddToShortlist(ShortListDTO shortListDto)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        shortListRepository.Add(shortListDto);
        unitOfWork.SaveChanges();
    }
}

public class StocksAdapter
{
    public string Ticker { get; set; }
    public Dictionary<string, decimal>? stockAttribute { get; set; } = new Dictionary<string, decimal>();
    public long Id { get; set; }
}