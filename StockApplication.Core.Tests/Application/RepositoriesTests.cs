using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
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

public class RepositoryTests
{
    private UnitOfWork _unitOfWork;
    private readonly IShortListRepository _shortListRepository;
    private readonly IStockDataRepository _stockRepository;
    private readonly IInvoicesRepository _invoicesRepository;
    private readonly ISubscriptionsRepository _subscriptionsRepository;
    private readonly ICashFlowStatementRepository _cashFlowStatementRepository;
    private readonly IIncomeStatementRepository _incomeStatementRepository;
    private readonly IIndividualStockRepository _individualStockRepository;
    private readonly IKeyMetricsRepository _keyMetricsRepository;
    private readonly IRatiosTtmRepository _ratiosTtmRepository;
    private readonly GenericRepositoryTests<IShortListRepository, ShortlistDto> _genericShortlistRepositoryTests;
    private readonly GenericRepositoryTests<IStockDataRepository, StockInfoDatumDTO> _genericStockDataRepositoryTests;
    private readonly GenericRepositoryTests<IInvoicesRepository, InvoicesDto> _genericInvoicesRepositoryTests;
    private readonly GenericRepositoryTests<ISubscriptionsRepository, SubscriptionsDto> _genericSubscriptionsRepositoryTests;
    private readonly GenericRepositoryTests<ICashFlowStatementRepository, CashFlowStatementDto> _genericCashFlowStatementRepositoryTests;
    private readonly GenericRepositoryTests<IIncomeStatementRepository, IncomeStatementDto> _genericIncomeStatementRepositoryTests;
    private readonly GenericRepositoryTests<IIndividualStockRepository, IndividualStockDto> _genericIndividualStockRepositoryTests;
    private readonly GenericRepositoryTests<IKeyMetricsRepository, KeyMetricsDto> _genericKeyMetricsRepositoryTests;
    private readonly GenericRepositoryTests<IRatiosTtmRepository, RatiosDto> _genericRatiosTtmRepositoryTests;

    public RepositoryTests()
    {
        var databaseMethods = new DatabaseMethods();
        _unitOfWork = databaseMethods.CreateTestUnitOfWork();
        
        _shortListRepository = _unitOfWork.ShortListRepository;
        _stockRepository = _unitOfWork.StockRepository;
        _invoicesRepository = _unitOfWork.InvoicesRepository;
        _subscriptionsRepository = _unitOfWork.SubscriptionsRepository;
        _cashFlowStatementRepository = _unitOfWork.CashFlowStatementRepository;
        _incomeStatementRepository = _unitOfWork.IncomeStatementRepository;
        _individualStockRepository = _unitOfWork.IndividualStockRepository;
        _keyMetricsRepository = _unitOfWork.KeyMetricsRepository;
        _ratiosTtmRepository = _unitOfWork.RatiosTtmRepository;
        
        _genericShortlistRepositoryTests = new GenericRepositoryTests<IShortListRepository, ShortlistDto>(
            _shortListRepository, _unitOfWork);
        _genericStockDataRepositoryTests = new GenericRepositoryTests<IStockDataRepository, StockInfoDatumDTO >(
            _stockRepository, _unitOfWork);
        _genericInvoicesRepositoryTests = new GenericRepositoryTests<IInvoicesRepository, InvoicesDto >(
            _invoicesRepository, _unitOfWork);
        _genericSubscriptionsRepositoryTests = new GenericRepositoryTests<ISubscriptionsRepository, SubscriptionsDto>(
            _subscriptionsRepository, _unitOfWork);
        _genericCashFlowStatementRepositoryTests = new GenericRepositoryTests<ICashFlowStatementRepository, CashFlowStatementDto>(
            _cashFlowStatementRepository, _unitOfWork);
        _genericIncomeStatementRepositoryTests = new GenericRepositoryTests<IIncomeStatementRepository, IncomeStatementDto>(
            _incomeStatementRepository, _unitOfWork);
        _genericIndividualStockRepositoryTests = new GenericRepositoryTests<IIndividualStockRepository, IndividualStockDto>(
            _individualStockRepository, _unitOfWork);
        _genericKeyMetricsRepositoryTests = new GenericRepositoryTests<IKeyMetricsRepository, KeyMetricsDto>(
            _keyMetricsRepository, _unitOfWork);
        _genericRatiosTtmRepositoryTests = new GenericRepositoryTests<IRatiosTtmRepository, RatiosDto>(
            _ratiosTtmRepository, _unitOfWork);
    }
    
