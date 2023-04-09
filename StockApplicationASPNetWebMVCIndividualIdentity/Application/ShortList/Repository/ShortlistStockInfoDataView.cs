using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Application;

namespace StockApplication.Core.Tests.Application;

[Table("ShortlistStockInfoDataView")]
public class ShortlistStockInfoDataView
{
    [Key]
    public long Id { get; set; }
    public long TickerId { get; set; }
    public string? Ticker { get; set; }
    public string? UserId { get; set; }
    public decimal? Eps { get; set; }
    public decimal? PeRatio { get; set; }
    public decimal? MarketCap { get; set; }
    public decimal? Roe { get; set; }

}