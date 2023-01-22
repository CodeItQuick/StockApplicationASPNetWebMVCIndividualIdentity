using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;

public class CashFlowStatementRepository : ICashFlowStatementRepository
{
    private readonly StockContext _context;

    public CashFlowStatementRepository(StockContext context)
    {
        _context = context;
    }

    public void AddRange(List<CashFlowStatementDto> cashFlowStatement)
    {
        _context.CashFlowStatement?.AddRange(cashFlowStatement);
        _context.SaveChanges();
    }

    public IEnumerable<CashFlowStatementDto>? GetAll()
    {
        return _context.CashFlowStatement?.Where(x => true);
    }
}