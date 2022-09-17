using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockIndexService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockIndexService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<StocksAdapter> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        var stockInfo = _unitOfWork.StockRepository
            .Get(null, null)
            .Skip(pageNumber * 20).Take(20);

        var stocksList = StocksAdapterConverter.ConvertFrom(stockInfo);

        return stocksList.ToList();
    }


}