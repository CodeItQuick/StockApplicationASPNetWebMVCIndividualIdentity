using System.Linq.Expressions;
using StockApplication.Core.Tests.Application;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IShortListRepository
{
    IEnumerable<ShortListDTO> Get(  
        Expression<Func<ShortListDTO, bool>> filter = null,  
        Func<IQueryable<ShortListDTO>, IOrderedQueryable<ShortListDTO>> orderBy = null,  
        string? includeProperties = "");
}