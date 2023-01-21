using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;

public interface IKeyMetricsRepository
{
    void AddRange(List<KeyMetricsDto> keyMetricsDtos);
}