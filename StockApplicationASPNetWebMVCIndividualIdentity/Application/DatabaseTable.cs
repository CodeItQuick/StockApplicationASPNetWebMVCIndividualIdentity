namespace StockApplicationASPNetWebMVCIndividualIdentity.Application;

public class DatabaseTable
{
    public virtual long Id { get; set; }
    public virtual string? Ticker { get; set; }
    public virtual string? Symbol { get; set; }
    public virtual string? UserId { get; set; }
}