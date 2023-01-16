using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortlistService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public  ShortlistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void AddToShortlist(ShortlistDto shortListDto)
    {
        _unitOfWork.ShortListRepository.Add(shortListDto);
        _unitOfWork.SaveChanges();
    }

    public void DeleteFromShortlist(string ticker, string userId)
    {
        var stockEntity = _unitOfWork.ShortListRepository
            .Find(dto => dto.Ticker == ticker && dto.UserId == userId)
            .First();
        _unitOfWork.ShortListRepository.Remove(stockEntity);
        _unitOfWork.SaveChanges();
    }
}