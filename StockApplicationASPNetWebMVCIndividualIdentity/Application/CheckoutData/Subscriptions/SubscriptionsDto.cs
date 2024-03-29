using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

[Table("Subscriptions")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class SubscriptionsDto
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public long Id { get; set; }
    [JsonProperty(PropertyName = "SubscriptionId")]
    public string? SubscriptionId { get; set; }
    [JsonProperty(PropertyName = "CreatedDate")]
    public DateTimeOffset CreatedDate { get; set; }
    [JsonProperty(PropertyName = "Description")]
    public string? Description { get; set; }
    [JsonProperty(PropertyName = "CancelAt")]
    public DateTimeOffset? CancelAt { get; set; }
    [JsonProperty(PropertyName = "CanceledAt")]
    public DateTimeOffset? CanceledAt { get; set; }
    [JsonProperty(PropertyName = "CreatedAt")]
    public DateTimeOffset? CreatedAt { get; set; }
    [JsonProperty(PropertyName = "CurrentPeriodStart")]
    public DateTimeOffset? CurrentPeriodStart { get; set; }
    [JsonProperty(PropertyName = "CurrentPeriodEnd")]
    public DateTimeOffset? CurrentPeriodEnd { get; set; }
    [JsonProperty(PropertyName = "Status")]
    public string? Status { get; set; }
    [JsonProperty(PropertyName = "Customer")]
    public string? Customer { get; set; }
    
}