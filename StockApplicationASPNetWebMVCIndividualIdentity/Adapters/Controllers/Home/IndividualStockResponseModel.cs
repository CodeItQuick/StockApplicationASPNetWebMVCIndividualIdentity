namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class IndividualStockResponseModel<TEntity>
{
    public IEnumerable<TEntity> IndividualStockEarningsView { get; set; }
}