namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockAdapterDTO
{
    public string Symbol { get; set; }
    public decimal PeRatio { get; set; }
    public decimal PbRatio { get; set; }
    public decimal CashFlowToSales { get; set; }
    public decimal Roe { get; set; }
    public decimal BvS { get; set; }
    public decimal DivYield { get; set; }
}