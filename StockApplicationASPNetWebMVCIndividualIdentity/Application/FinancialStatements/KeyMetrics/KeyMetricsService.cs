using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class KeyMetricsService
{
    private readonly IUnitOfWork _unitOfWork;

    public KeyMetricsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddToKeyMetrics(List<KeyMetricsDto> keyMetricsDtos)
    {   
        try
        {
            _unitOfWork.KeyMetricsRepository.AddRange(keyMetricsDtos);
            _unitOfWork.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}