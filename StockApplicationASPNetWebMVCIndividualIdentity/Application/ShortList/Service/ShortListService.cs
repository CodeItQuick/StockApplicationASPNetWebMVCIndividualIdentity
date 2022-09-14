using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListService
{
    private readonly IShortListRepository? _shortListRepository;
    
    public ShortListService()
    {
        
    }
    public ShortListService(IShortListRepository shortListRepository)
    {
        _shortListRepository = shortListRepository;
    }
    
    public List<StocksAdapter> ShortlistedStocks(int pageNumber)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        var stockInfo = shortListRepository.Get()
            .Skip(pageNumber * 20).Take(20).ToList();

        var stocksAdapters = ShortListAdapterConverter.Convert(stockInfo);

        return stocksAdapters;
    }


    public void AddToShortlist(ShortListDTO shortListDto)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = _shortListRepository ?? unitOfWork.ShortListRepository;
        shortListRepository.Add(shortListDto);
        unitOfWork.SaveChanges();
    }
}