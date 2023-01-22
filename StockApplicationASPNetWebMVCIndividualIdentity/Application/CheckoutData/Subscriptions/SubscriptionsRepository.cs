using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class SubscriptionsRepository : ISubscriptionsRepository
{
    private readonly StockContext _context;

    public SubscriptionsRepository(StockContext context)
    {
        _context = context;
    }

    public void Add(SubscriptionsDto subscriptionDto)
    {
        _context.Subscriptions?.Add(subscriptionDto);
        _context.SaveChanges();
    }

    public IEnumerable<SubscriptionsDto> Get(int? id, int? userId)
    {
        return _context.Subscriptions.Where(x => true);
    }
}