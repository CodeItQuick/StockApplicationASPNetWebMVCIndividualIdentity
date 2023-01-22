using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

public class CashFlowStatementService
{
    private readonly ICashFlowStatementRepository _cashFlowStatementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CashFlowStatementService(ICashFlowStatementRepository cashFlowStatementRepository)
    {
        _cashFlowStatementRepository = cashFlowStatementRepository;
    }

    public void AddToCashFlowStatement(List<CashFlowStatementDto> cashFlowStatement)
    {   
        try
        {
            _cashFlowStatementRepository.AddRange(cashFlowStatement);
            
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public IEnumerable<CashFlowStatementDto> RetrieveIndividualStocks(string ticker)
    {
        return _cashFlowStatementRepository.GetAll()?.Where(x => x.Symbol.Equals(ticker));
    }
}