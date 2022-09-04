using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Domain;

public class AcceptanceTests
{
    
    [Fact]
    public void GivenAnEmptyShortlistCanDisplayList()
    {
        var stock = new Stock("AAPL");
        var stockList = new List<Stock>
        {
            stock
        };
        var shortlistedStocks = new ShortList();

        shortlistedStocks.Populate(stockList);
            
        Assert.Single(shortlistedStocks.RetrieveStocks(0));
    }
    [Fact]
    public void GivenAStockWeCanAddItToTheShortlistedStocks()
    {
        var stock = new Stock("AAPL");
        var shortlistedStocks = new ShortList();

        shortlistedStocks.Add(stock);
            
        Assert.True(shortlistedStocks.NumStocks() == 1);
    }
    [Fact]
    public void GivenAShortListedSetOfStocksCanRemoveAStock()   
    {
        var stock = new Stock("AAPL");
        var shortlistedStocks = new ShortList();
        shortlistedStocks.Add(stock);

        shortlistedStocks.Remove(stock);
            
        Assert.True(shortlistedStocks.NumStocks() == 0);
    }
    [Fact]
    public void GivenAnIndexCanPopulateWithStocks()
    {
        var index = new IndexStock("W5000");
        var stocks = new List<Stock> { new("AAPL"), new("MSFT") };

        index.Populate(stocks);
        
        Assert.Equal(2, index.Size());
    }
    [Fact]
    public void GivenAnIndexCanRetrieveAStock()
    {
        var index = new IndexStock("W5000");
        var stocks = new List<Stock> { new("AAPL"), new("MSFT") };
        index.Populate(stocks);
        
        Stock? stock = index.RetrieveBySymbol("AAPL");
        
        Assert.Equal("AAPL", stock.Ticker());
    }
    [Fact]
    public void GivenAnIndexCanDefineAStockWithShortlistedAttribute()
    {
        var index = new IndexStock("W5000");
        var stockWithAttributes = new Stock("AAPL", new List<StockAttributeDecimal>()
        {
            new("roe", new decimal(0.25))
        });
        var stocks = new List<Stock> { stockWithAttributes, new("MSFT") };
        index.Populate(stocks);
        
        Stock? stockAapl = index.RetrieveBySymbol("AAPL");
        Stock? stockMsft = index.RetrieveBySymbol("MSFT");
        
        Assert.Equal("AAPL", stockAapl.Ticker());
        Assert.Equal("MSFT", stockMsft.Ticker());
    }
    [Fact]
    public void GivenAnIndexCanListAllTheStocks()
    {
        var index = new IndexStock("W5000");
        var stockWithAttributes = new Stock("AAPL", new List<StockAttributeDecimal>()
        {
            new("roe", new decimal(0.25))
        });
        var stocks = new List<Stock> { stockWithAttributes, new("MSFT") };
        index.Populate(stocks);

        IEnumerable<Stock> stockList = index.RetrieveIndex(0);

        Assert.Equal(2, stockList.Count());
    }
}