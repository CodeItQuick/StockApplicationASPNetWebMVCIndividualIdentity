using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

public class RatiosTtmRepository : Repository<RatiosTtmDto>, IRatiosTtmRepository
{
    public RatiosTtmRepository(StockContext context) : base(context)
    {
    }
}