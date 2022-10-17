using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class IncomeStatementService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public IncomeStatementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void AddToIncomeStatements(List<IncomeStatementDto> incomeStatementDtos)
    {
        try
        {
            _unitOfWork.IncomeStatementRepository.AddRange(incomeStatementDtos);
            _unitOfWork.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}