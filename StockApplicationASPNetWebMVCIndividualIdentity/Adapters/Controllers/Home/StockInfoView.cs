using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using Stripe;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class StockInfoView
{
    public List<StocksAdapter> StockInfoDatums { get; set; }
    public static StockInfoView Of(List<StocksAdapter> stockInfoDatums, StripeList<Subscription>? subscriptions)
    {
        var stockInfoView = new StockInfoView();
        stockInfoDatums.ForEach(stock =>
        {
            if (subscriptions == null) return;
            var subscriptionRecord = subscriptions.FirstOrDefault(subscription => 
                subscription is { Description: { } } && 
                subscription.Description.Contains(stock.Ticker));
            string? subscriptionType = null;
            subscriptionRecord?.Items.Data[0].Plan.Metadata
                .TryGetValue("SubscriptionName", out subscriptionType);
            stock.SubscriptionType = subscriptionType ?? "None";
        });
        stockInfoView.StockInfoDatums = stockInfoDatums;
        return stockInfoView;
    }
}