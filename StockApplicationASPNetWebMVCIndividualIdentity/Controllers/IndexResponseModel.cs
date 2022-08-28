using StockApplicationASPNetWebMVCIndividualIdentity.Models;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Controllers;

public class IndexResponseModel 
{
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; } = true;
    public List<StockInfoDatumDTO>? StockInfoDatums { get; set; }
    public int PageIndex { get; set; } = 0;
}