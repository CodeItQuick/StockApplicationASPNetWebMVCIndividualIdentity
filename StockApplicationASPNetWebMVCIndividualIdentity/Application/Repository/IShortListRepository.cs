using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplication.Core.Tests.Application;

public interface IShortListRepository
{
    IEnumerable<StockInfoDatumDTO> Get(  
        Expression<Func<StockInfoDatumDTO, bool>> filter = null,  
        Func<IQueryable<StockInfoDatumDTO>, IOrderedQueryable<StockInfoDatumDTO>> orderBy = null,  
        string? includeProperties = "");
}