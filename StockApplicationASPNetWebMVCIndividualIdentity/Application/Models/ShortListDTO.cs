using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplication.Core.Tests.Application;

[Table("Shortlist")]
public class ShortListDTO
{
    [Key]
    public long Id { get; set; }
    public string? Ticker { get; set; }
    public long StockInfoDataId { get; set; }
    public long UserId { get; set; }
}