using Microsoft.EntityFrameworkCore;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;

public class StockIndexRepository
{
    private readonly IStockContext _stockContext;

    public StockIndexRepository(IStockContext stockContext)
    {
        _stockContext = stockContext;
    }
    
    public List<StockInfoDatumDTO> RetrieveStockInfo(int pageNumber)
    {
        var stockInfoDatumDtos = _stockContext
            .StockRepository
            .OrderBy(x => x.Ticker)
            .Skip(pageNumber * 20)
            .Take(20)
            .ToList();

        var cashFlowStatements = _stockContext
            .CashFlowStatement
            .Where(x => stockInfoDatumDtos.Select(y => y.Id).Contains(x.Id))
            .ToList();

        stockInfoDatumDtos.ForEach(stockInfo =>
        {
            stockInfo.CashFlowStatements = cashFlowStatements.FindAll(x => x.Symbol.Equals(stockInfo.Ticker));
        });
        
        return stockInfoDatumDtos;
    }

    public int RetrieveCountStockInfo()
    {
        return _stockContext
            .StockRepository
            .Count();
    }


    public List<StockInfoDatumDTO> RetrieveAll()
    {
        return _stockContext.StockRepository.ToList();
    }
}
