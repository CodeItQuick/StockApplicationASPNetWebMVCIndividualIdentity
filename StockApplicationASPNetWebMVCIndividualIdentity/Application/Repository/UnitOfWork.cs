using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class UnitOfWork : IUnitOfWork  
{  
    protected readonly StockContext Context;  
  
    public UnitOfWork()  
    {  
        Context = new StockContext();  
    }  
  
    public bool SaveChanges()  
    {  
        bool returnValue = true;
        using var dbContextTransaction = Context.Database.BeginTransaction();
        try  
        {  
            Context.SaveChanges();  
            dbContextTransaction.Commit();  
        }  
        catch (Exception)  
        {  
            //Log Exception Handling message                      
            returnValue = false;  
            dbContextTransaction.Rollback();  
        }

        return returnValue;  
    }  
 
    #region Public Properties  
  
    private StockDataRepository? _stockDataRepository;  
    
    public IStockDataRepository StockRepository => _stockDataRepository 
        ??= new StockDataRepository(Context);

    private ShortListRepository? _shortListRepository;
    public IShortListRepository ShortListRepository => _shortListRepository 
        ??= new ShortListRepository(Context);

    private ShortlistStockInfoDataViewRepository? _shortlistStockInfoDataViewRepository;
    public IShortlistStockInfoDataViewRepository ShortlistStockInfoDataViewRepository => 
        _shortlistStockInfoDataViewRepository ??= new ShortlistStockInfoDataViewRepository(Context);

    private IncomeStatementRepository? _incomeStatementRepository;
    public IIncomeStatementRepository IncomeStatementRepository => 
        _incomeStatementRepository ??= new IncomeStatementRepository(Context);
    private KeyMetricsRepository? _keyMetricsRepository;
    public IKeyMetricsRepository KeyMetricsRepository => 
        _keyMetricsRepository ??= new KeyMetricsRepository(Context);
    private RatiosTtmRepository? _ratiosTtmRepository;
    public IRatiosTtmRepository RatiosTtmRepository => 
        _ratiosTtmRepository ??= new RatiosTtmRepository(Context);
    private CashFlowStatementRepository? _cashFlowStatementRepository;
    public ICashFlowStatementRepository CashFlowStatementRepository => 
        _cashFlowStatementRepository ??= new CashFlowStatementRepository(Context);
    private IndividualStockRepository? _individualStockRepository;
    public IIndividualStockRepository IndividualStockRepository => 
        _individualStockRepository ??= new IndividualStockRepository(Context);
    private InvoicePaymentSucceededRepository? _invoicePaymentSucceededRepository;
    public IInvoicePaymentSucceededRepository InvoicePaymentSucceededRepository => 
        _invoicePaymentSucceededRepository ??= new InvoicePaymentSucceededRepository(Context);

    #endregion


    #region IDisposable Support

    private bool _disposedValue = false; // To detect redundant calls  

    protected virtual void Dispose(bool disposing)  
    {  
        if (_disposedValue) return;  
  
        if (disposing)  
        {  
            //dispose managed state (managed objects).  
        }  
  
        // free unmanaged resources (unmanaged objects) and override a finalizer below.  
        // set large fields to null.  
  
        _disposedValue = true;  
    }  
  
    // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.  
    // ~UnitOfWork() {  
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
    //   Dispose(false);  
    // }  
  
    // This code added to correctly implement the disposable pattern.  
    public void Dispose()  
    {  
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
        Dispose(true);  
        // uncomment the following line if the finalizer is overridden above.  
        // GC.SuppressFinalize(this);  
    }  
    #endregion  
  
}