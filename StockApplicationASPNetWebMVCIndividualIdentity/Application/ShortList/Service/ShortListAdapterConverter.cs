using StockApplication.Core.Tests.Application;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListAdapterConverter
{
    
    public static List<StocksAdapter> Convert(List<ShortlistStockInfoDataView> stockInfo)
    {
        List<StocksAdapter> shortlistStocks = new List<StocksAdapter>();
        foreach (var shortListDto in stockInfo)
        {
            if (shortListDto.Ticker != null)
            {
                StocksAdapter stockAdapter = new StocksAdapter();
                stockAdapter.Ticker = shortListDto.Ticker ?? "";
                stockAdapter.Id = shortListDto.Id;
                stockAdapter.Roe = shortListDto.Roe ?? 0.0m;
                stockAdapter.PeRatio = shortListDto.PeRatio ?? 0.0m;
                stockAdapter.MarketCap = shortListDto.MarketCap ?? 0.0m;
                stockAdapter.Eps = shortListDto.Eps ?? 0.0m;
                shortlistStocks.Add(stockAdapter);
            }
        }

        return shortlistStocks;
    }
}