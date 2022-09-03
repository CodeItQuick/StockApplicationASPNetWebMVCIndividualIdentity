namespace StockApplicationASPNetWebMVCIndividualIdentity.Domain;

public class IndexStock
{
    private readonly string _indexSymbol;
    private List<Stock> _stocks;

    public IndexStock(string indexSymbol)
    {
        _indexSymbol = indexSymbol;
        _stocks = new List<Stock>();
    }

    public void Populate(IEnumerable<Stock> stocks)
    {
        _stocks = stocks.ToList();
    }
    
    

    public Stock? RetrieveBySymbol(string ticker)
    {
        return _stocks.Find(r => r.IsMatch(ticker));
    }

    public int Size()
    {
        return _stocks.Count;
    }

    public IEnumerable<Stock> RetrieveIndex(int pageNumber)
    {
        return _stocks.Skip(pageNumber * 20).Take(20).ToList();
    }
}