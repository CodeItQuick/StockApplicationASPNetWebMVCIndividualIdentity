using System.Linq.Expressions;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public interface IStockDataRepository : IRepository<StockInfoDatumDTO>
{
}