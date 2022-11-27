using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class InvoicePaymentSucceededRepository : Repository<InvoicePaymentSucceededDto>, IInvoicePaymentSucceededRepository
{
    public InvoicePaymentSucceededRepository(StockContext context) : base(context)
    {
    }
}