    [Fact]
    public void CanAddEntryToRepository()
    {
        _genericShortlistRepositoryTests.CanAddEntryToRepository();
        _genericStockDataRepositoryTests.CanAddEntryToRepository();
        _genericInvoicesRepositoryTests.CanAddEntryToRepository();
        _genericSubscriptionsRepositoryTests.CanAddEntryToRepository();
        _genericCashFlowStatementRepositoryTests.CanAddEntryToRepository();
        _genericIncomeStatementRepositoryTests.CanAddEntryToRepository();
        _genericIndividualStockRepositoryTests.CanAddEntryToRepository();
        _genericKeyMetricsRepositoryTests.CanAddEntryToRepository();
        _genericRatiosTtmRepositoryTests.CanAddEntryToRepository();
    }
    
    [Fact]
    public void CanAddRangeOfEntriesToRepository()
    {
        _genericShortlistRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericStockDataRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericInvoicesRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericSubscriptionsRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericCashFlowStatementRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericIncomeStatementRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericIndividualStockRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericKeyMetricsRepositoryTests.CanAddRangeOfEntriesToRepository();
        _genericRatiosTtmRepositoryTests.CanAddRangeOfEntriesToRepository();
    }

    [Fact]
    public void CanRemoveEntryToRepository()
    {
        _genericShortlistRepositoryTests.CanRemoveEntryToRepository();
        _genericStockDataRepositoryTests.CanRemoveEntryToRepository();
        _genericInvoicesRepositoryTests.CanRemoveEntryToRepository();
        _genericSubscriptionsRepositoryTests.CanRemoveEntryToRepository();
        _genericCashFlowStatementRepositoryTests.CanRemoveEntryToRepository();
        _genericIncomeStatementRepositoryTests.CanRemoveEntryToRepository();
        _genericIndividualStockRepositoryTests.CanRemoveEntryToRepository();
        _genericKeyMetricsRepositoryTests.CanRemoveEntryToRepository();
        _genericRatiosTtmRepositoryTests.CanRemoveEntryToRepository();
    }
    [Fact]
    public void CanRemoveRangeEntryToRepository()
    {
        _genericShortlistRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericStockDataRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericInvoicesRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericSubscriptionsRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericCashFlowStatementRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericIncomeStatementRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericIndividualStockRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericKeyMetricsRepositoryTests.CanRemoveRangeEntryToRepository();
        _genericRatiosTtmRepositoryTests.CanRemoveRangeEntryToRepository();
    }
    [Fact]
    public void CanRemoveEntityEntryToRepository()
    {
        _genericShortlistRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericStockDataRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericInvoicesRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericSubscriptionsRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericCashFlowStatementRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericIncomeStatementRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericIndividualStockRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericKeyMetricsRepositoryTests.CanRemoveEntityEntryToRepository();
        _genericRatiosTtmRepositoryTests.CanRemoveEntityEntryToRepository();
    }
    // TODO: needs a pattern implemented to shorten the amount of code needed
    [Fact]
    public void CanUpdateEntryToRepository()
    {
        var shortlistDto = _shortListRepository
            .GetAll()
            .First();
        _genericShortlistRepositoryTests.CanUpdateEntryToRepository(new ShortlistDto()
        {
            Id = shortlistDto.Id,
            StockInfoDataId = shortlistDto.StockInfoDataId,
            Ticker = "New Ticker",
            UserId = shortlistDto.UserId
        }, "New Ticker");
        
        var stockInfoDatum = _stockRepository
            .GetAll()
            .First();
        _genericStockDataRepositoryTests.CanUpdateEntryToRepository(new StockInfoDatumDTO()
        {
            Id = stockInfoDatum.Id,
            Ticker = "New Ticker",
        }, "New Ticker");
    }

}