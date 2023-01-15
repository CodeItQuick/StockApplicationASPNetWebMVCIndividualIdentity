using AutoFixture;
using EntityFrameworkCoreMock;
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
    private IEnumerable<StockInfoDatumDTO> _stockInfoDatumDtoTable;
    private IEnumerable<ShortlistDto> _shortlistDto;
    private IEnumerable<ShortlistStockInfoDataView> _shortlistStockInfoDataView;
    private IEnumerable<KeyMetricsDto> _KeyMetricsDto;
    private IEnumerable<IncomeStatementDto> _incomeStatementDto;
    private IEnumerable<RatiosDto> _ratiosDtos;
    private IEnumerable<CashFlowStatementDto> _cashFlowStatementDtos;
    private IEnumerable<IndividualStockDto> _individualStockDto;
    private IEnumerable<InvoicesDto> _invoicesDtos;
    private IEnumerable<SubscriptionsDto> _subscriptionsDto;
    public DbContextMock<StockContext> TestDbContext { get; set; }
    public Fixture Fixture { get; set; }

    public DatabaseMethods()
    {
        Fixture = new Fixture();
        _stockInfoDatumDtoTable = Fixture.Create<IEnumerable<StockInfoDatumDTO>>();
        _shortlistDto = Fixture.Create<IEnumerable<ShortlistDto>>();
        _shortlistStockInfoDataView = Fixture.Create<IEnumerable<ShortlistStockInfoDataView>>();
        _incomeStatementDto = Fixture.Create<IEnumerable<IncomeStatementDto>>();
        _KeyMetricsDto = Fixture.Create<IEnumerable<KeyMetricsDto>>();
        _ratiosDtos = Fixture.Create<IEnumerable<RatiosDto>>();
        _cashFlowStatementDtos = Fixture.Create<IEnumerable<CashFlowStatementDto>>();
        _individualStockDto = Fixture.Create<IEnumerable<IndividualStockDto>>();
        _invoicesDtos = Fixture.Create<IEnumerable<InvoicesDto>>();
        _subscriptionsDto = Fixture.Create<IEnumerable<SubscriptionsDto>>();
        
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

    public UnitOfWork CreateTestUnitOfWork()
    {
        return new UnitOfWork(TestDbContext.Object);
    }
}