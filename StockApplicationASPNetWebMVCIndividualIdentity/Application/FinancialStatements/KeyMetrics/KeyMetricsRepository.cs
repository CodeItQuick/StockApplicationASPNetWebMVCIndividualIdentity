using Microsoft.EntityFrameworkCore;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;

public class KeyMetricsRepository : IKeyMetricsRepository
{
    private readonly StockContext context;

    public KeyMetricsRepository(StockContext context)
    {
        this.context = context;
    }

    public void AddRange(List<KeyMetricsDto> keyMetricsDtos)
    { 
        context.KeyMetrics.AddRange(keyMetricsDtos);
        context.SaveChanges();

    }
}