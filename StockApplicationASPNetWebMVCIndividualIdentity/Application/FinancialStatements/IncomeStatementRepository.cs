using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;

public class IncomeStatementRepository : Repository<IncomeStatementDto>, IIncomeStatementRepository
{
    public IncomeStatementRepository(StockContext context) : base(context)
    {
    }
}