using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;

namespace StockApplication.Core.Tests.Application;

public class StockIndexServiceTests: IClassFixture<StockIndexRepositoryFixtures>
{
    private readonly StockIndexRepositoryFixtures _fixture;

    public StockIndexServiceTests(StockIndexRepositoryFixtures fixtures)
    {
        _fixture = fixtures;
    }

    [Fact]
    public void GivenAnIndexCanHandleEmptyListOfStocks()
    {
        var service = new StockIndexService(new StockIndexRepository(_fixture.StockContextDb));
        
        // display the stocks from the service
        var allStocks = service.DisplayAllStocks(1);
        
        // check the return value + that we got all the repository calls
        Assert.Equal(0, allStocks?.Count);
    }
    [Fact]
    public void GivenAnIndexCanHandleListOfStocks()
    {
        var service = new StockIndexService(new StockIndexRepository(_fixture.StockContextDb));
        
        var allStocks = service.DisplayAllStocks(0).ToList();
        
        Assert.Equal(2, allStocks.Count);
        
    }
    [Fact]
    public void GivenAnIndexCanHandleCountingNumberOfStocks()
    {
        var service = new StockIndexService(new StockIndexRepository(_fixture.StockContextDb));
        
        var allStocks = service.DisplayAllStocksCount();
        
        Assert.Equal(1, allStocks);
        
    }
    [Fact]
    public void GivenALetterCanRetrieveCorrectPage()
    {
        var service = new StockIndexService(new StockIndexRepository(_fixture.StockContextDb));
        
        var allStocks = service.DisplayAllStocksToPage("a");
        
        Assert.Equal(0, allStocks.Page);
        
    }
}