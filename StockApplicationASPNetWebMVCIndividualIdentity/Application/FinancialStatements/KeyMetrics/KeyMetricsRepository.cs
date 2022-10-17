using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class KeyMetricsRepository : Repository<KeyMetricsDto>, IKeyMetricsRepository
{
    public KeyMetricsRepository(StockContext context) : base(context)
    {
    }
}