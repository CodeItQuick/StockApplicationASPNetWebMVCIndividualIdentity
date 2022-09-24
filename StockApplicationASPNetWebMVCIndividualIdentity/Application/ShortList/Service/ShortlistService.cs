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
        _unitOfWork.ShortListRepository.Add(shortListDto);
        _unitOfWork.SaveChanges();
    }

    public void DeleteFromShortlist(long stockId)
    {
        var stockEntity = _unitOfWork.ShortListRepository.Get(stockId);
        _unitOfWork.ShortListRepository.Remove(stockEntity);
        _unitOfWork.SaveChanges();
    }
}