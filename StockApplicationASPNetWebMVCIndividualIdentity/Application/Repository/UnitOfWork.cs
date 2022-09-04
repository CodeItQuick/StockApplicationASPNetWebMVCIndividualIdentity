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
    
    public StockDataRepository StockRepository => _stockDataRepository ??= new StockDataRepository(Context);

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
public interface IUnitOfWork : IDisposable  
{  
    bool SaveChanges();  
} 