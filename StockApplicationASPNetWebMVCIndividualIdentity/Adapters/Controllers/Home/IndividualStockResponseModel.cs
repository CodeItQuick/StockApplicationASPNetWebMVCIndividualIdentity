using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class IndividualStockResponseModel<TEntity>
{
    public IEnumerable<TEntity>? IndividualStockEarningsView { get; set; }
    public IEnumerable<SubscriptionsDto> StockSubscriptions { get; set; }
    public List<CashFlowStatementDto> CashFlowDto { get; set; }
}