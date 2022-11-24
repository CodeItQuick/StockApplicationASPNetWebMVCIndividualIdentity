using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class IndexResponseModel<TEntity>
{
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; } = true;
    public List<TEntity> StockInfoDatums { get; set; }
    public int PageIndex { get; set; } = 0;
    public int NumPages { get; set; } = 1;
}