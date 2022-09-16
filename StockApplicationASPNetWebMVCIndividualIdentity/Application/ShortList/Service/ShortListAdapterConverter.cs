using StockApplication.Core.Tests.Application;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListAdapterConverter
{
    
    public static List<StocksAdapter> Convert(List<StockApplication.Core.Tests.Application.ShortlistStockInfoDataView> stockInfo)
    {
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
                            r.GetValue(shortListDto, null) is decimal
                                ? (decimal)(r.GetValue(shortListDto, null) ??
                                            Decimal.Zero)
                                : 0);
                    }

                    ;
                });
                shortlistStocks.Add(stockAdapter);
            }
        }

        return shortlistStocks;
    }
}