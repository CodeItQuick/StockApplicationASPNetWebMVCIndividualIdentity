using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

[Table("Invoices")]
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class InvoicesDto : DatabaseTable
{
    [Key]
    [JsonProperty(PropertyName = "Id")]
    public override long Id { get; set; }
    [JsonProperty(PropertyName = "CreatedDate")]
    public DateTimeOffset CreatedDate { get; set; }
    [JsonProperty(PropertyName = "AmountPaid")]
    public long AmountPaid { get; set; }
    [JsonProperty(PropertyName = "AmountDue")]
    public long AmountDue { get; set; }
    [JsonProperty(PropertyName = "AmountRemaining")]
    public long AmountRemaining { get; set; }
    [JsonProperty(PropertyName = "CollectionMethod")]
    public string? CollectionMethod { get; set; }
    [JsonProperty(PropertyName = "Customer")]
    public string? Customer { get; set; }
    [JsonProperty(PropertyName = "CustomerEmail")]
    public string? CustomerEmail { get; set; }
    [JsonProperty(PropertyName = "CustomerName")]
    public string? CustomerName { get; set; }
    [JsonProperty(PropertyName = "Subscription")]
    public string? Subscription { get; set; }
    [JsonProperty(PropertyName = "Paid")]
    public bool Paid { get; set; }
    [JsonProperty(PropertyName = "LineItemPriceId")]
    public string? LineItemPriceId { get; set; }

    [JsonProperty(PropertyName = "HostedInvoiceUrl")]
    public string? HostedInvoiceUrl { get; set; }
}