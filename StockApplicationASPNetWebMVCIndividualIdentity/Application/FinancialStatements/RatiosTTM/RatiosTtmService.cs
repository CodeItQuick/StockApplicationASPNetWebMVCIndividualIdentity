using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

public class RatiosTtmService
{
    private readonly IUnitOfWork _unitOfWork;

    public RatiosTtmService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddToRatiosTtm(List<RatiosTtmDto> ratiosTtm)
    {   
        try
        {
            _unitOfWork.RatiosTtmRepository.AddRange(ratiosTtm);
            _unitOfWork.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}