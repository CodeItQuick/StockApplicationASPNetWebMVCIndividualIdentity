using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class IndividualStockService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public IndividualStockService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IEnumerable<IndividualStockDto> RetrieveIndividualStocks(string individualStockDto)
    {
        try
        {
            var individualStockDtos = _unitOfWork.IndividualStockRepository
                .GetAll()
                .Where(x => x.Symbol.Equals(individualStockDto));
            return individualStockDtos;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}