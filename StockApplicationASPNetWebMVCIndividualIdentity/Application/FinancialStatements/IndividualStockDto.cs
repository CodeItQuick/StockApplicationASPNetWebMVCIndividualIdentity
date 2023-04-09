using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;

[Table("IndividualStock")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class IndividualStockDto
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public int Id { get; set; }
    [JsonProperty(PropertyName = "Symbol")]
    public string Symbol { get; set; }
    [JsonProperty(PropertyName = "MarketCap")]
    public decimal? MarketCap { get; set; }
    [JsonProperty(PropertyName = "Date")]
    public DateTimeOffset Date { get; set; }
    [JsonProperty(PropertyName = "ReturnOnEquity")]
    public decimal? ReturnOnEquity { get; set; }
    [JsonProperty(PropertyName = "ShareholdersEquityPerShare")]
    public decimal? ShareholdersEquityPerShare { get; set; }
    [JsonProperty(PropertyName = "PerShareEarnings")]
    public decimal? PerShareEarnings { get; set; }
}