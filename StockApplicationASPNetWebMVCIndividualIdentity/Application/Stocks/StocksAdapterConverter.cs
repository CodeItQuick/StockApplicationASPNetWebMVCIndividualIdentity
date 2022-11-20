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
                r.PbRatio ?? Decimal.Zero,
                r.PeRatio ?? Decimal.Zero,
                r.DivYield ?? Decimal.Zero,
                r.Eps ?? Decimal.Zero,
                (r.Roe + r.Roe1 + r.Roe2 + r.Roe3) / 4
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