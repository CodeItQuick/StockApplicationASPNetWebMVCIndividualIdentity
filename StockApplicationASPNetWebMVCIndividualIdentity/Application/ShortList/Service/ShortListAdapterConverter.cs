using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListAdapterConverter
{
    
    public static List<StocksAdapter> Convert(
        List<ShortlistStockInfoDataView> stockInfo, 
        List<StockInfoDatumDTO> stockInfoDatumDtos)
    {
        List<StocksAdapter> shortlistStocks = new List<StocksAdapter>();
        foreach (var shortListDto in stockInfo)
        {
            if (shortListDto.Ticker == null)
            {
                continue;
            };
            if (stockInfoDatumDtos.Count(r => 
                    r.Ticker != null && r.Ticker.Equals(shortListDto.Ticker)) != 1)
            {
                StocksAdapter justTickerStocksAdapter = new()
                {
                    Ticker = shortListDto.Ticker ?? "",
                    Id = shortListDto.Id
                };
                shortlistStocks.Add(justTickerStocksAdapter);
                continue;
            };
            StocksAdapter stockAdapter = new()
            {
                stockAttribute = new(),
                Ticker = shortListDto.Ticker ?? "",
                Id = shortListDto.Id
            };
            stockAdapter.stockAttribute["PbRatio"] = stockInfoDatumDtos.Single(r => 
                    r.Ticker != null && r.Ticker.Equals(shortListDto.Ticker))
                .PbRatio ?? 0.0m;
            stockAdapter.stockAttribute["PeRatio"] = stockInfoDatumDtos.Single(r => 
                    r.Ticker != null && r.Ticker.Equals(shortListDto.Ticker))
                .PeRatio ?? 0.0m;
            stockAdapter.stockAttribute["Eps"] = stockInfoDatumDtos.Single(r => 
                    r.Ticker != null && r.Ticker.Equals(shortListDto.Ticker))
                .Eps ?? 0.0m;
            stockAdapter.stockAttribute["DivYield"] = stockInfoDatumDtos.Single(r => 
                    r.Ticker != null && r.Ticker.Equals(shortListDto.Ticker))
                .DivYield ?? 0.0m;
            shortlistStocks.Add(stockAdapter);
        }

        return shortlistStocks;
    }
}