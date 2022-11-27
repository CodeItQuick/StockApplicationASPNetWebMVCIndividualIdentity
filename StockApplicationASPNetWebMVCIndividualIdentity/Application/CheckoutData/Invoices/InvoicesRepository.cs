using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class InvoicesRepository : Repository<InvoicesDto>, IInvoicesRepository
{
    public InvoicesRepository(StockContext context) : base(context)
    {
    }
}