using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class IndividualStockService
{
    private readonly IIndividualStockRepository _individualStockRepository;
    
    public IndividualStockService(IIndividualStockRepository individualStockRepository)
    {
        _individualStockRepository = individualStockRepository;
    }
    
    public IEnumerable<IndividualStockDto> RetrieveIndividualStocks(string individualStockDto)
    {
        try
        {
            var individualStockDtos = _individualStockRepository
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