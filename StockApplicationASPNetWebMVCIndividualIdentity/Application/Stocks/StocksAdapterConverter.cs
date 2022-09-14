using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StocksAdapterConverter
{
    public static IEnumerable<StocksAdapter> ConvertFrom(IEnumerable<StockInfoDatumDTO> stockInfo)
    {
        var stocksList = stockInfo.Select(r =>
        {
            var stock = new Stock(r.Ticker ?? "undefined");
            stock.AddDefaultAttributes(
                r.Roe ?? Decimal.Zero,
                r.PeRatio ?? Decimal.Zero,
                Decimal.Parse((r.MarketCap != null ? r.MarketCap.ToString() : "0.0") ?? "0.0"),
                r.Eps ?? Decimal.Zero
            );

            StocksAdapter stockAdapterData = new StocksAdapter();
            stockAdapterData.Ticker = stock.Ticker();
            stockAdapterData.Id = r.Id;
            stockAdapterData.stockAttribute = stock.Attributes();
            return stockAdapterData;
        });
        return stocksList;
    }
}