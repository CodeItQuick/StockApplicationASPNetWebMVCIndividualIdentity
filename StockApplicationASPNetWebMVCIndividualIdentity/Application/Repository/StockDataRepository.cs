using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class StockDataRepository : Repository<StockInfoDatumDTO>, IStockDataRepository
{
    public StockDataRepository(StockContext stockContext) : base(stockContext)
    {
    }

}

