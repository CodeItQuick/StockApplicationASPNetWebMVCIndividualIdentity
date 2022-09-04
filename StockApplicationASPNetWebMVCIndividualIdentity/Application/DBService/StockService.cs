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
            if (stockData is not { PeRatio: { }, Symbol: { } })
            {
                return new Stock("undefined");
            }
            var defaultAttributes = StockAttributeDecimals(stockData);

            return new Stock(stockData.Symbol, defaultAttributes);

        }); 
        stockList.Populate(mappedStocks);

        var displayAllStocks = stockList.RetrieveIndex(pageNumber)
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
}