using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class IndexResponseModel 
{
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; } = true;
    public List<StocksAdapter> StockInfoDatums { get; set; }
    public int PageIndex { get; set; } = 0;
}