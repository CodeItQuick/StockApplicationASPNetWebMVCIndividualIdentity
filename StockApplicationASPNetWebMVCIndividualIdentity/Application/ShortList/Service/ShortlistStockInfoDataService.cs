using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortlistStockInfoDataService
{
    private readonly IShortlistStockInfoDataViewRepository _shortlistStockInfoDataViewRepository;
    
    public ShortlistStockInfoDataService()
    {
        
    }
    public ShortlistStockInfoDataService(IShortlistStockInfoDataViewRepository shortlistStockInfoDataViewRepository)
    {
        _shortlistStockInfoDataViewRepository = shortlistStockInfoDataViewRepository;
    }
    
    public List<StocksAdapter> ShortlistedStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IShortlistStockInfoDataViewRepository shortListRepository = 
            _shortlistStockInfoDataViewRepository ?? unitOfWork.ShortlistStockInfoDataViewRepository;
        var stockInfo = shortListRepository.Get()
            .Skip(pageNumber * 20).Take(20).ToList();

        var stocksAdapters = ShortListAdapterConverter.Convert(stockInfo);

        return stocksAdapters;
    }
}