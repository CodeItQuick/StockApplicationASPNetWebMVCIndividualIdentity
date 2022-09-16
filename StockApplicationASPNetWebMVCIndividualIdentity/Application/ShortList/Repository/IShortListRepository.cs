using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IShortListRepository
{

    public void Add(ShortlistDto entity);
}