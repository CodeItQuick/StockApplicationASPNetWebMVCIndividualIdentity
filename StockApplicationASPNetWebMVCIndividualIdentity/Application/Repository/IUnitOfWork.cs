using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IUnitOfWork : IDisposable  
{  
    bool SaveChanges();
    IShortListRepository ShortListRepository { get; }
    IStockDataRepository StockRepository { get; }
    IShortlistStockInfoDataViewRepository ShortlistStockInfoDataViewRepository { get; }
    IInvoicesRepository InvoicesRepository { get; }
    ISubscriptionsRepository SubscriptionsRepository { get; }
}