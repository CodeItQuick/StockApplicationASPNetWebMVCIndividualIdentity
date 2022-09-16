using System.Linq.Expressions;
using StockApplication.Core.Tests.Application;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IShortlistStockInfoDataViewRepository
{
    IEnumerable<ShortlistStockInfoDataView> Get(  
        Expression<Func<ShortlistStockInfoDataView, bool>> filter = null,  
        Func<IQueryable<ShortlistStockInfoDataView>, 
            IOrderedQueryable<ShortlistStockInfoDataView>> orderBy = null,  
        string? includeProperties = "");
}