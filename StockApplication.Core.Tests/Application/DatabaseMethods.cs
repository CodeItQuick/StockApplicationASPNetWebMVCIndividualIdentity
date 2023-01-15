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
    private DbContextMock<StockContext> TestDbContext { get; set; }

    public DatabaseMethods()
    {
        var fixture = new Fixture();
        _stockInfoDatumDtoTable = fixture.Create<IEnumerable<StockInfoDatumDTO>>();
        _shortlistDto = fixture.Create<IEnumerable<ShortlistDto>>();
        _shortlistStockInfoDataView = fixture.Create<IEnumerable<ShortlistStockInfoDataView>>();
        _incomeStatementDto = fixture.Create<IEnumerable<IncomeStatementDto>>();
        _KeyMetricsDto = fixture.Create<IEnumerable<KeyMetricsDto>>();
        _ratiosDtos = fixture.Create<IEnumerable<RatiosDto>>();
        _cashFlowStatementDtos = fixture.Create<IEnumerable<CashFlowStatementDto>>();
        _individualStockDto = fixture.Create<IEnumerable<IndividualStockDto>>();
        _invoicesDtos = fixture.Create<IEnumerable<InvoicesDto>>();
        _subscriptionsDto = fixture.Create<IEnumerable<SubscriptionsDto>>();
        
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