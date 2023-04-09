using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class IndividualStockRepositoryTests: IClassFixture<IndividualStockRepositoryFixtures>
{
    private readonly IndividualStockRepositoryFixtures _fixture;

    public IndividualStockRepositoryTests(IndividualStockRepositoryFixtures fixture)
    {
        fixture.SeedDatabase();
        _fixture = fixture;
    }

    [Fact]
    public void ServiceCanRetrieveIndividualStocks()
    {
        var shortListStockService = new ShortListStockService(_fixture.StockContextDb);

        var stockInfo = shortListStockService.RetrieveIndividualStock("ABC");
        
        Assert.Equal(1, stockInfo.Count());
    }
    [Fact]
    public void SymbolRetrievalExists()
    {
        var shortListStockService = new ShortListRepository(_fixture.StockContextDb);

        var stockInfo = shortListStockService.RetrieveIndividualStock("ABC");
        
        Assert.Equal(1, stockInfo.Count());
    }

}

public class IndividualStockRepositoryFixtures 
{
    readonly List<IndividualStockDto> individualStockDtos = new()
    {
        new() { Symbol = "ABC" },
        new() { Symbol = "BCD" },
    };

    public StockContext? StockContextDb;
    private SqliteConnection _connection;

    public void SeedDatabase()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<StockContext>().UseSqlite(_connection).Options;

        StockContextDb = new StockContext(options);
        StockContextDb.Database.EnsureCreated();

        StockContextDb.IndividualStocks.AddRange(individualStockDtos);
        StockContextDb.SaveChanges();
    }
}