using AutoFixture;
using EntityFrameworkCoreMock;
using StockApplicationASPNetWebMVCIndividualIdentity.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

internal class DatabaseMethods
{
    private List<StockInfoDatumDTO> _stockInfoDatumDtoTable;
    private List<ShortlistDto> _shortlistDto;
    private List<ShortlistStockInfoDataView> _shortlistStockInfoDataView;
    private List<KeyMetricsDto> _KeyMetricsDto;
    private List<IncomeStatementDto> _incomeStatementDto;
    private List<RatiosDto> _ratiosDtos;
    private List<CashFlowStatementDto> _cashFlowStatementDtos;
    private List<IndividualStockDto> _individualStockDto;
    private List<InvoicesDto> _invoicesDtos;
    private List<SubscriptionsDto> _subscriptionsDto;
    public DbContextMock<StockContext> TestDbContext { get; set; }
    public Fixture Fixture { get; set; }

    public DatabaseMethods()
    {
        Fixture = new Fixture();
        _stockInfoDatumDtoTable = BuildIdTableData(new List<StockInfoDatumDTO>());

        _shortlistDto = BuildIdTableData(new List<ShortlistDto>());
        _shortlistStockInfoDataView = BuildIdTableData(new List<ShortlistStockInfoDataView>());
        _incomeStatementDto = BuildIdTableData(new List<IncomeStatementDto>());
        // _KeyMetricsDto = BuildIdTableData(new List<KeyMetricsDto>());
        _ratiosDtos = BuildIdTableData(new List<RatiosDto>());
        _cashFlowStatementDtos = BuildIdTableData(new List<CashFlowStatementDto>());
        _individualStockDto = BuildIdTableData(new List<IndividualStockDto>());
        _invoicesDtos = BuildIdTableData(new List<InvoicesDto>());
        _subscriptionsDto = BuildIdTableData(new List<SubscriptionsDto>());
        
        TestDbContext = new DbContextMock<StockContext>();
        TestDbContext
            .CreateDbSetMock(x => x.Set<StockInfoDatumDTO>(), _stockInfoDatumDtoTable);
        TestDbContext
            .CreateDbSetMock(x => x.Set<ShortlistDto>(), _shortlistDto);
        TestDbContext
            .CreateDbSetMock(x => x.Set<ShortlistStockInfoDataView>(), _shortlistStockInfoDataView);
        TestDbContext
            .CreateDbSetMock(x => x.Set<KeyMetricsDto>(), _KeyMetricsDto);
        TestDbContext
            .CreateDbSetMock(x => x.Set<IncomeStatementDto>(), _incomeStatementDto);
        TestDbContext
            .CreateDbSetMock(x => x.Set<RatiosDto>(), _ratiosDtos);
        TestDbContext
            .CreateDbSetMock(x => x.Set<CashFlowStatementDto>(), _cashFlowStatementDtos);
        TestDbContext
            .CreateDbSetMock(x => x.Set<IndividualStockDto>(), _individualStockDto);
        TestDbContext
            .CreateDbSetMock(x => x.Set<InvoicesDto>(), _invoicesDtos);
        TestDbContext
            .CreateDbSetMock(x => x.Set<SubscriptionsDto>(), _subscriptionsDto);
        
    }

    private List<TEntity> BuildIdTableData<TEntity>(List<TEntity> list) where TEntity : DatabaseTable 
    {
        TEntity TableData(long id) =>
            Fixture.Build<TEntity>()
                .WithAutoProperties()
                .With(x => x.Id, id)
                .With(x => x.Ticker, "ABC")
                .With(x => x.Symbol, "ABC")
                .With(x => x.UserId, "test_user_1")
                .Create();

        list.AddRange(new[] { TableData(1L), TableData(2L), TableData(3L) });
        return list;
    }

    public UnitOfWork CreateTestUnitOfWork()
    {
        return new UnitOfWork(TestDbContext.Object);
    }
}