using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockService
{
    private readonly IStockDataRepository? _stockDataRepository;

    public StockService()
    {
        
    }

    public StockService(IStockDataRepository stockDataRepository)
    {
        _stockDataRepository = stockDataRepository;
    }

    public IEnumerable<StockAdapterDTO> DisplayAllStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _stockDataRepository ?? unitOfWork.StockRepository;
        var stockInfo = stockDataRepository.Get();
        var stockList = new IndexStock("W5000");

        var mappedStocks = stockInfo.Select(stockData =>
        {
            if (stockData is { PeRatio: { }, Symbol: { } })
            {
                return new Stock(stockData.Symbol, new List<StockAttributeDecimal>()
                {
                    new("PeRatio", stockData?.PeRatio ?? 0)
                });
            }

            return new Stock("undefined");
        }); 
        stockList.Populate(mappedStocks);

        var displayAllStocks = stockList.RetrieveIndex(pageNumber)
            .Select(r => new StockAdapterDTO()
            {
                Symbol = r.Ticker(),
                PeRatio = r.RetrieveAttributeFor(r.Ticker(), "PeRatio")!.Value
            });
        return displayAllStocks;
    }
}