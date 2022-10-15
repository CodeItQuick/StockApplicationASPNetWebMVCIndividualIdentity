using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IShortListRepository
{

    public void Add(ShortlistDto entity);
    ShortlistDto Get(long stockId);
    public void Remove(ShortlistDto stockId);
    public IEnumerable<ShortlistDto> Find(System.Linq.Expressions.Expression<Func<ShortlistDto, bool>> predicate);

}