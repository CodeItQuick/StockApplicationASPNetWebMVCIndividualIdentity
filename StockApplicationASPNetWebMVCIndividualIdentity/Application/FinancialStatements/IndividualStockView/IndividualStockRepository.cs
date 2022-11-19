using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;

public class IndividualStockRepository : Repository<IndividualStockDto>, IIndividualStockRepository
{
    public IndividualStockRepository(StockContext context) : base(context)
    {
    }
}