using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockIndexService : IStockIndexService
{
    private readonly StockIndexRepository _stockIndexRepository;

    public StockIndexService()
    {
        _stockIndexRepository = new StockIndexRepository(new StockContext());
    }

    public StockIndexService(StockIndexRepository stockIndexRepository)
    {
        _stockIndexRepository = stockIndexRepository;
    }

    public List<StocksAdapter> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        var stockInfo = _stockIndexRepository.RetrieveStockInfo(pageNumber);
        
        var cashFlow = new Dictionary<string, List<long>?>();
        var predictedMarketCap = new Dictionary<string, long>();
        foreach(var stock in stockInfo) {
            var currentStock = new Stock(stock.Ticker);
            var yearsCashFlow = stock.CashFlowStatements
                .Where(stock => stock.Symbol.Equals(stock.Symbol, StringComparison.InvariantCultureIgnoreCase))
                .Select(stock => Convert.ToInt64(stock.FreeCashFlow)).ToList();

            if (!yearsCashFlow.Any())
            {
                continue;
            }
            currentStock
                .IntrinsicValue(
                    yearsCashFlow);
            predictedMarketCap[stock.Ticker] = Convert.ToInt64(currentStock.RegressionStockValueForYear(20));

            cashFlow[stock.Ticker] = yearsCashFlow;
        }
        var stocksList = StocksAdapterConverter.ConvertFrom(stockInfo).ToList();
        
        stocksList.ForEach(stock =>
        {
            predictedMarketCap.TryGetValue(stock.Ticker, out var predictedValue);
            stock.stockAttribute?.Add("PredictedIntrinsicValue", Convert.ToDecimal(predictedValue));
            cashFlow.TryGetValue(stock.Ticker, out var stockCashFlow);
            Enumerable.Range(0, stockCashFlow?.Count ?? 0)
                .ToList()
                .ForEach(idx =>
                {
                    stock.stockAttribute?.Add($"Cashflow{idx}", stockCashFlow[idx]);
                    
                });
        });
        return stocksList.ToList();
    }

    public int DisplayAllStocksCount()
    {
        // Get Data
        var numPages = _stockIndexRepository.RetrieveCountStockInfo();
        return Int32.Parse(Math.Ceiling(Double.Parse(numPages.ToString()) / 20).ToString()); // FIXME: there's 19 per page for some reason
    }

    public PageItems DisplayAllStocksToPage(string letter)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();

        var stockInfo = _stockIndexRepository
            .RetrieveAll();
        var pageId = stockInfo
            .OrderBy(x => x.Ticker)
            .ToList()
            .FindIndex(x => x.Ticker != null && x.Ticker.StartsWith(letter));
        var pageNumber = Math.Floor((decimal)((pageId + 1) / 20));
        var foundPage = stockInfo
            .OrderBy(x => x.Ticker)
            .Skip((int)(pageNumber * 20)).Take(20);

        var stocksList = StocksAdapterConverter.ConvertFrom(foundPage);

        var pageItems = new PageItems()
        {
            StocksList = stocksList,
            Page = pageNumber
        };
        
        return pageItems;
    }
}

public interface IStockIndexService
{
    public List<StocksAdapter> DisplayAllStocks(int pageNumber);
    public int DisplayAllStocksCount();
    public PageItems DisplayAllStocksToPage(string letter);
}

public class PageItems
{
    public IEnumerable<StocksAdapter> StocksList { get; set; }
    public decimal Page { get; set; }
}