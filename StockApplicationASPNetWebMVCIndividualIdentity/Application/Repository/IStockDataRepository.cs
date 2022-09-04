using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IStockDataRepository
{
     IEnumerable<StockInfoDatumDTO> Get(  
        Expression<Func<StockInfoDatumDTO, bool>> filter = null,  
        Func<IQueryable<StockInfoDatumDTO>, IOrderedQueryable<StockInfoDatumDTO>> orderBy = null,  
        string? includeProperties = "")  ;
}