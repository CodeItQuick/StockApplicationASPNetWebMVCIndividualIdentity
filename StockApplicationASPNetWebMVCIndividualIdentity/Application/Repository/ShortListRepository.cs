using StockApplication.Core.Tests.Application;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class ShortListRepository : Repository<ShortListDTO>, IShortListRepository
{
    public ShortListRepository(StockContext context) : base(context)
    {
    }
}