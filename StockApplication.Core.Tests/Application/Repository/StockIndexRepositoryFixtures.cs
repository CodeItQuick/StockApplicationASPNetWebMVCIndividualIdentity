using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class StockIndexRepositoryFixtures : IDisposable  
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

    public readonly StockContext StockContextDb;

    public StockIndexRepositoryFixtures()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
 
        var options = new DbContextOptionsBuilder<StockContext>().UseSqlite(connection).Options;

        StockContextDb = new StockContext(options);
        StockContextDb.Database.EnsureCreated();
        
        StockContextDb.StockRepository.AddRange(_stockInfoDatumDtos);
        StockContextDb.CashFlowStatement?.AddRange(_cashFlowStatementDtos);
        StockContextDb.SaveChanges();
    }

    public void Dispose()
    {
        StockContextDb.Dispose();
    }
}