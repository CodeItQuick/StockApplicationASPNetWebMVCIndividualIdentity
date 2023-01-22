using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;

public class IndividualStockRepository : IIndividualStockRepository
{
    private readonly StockContext _context;


    public IndividualStockRepository(StockContext context)
    {
        _context = context;
    }

    public List<IndividualStockDto> GetAll()
    {
        return _context.IndividualStocks.Select(x => x).ToList();
    }
}