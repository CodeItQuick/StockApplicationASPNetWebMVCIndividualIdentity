using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class ShortListStockService
{
    private readonly ShortListRepository _shortListRepository;

    public ShortListStockService(IStockContext stockContext)
    {
        _shortListRepository = new ShortListRepository(stockContext as StockContext);
    }

    public List<StocksAdapter> ShortlistedStocks(int pageNumber, string username)
    {
        var stockList = _shortListRepository.RetrieveShortlist(pageNumber, username);

        var stocksAdapters = ShortListAdapterConverter.Of(stockList);
        
        return stocksAdapters;
    }
    
    
    public void AddToShortlist(ShortlistDto shortListDto)
    {
        _shortListRepository.AddToShortlist(shortListDto);
    }

    public void DeleteFromShortlist(string ticker, string currentUser)
    {
        _shortListRepository.DeleteFromShortlist(ticker, currentUser);
    }
    public void AddToIncomeStatements(List<IncomeStatementDto> incomeStatementDtos)
    {
        _shortListRepository.AddToIncomeStatements(incomeStatementDtos);
    }
    public void AddToKeyMetrics(List<KeyMetricsDto> keyMetricsDtos)
    {
        _shortListRepository.AddToKeyMetrics(keyMetricsDtos);
    }
    public void AddToRatiosTtm(List<RatiosDto> ratios)
    {
        _shortListRepository.AddToRatiosTtm(ratios);
    }
    public void AddToCashFlowStatement(List<CashFlowStatementDto> cashFlowStatements)
    {
        _shortListRepository.AddToCashFlowStatements(cashFlowStatements);
    }

    public IEnumerable<IndividualStockDto>? RetrieveIndividualStock(string ticker)
    {
        return _shortListRepository.RetrieveIndividualStock(ticker);
    }

    public IEnumerable<CashFlowStatementDto> RetrieveCashFlowStatements(string ticker)
    {
        return _shortListRepository.RetrieveCashFlowStatements(ticker);
    }
}