using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortlistStockInfoDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ShortlistStockInfoDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public List<StocksAdapter> ShortlistedStocks(int pageNumber)
    {
        var stockInfo = _unitOfWork
            .ShortlistStockInfoDataViewRepository
            .Get(null, null, "")
            .Skip(pageNumber * 20).Take(20).ToList();
        var allStocks = _unitOfWork
            .StockRepository
            .Get(null, null, "")
            .ToList();

        var stocksAdapters = ShortListAdapterConverter.Convert(stockInfo, allStocks);

        return stocksAdapters;
    }
}