using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Stocks.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class ShortlistRepositoryTests: IClassFixture<ShortListRepositoryFixtures>
{
    private readonly ShortListRepositoryFixtures _fixture;

    public ShortlistRepositoryTests(ShortListRepositoryFixtures fixture)
    {
        fixture.SeedDatabase();
        _fixture = fixture;
    }

    [Fact]
    public void ServiceRetrieveShortlistReturnsItem()
    {
        var shortListStockService = new ShortListStockService(_fixture.StockContextDb);

        var stockInfo = shortListStockService.ShortlistedStocks(0, "test_username");
        
        Assert.Equal(1, stockInfo.Count());
    }

    [Fact]
    public void ServiceAddShortlistAddsItem()
    {
        
        var shortListStockService = new ShortListStockService(_fixture.StockContextDb);

        ShortlistDto shortlistDto = new ShortlistDto() { Ticker = "ABC", UserId = "test_username", StockInfoDataId = 1};
        shortListStockService.AddToShortlist(shortlistDto);
        
        Assert.Equal(2, _fixture.StockContextDb.Shortlists?.Count());
    }

    [Fact]
    public void RetrieveShortlistReturnsItem()
    {
        var stockIndexRepository = new ShortListRepository(_fixture.StockContextDb);

        var stockInfo = stockIndexRepository.RetrieveShortlist(0, "test_username");
        
        Assert.Equal(1, stockInfo.Count());
    }

    [Fact]
    public void AddShortlistAddsItem()
    {
        
        var stockIndexRepository = new ShortListRepository(_fixture.StockContextDb);

        ShortlistDto shortlistDto = new ShortlistDto() { Ticker = "ABC", UserId = "test_username", StockInfoDataId = 1};
        var stockInfo = stockIndexRepository.AddToShortlist(shortlistDto);
        
        Assert.Equal(1, stockInfo);
        Assert.Equal(2, _fixture.StockContextDb.Shortlists?.Count());
    }
}

public class ShortListRepositoryFixtures 
{
    readonly List<StockInfoDatumDTO> _stockInfoDatumDtos = new()
    {
        new() { Ticker = "ABC" },
        new() { Ticker = "BCD" },
    };

    readonly List<CashFlowStatementDto> _cashFlowStatementDtos = new()
    {
        new() { Symbol = "ABC", Date = DateTimeOffset.Now, ReportedCurrency = "USD", Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023", Period = "1", Link = "123", FinalLink = "123" },
        new() { Symbol = "ABC", Date = DateTimeOffset.Now, ReportedCurrency = "USD", Cik = "1234", FillingDate = DateTimeOffset.Now, AcceptedDate = DateTimeOffset.Now, CalendarYear = "2023", Period = "1", Link = "123", FinalLink = "123" },
    };

    readonly List<ShortlistDto> _shortlistDtos = new()
    {
        new ShortlistDto() { Ticker = "ABC", UserId = "test_username", StockInfoDataId = 1 } 
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

        StockContextDb.Shortlists?.AddRange(_shortlistDtos);
        StockContextDb.StockRepository.AddRange(_stockInfoDatumDtos);
        StockContextDb.CashFlowStatement?.AddRange(_cashFlowStatementDtos);
        StockContextDb.SaveChanges();
    }
}