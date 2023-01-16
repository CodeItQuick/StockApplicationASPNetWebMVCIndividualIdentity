using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Application;

namespace StockApplication.Core.Tests.Application;

[Table("ShortlistStockInfoDataView")]
public class ShortlistStockInfoDataView : DatabaseTable
{
    [Key]
    public override long Id { get; set; }
    public long TickerId { get; set; }
    public override string? Ticker { get; set; }
    public override string? UserId { get; set; }
    public decimal? Eps { get; set; }
    public decimal? PeRatio { get; set; }
    public decimal? MarketCap { get; set; }
    public decimal? Roe { get; set; }

}