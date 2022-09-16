using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortlistService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ShortlistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void AddToShortlist(ShortlistDto shortListDto)
    {
        IShortListRepository shortListRepository = _unitOfWork.ShortListRepository;
        shortListRepository.Add(shortListDto);
        _unitOfWork.SaveChanges();
    }
}