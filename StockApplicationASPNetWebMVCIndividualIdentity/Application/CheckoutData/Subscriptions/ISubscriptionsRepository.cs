
namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public interface ISubscriptionsRepository
{
    void Add(SubscriptionsDto subscriptionDto);
    IEnumerable<SubscriptionsDto> Get(int? id, int? userId);
}