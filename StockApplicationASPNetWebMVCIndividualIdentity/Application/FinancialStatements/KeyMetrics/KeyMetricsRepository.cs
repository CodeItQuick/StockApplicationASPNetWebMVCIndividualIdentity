using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;

public class KeyMetricsRepository : Repository<KeyMetricsDto>, IKeyMetricsRepository
{
    public KeyMetricsRepository(StockContext context) : base(context)
    {
    }
}