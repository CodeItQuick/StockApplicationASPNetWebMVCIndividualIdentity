using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortlistService
{
    private readonly IShortListRepository? _shortListRepository;
    
    public ShortlistService()
    {
        
    }
    public ShortlistService(IShortListRepository? shortListRepository)
    {
        _shortListRepository = shortListRepository;
    }
    
    public void AddToShortlist(ShortlistDto shortListDto)
    {
        using var unitOfWork = new UnitOfWork();
        IShortListRepository shortListRepository = 
            _shortListRepository ?? unitOfWork.ShortListRepository;
        shortListRepository.Add(shortListDto);
        unitOfWork.SaveChanges();
    }
}