using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class ShortListRepository : Repository<ShortlistDto>, IShortListRepository
{
    private readonly StockContext _stockContext;

    public ShortListRepository(StockContext context)
    {
        _stockContext = context;
    }


    public List<Stock> RetrieveShortlist(int pageNumber, string username)
    {
        var stockTickers = _stockContext.Shortlists
            ?.Where(x => x.UserId.Equals(username))
            .Skip(pageNumber * 20).Take(20).Select(x => x.Ticker).Distinct().ToList();
        var allStocks = _stockContext.StockRepository
            .ToList();
        var cashFlowStatements = _stockContext.CashFlowStatement
            ?.ToList();
        var cashFlowDictionary = stockTickers
            .ToDictionary(
                stock => stock, 
                stock => cashFlowStatements
                    ?.Where(x => x.Symbol.Equals(stock))
                    .Select(x => Convert.ToInt64(x.FreeCashFlow)));

        // Where does the below go? Is this the translation from DB->Domain that belongs in an application adapter?
        var stockList = new List<Stock>();
        foreach(var stockTicker in stockTickers) {
            var cashFlowDto = cashFlowDictionary.Single(stock => stock.Key.Equals(stockTicker));
            var stockData = allStocks.Single(stock => stock.Ticker.Equals(stockTicker));
            List<StockAttributeDecimal> stockAttributes = new List<StockAttributeDecimal>()
            {
                // the stockAttributes - seems like there's little/no value to transforming these to the domain?
                new("PbRatio", stockData.PbRatio),
                new("PeRatio", stockData.PeRatio),
                new("Eps", stockData.Eps),
                new("DivYield", stockData.DivYield),
                new("MarketCap", stockData.MarketCap),
                new("Id", stockData.Id)
            };
            var currentStock = new Stock(stockTicker, stockAttributes);
            
            currentStock.IntrinsicValue(cashFlowDto.Value.ToList()); // this is worthwhile to calculate the intrinsic value
            stockList.Add(currentStock);
        }

        return stockList;
    }

    public int AddToShortlist(ShortlistDto shortlistDto)
    {
        _stockContext.Shortlists?.Add(shortlistDto);
        return _stockContext.SaveChanges();
    }
    
    
    public void DeleteFromShortlist(string ticker, string userId)
    {
        var stockEntity = _stockContext.Shortlists?
            .SingleOrDefault(dto => dto.Ticker == ticker && dto.UserId == userId);
        _stockContext.Shortlists?.Remove(stockEntity);
        _stockContext.SaveChanges();
    }

    public void AddToIncomeStatements(List<IncomeStatementDto> incomeStatementDtos)
    {
        _stockContext.IncomeStatements?.AddRange(incomeStatementDtos);
        _stockContext.SaveChanges();
    }

    public void AddToKeyMetrics(List<KeyMetricsDto> keyMetricsDtos)
    {
        _stockContext.KeyMetrics?.AddRange(keyMetricsDtos);
        _stockContext.SaveChanges();
    }
    public void AddToRatiosTtm(List<RatiosDto> ratiosDtos)
    {
        _stockContext.Ratios?.AddRange(ratiosDtos);
        _stockContext.SaveChanges();
    }

    public void AddToCashFlowStatements(List<CashFlowStatementDto> cashFlowStatements)
    {
        _stockContext.CashFlowStatement?.AddRange(cashFlowStatements);
        _stockContext.SaveChanges();
    }

    public IEnumerable<IndividualStockDto>? RetrieveIndividualStock(string ticker)
    {
        return _stockContext.IndividualStocks?
            .Where(x => x.Symbol.Equals(ticker));
    }

    public IEnumerable<CashFlowStatementDto> RetrieveCashFlowStatements(string ticker)
    {
        return _stockContext.CashFlowStatement?
            .Where(x => x.Symbol.Equals(ticker));
    }
}