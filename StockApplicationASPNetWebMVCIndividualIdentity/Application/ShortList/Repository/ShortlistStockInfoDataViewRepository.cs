using System.Linq.Expressions;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using ShortlistStockInfoDataView = StockApplication.Core.Tests.Application.ShortlistStockInfoDataView;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class ShortlistStockInfoDataViewRepository : Repository<ShortlistStockInfoDataView>, 
    IShortlistStockInfoDataViewRepository
{
    public ShortlistStockInfoDataViewRepository(StockContext context) : base(context)
    {
    }
}