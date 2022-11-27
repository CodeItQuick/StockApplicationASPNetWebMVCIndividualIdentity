using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class IndividualStockResponseModel<TEntity>
{
    public IEnumerable<TEntity> IndividualStockEarningsView { get; set; }
    public IEnumerable<SubscriptionsDto> StockSubscriptions { get; set; }
}