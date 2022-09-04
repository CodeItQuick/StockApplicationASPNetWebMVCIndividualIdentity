using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests;

public class ShortList
{
    private List<Stock> _stocks;

    public ShortList()
    {
        _stocks = new List<Stock>();
    }

    public void Add(Stock stock)
    {
        _stocks.Add(stock);
    }

    public int NumStocks()
    {
        return _stocks.Count;
    }

    public void Remove(Stock stock)
    {
        _stocks.Remove(stock);
    }

    public void Populate(IEnumerable<Stock> allShortlistedStocks)
    {
        _stocks = allShortlistedStocks.ToList();
    }

    public IEnumerable<Stock> RetrieveStocks(int pageNumber)
    {
        return _stocks.Skip(pageNumber).Take(20);
    }
}