using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

[Table("Shortlist")]
public class ShortlistDto
{
    [Key]
    public long? Id { get; set; }
    public long StockInfoDataId { get; set; }
    public long UserId { get; set; }
    public string Ticker { get; set; }
}