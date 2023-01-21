using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;

public class KeyMetricsService : IKeyMetricsService
{
    private readonly IKeyMetricsRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public KeyMetricsService(IKeyMetricsRepository repository)
    {
        _repository = repository;
    }

    public void AddToKeyMetrics(List<KeyMetricsDto> keyMetricsDtos)
    {   
        try
        {
            _repository.AddRange(keyMetricsDtos);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

public interface IKeyMetricsService
{
    void AddToKeyMetrics(List<KeyMetricsDto> keyMetricsDtos);
}