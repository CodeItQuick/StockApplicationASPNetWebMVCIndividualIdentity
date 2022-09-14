using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplication.Core.Tests.Application;

[Table("ShortlistStockInfoDataView")]
public class ShortListDTO
{
    [Key]
    public long Id { get; set; }
    public string? Ticker { get; set; }
    public int UserId { get; set; }
    public decimal? Eps { get; set; }
    public decimal? PeRatio { get; set; }
    public decimal? MarketCap { get; set; }
    public decimal? Roe { get; set; }

}