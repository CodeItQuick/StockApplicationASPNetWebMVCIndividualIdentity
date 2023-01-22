using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;

public interface ICashFlowStatementRepository
{
    void AddRange(List<CashFlowStatementDto> cashFlowStatement);
    IEnumerable<CashFlowStatementDto>? GetAll();
}