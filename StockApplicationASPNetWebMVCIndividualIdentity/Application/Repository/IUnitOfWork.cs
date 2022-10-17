namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IUnitOfWork : IDisposable  
{  
    bool SaveChanges();
    IShortListRepository ShortListRepository { get; }
    IStockDataRepository StockRepository { get; }
    IShortlistStockInfoDataViewRepository ShortlistStockInfoDataViewRepository { get; }
    IIncomeStatementRepository IncomeStatementRepository { get; }
    IKeyMetricsRepository KeyMetricsRepository { get; }
}