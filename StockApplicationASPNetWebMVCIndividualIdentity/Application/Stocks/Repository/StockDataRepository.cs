using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class StockDataRepository : Repository<StockInfoDatumDTO>, IStockDataRepository
{

    public StockDataRepository(StockContext stockContext) : base(stockContext)
    {
    }

}

