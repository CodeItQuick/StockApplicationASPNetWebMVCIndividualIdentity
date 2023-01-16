using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

[Table("Shortlist")]
public class ShortlistDto : DatabaseTable
{
    [Key]
    public override long Id { get; set; }
    public long StockInfoDataId { get; set; }
    public string UserId { get; set; }
    public string Ticker { get; set; }
}

public interface IEntityId
{
}