using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class ShortListRepository : Repository<ShortlistDto>, IShortListRepository
{
    public ShortListRepository(StockContext context) : base(context)
    {
    }
}