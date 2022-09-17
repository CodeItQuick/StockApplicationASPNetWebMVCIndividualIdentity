namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StocksAdapter
{
    public string Ticker { get; set; }
    public Dictionary<string, decimal>? stockAttribute { get; set; } = new Dictionary<string, decimal>();
    public long Id { get; set; }
}