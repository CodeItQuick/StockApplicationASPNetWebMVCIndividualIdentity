using MathNet.Numerics;
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

    [Fact]
    public void GivenDefaultSettingsCanPopulateAttributes()
    {
        var stock = new Stock("AAPL");
        
        stock.AddDefaultAttributes(
            new decimal(0.1),
            new decimal(0.2),
            new decimal(0.3),
            new decimal(0.4), 
            new decimal(0.5));
        
        Assert.Equal(stock.Attributes().Count, 5);
    }

    [Fact]
    public void StockCanCalculateSimpleIntrinsicValueForYearZeroFromPreviousFreeCashFlow()
    {
        var stock = new Stock("UNP");

        stock.IntrinsicValue(new List<long>()
        {
            100L, // year 0
            100L, // year 1
            100L // year 2, current year
        });
        
        // total stock value (year 0, for 3 year period)
        Assert.Equal(stock.StraightLineStockValueForYear(0), 300L); 
    }
    [Fact]
    public void StockCanCalculateSimpleIntrinsicValueForYearOneFromPreviousFreeCashFlowAndSimpleProjection()
    {
        var stock = new Stock("UNP");

        stock.IntrinsicValue(new List<long>()
        {
            100L, // year 0
            80L, // year 1
            120L // year 2, current year
        });
        
        // total stock value (year 0, for 3 year period)
        Assert.Equal(stock.StraightLineStockValueForYear(2), 320L); 
    }
    [Fact]
    public void StockCanCalculateRegressionIntrinsicValueForYearOneFromPreviousFreeCashFlowAndSimpleProjection()
    {
        var stock = new Stock("UNP");

        stock.IntrinsicValue(new List<long>()
        {
            111443000000, 
            92953000000, 
            73365000000,
            58896000000,
            64121000000,
            50803000000,
            52276000000,
            69778000000,
            49900000000,
            44590000000,
        });
        
        // total stock value (year 0, for 3 year period)
        Assert.Equal(
            1668237981819, 
            stock.RegressionStockValueForYear(20).Round(0)); 
    }
}