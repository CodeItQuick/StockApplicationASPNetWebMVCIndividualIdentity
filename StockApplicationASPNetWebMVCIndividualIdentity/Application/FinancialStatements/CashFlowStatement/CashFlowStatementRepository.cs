using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;

public class CashFlowStatementRepository : Repository<CashFlowStatementDto>, ICashFlowStatementRepository
{
    public CashFlowStatementRepository(StockContext context) : base(context)
    {
    }
}