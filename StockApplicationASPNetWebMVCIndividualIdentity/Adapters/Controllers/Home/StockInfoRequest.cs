namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;

public class StockInfoRequest
{
    public string sortOrder { get; set; }
    public string currentFilter { get; set; }
    public string searchString { get; set; }
    public int? pageNumber { get; set; }
}