using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockService
{
    public IEnumerable<Stock> DisplayAllStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        var stockInfo = unitOfWork.StockRepository.Get();
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
        
        return stockList.RetrieveIndex(pageNumber);
    }
}