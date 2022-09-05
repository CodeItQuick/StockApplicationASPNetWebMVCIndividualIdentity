using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplication.Core.Tests.Application;

[Table("ShortList")]
public class ShortListDTO
{
    [Key]
    public long Id { get; set; }
    public string? Symbol { get; set; }
}