using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListAdapterConverter
{
    
    public static List<StocksAdapter> Of(List<Stock> stocks)
    {
        List<StocksAdapter> shortlistStocks = new List<StocksAdapter>();
        foreach (var stock in stocks)
        {
            StocksAdapter stockAdapter = new()
            {
                stockAttribute = new(),
                Ticker = stock.Ticker(),
                Id = Convert.ToInt64(stock.Attributes()["Id"])
            };
            stockAdapter.stockAttribute["PbRatio"] = stock.Attributes()["PbRatio"];
            stockAdapter.stockAttribute["PeRatio"] = stock.Attributes()["PeRatio"];
            stockAdapter.stockAttribute["Eps"] = stock.Attributes()["Eps"];
            stockAdapter.stockAttribute["DivYield"] = stock.Attributes()["DivYield"];
            stockAdapter.stockAttribute["MarketCap"] = stock.Attributes()["MarketCap"];
            stockAdapter.stockAttribute["IntrinsicValue"] = 
                Convert.ToDecimal(stock?.StraightLineStockValueForYear(0));
            stockAdapter.stockAttribute["PredictedIntrinsicValue"] = 
                Convert.ToDecimal(stock?.RegressionStockValueForYear(20));
            Enumerable.Range(0, stock?.Cashflow().Count ?? 0)
                .ToList()
                .ForEach(idx =>
                {
                    stockAdapter.stockAttribute?.Add($"Cashflow{idx}", stock.CashFlows(idx));
                    
                });
            shortlistStocks.Add(stockAdapter);
        }

        return shortlistStocks;
    }
}