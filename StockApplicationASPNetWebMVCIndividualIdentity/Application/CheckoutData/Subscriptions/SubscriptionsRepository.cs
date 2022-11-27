using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class SubscriptionsRepository : Repository<SubscriptionsDto>, ISubscriptionsRepository
{
    public SubscriptionsRepository(StockContext context) : base(context)
    {
    }
}