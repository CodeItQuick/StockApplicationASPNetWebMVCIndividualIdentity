namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StocksAdapter
{
    public string Ticker { get; set; }
    public Dictionary<string, decimal>? stockAttribute { get; set; } = new Dictionary<string, decimal>();
    public long Id { get; set; }
    public decimal MarketCap { get; set; }
    public decimal PeRatio { get; set; }
    public decimal Roe { get; set; }
    public decimal Eps { get; set; }
}