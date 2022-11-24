using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockIndexService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockIndexService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<StocksAdapter> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        var stockInfo = _unitOfWork.StockRepository
            .Get(null, null)
            .OrderBy(x => x.Ticker)
            .Skip(pageNumber * 20).Take(20);

        var stocksList = StocksAdapterConverter.ConvertFrom(stockInfo);

        return stocksList.ToList();
    }

    public int DisplayAllStocksCount()
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        var numPages = _unitOfWork.StockRepository
            .Get(null, null)
            .Count();
        return numPages / 19; // FIXME: there's 19 per page for some reason
    }

    public PageItems DisplayAllStocksToPage(string letter)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();

        var stockInfo = _unitOfWork.StockRepository
            .Get(null, null);
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

public class PageItems
{
    public IEnumerable<StocksAdapter> StocksList { get; set; }
    public decimal Page { get; set; }
}