using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IStockDataRepository : IRepository<StockInfoDatumDTO>
{
     IEnumerable<StockInfoDatumDTO> Get(  
        Expression<Func<StockInfoDatumDTO, bool>> filter,  
        Func<IQueryable<StockInfoDatumDTO>, IOrderedQueryable<StockInfoDatumDTO>> orderBy,  
        string? includeProperties = "");
}