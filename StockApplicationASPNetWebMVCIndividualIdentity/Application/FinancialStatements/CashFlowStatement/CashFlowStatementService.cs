using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

public class CashFlowStatementService
{
    private readonly IUnitOfWork _unitOfWork;

    public CashFlowStatementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddToCashFlowStatement(List<CashFlowStatementDto> cashFlowStatement)
    {   
        try
        {
            _unitOfWork.CashFlowStatementRepository.AddRange(cashFlowStatement);
            _unitOfWork.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}