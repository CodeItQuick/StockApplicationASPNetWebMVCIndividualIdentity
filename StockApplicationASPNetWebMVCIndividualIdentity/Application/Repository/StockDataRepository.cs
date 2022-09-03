using StockApplication.Core.Tests.Domain;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

internal class StockDataRepository : Repository<StockInfoDatumDTO>
{
    public StockDataRepository(stockContext stockContext) : base(stockContext)
    {
    }

}

