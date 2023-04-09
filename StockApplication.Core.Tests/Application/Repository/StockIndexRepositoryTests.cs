using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;

namespace StockApplication.Core.Tests.Application;

public class StockIndexRepositoryTests: IClassFixture<StockIndexRepositoryFixtures>
{
    private readonly StockIndexRepositoryFixtures _fixture;

    public StockIndexRepositoryTests(StockIndexRepositoryFixtures fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void RetrieveStockInfoReturnsValidData()
    {
        
        var stockIndexRepository = new StockIndexRepository(_fixture.StockContextDb);

        var stockInfo = stockIndexRepository.RetrieveStockInfo(0);
        
        Assert.Equal(2, stockInfo.Count());
        Assert.Equal(2, stockInfo.First().CashFlowStatements.Count());
    } 
    [Fact]
    public void RetrieveCountStockInfoReturnsValidCountOfItems()
    {
        
        var stockIndexRepository = new StockIndexRepository(_fixture.StockContextDb);

        var stockInfo = stockIndexRepository.RetrieveCountStockInfo();
        
        Assert.Equal(2, stockInfo);
    } 
}