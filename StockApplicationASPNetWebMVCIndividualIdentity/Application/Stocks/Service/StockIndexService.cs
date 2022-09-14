using System.Globalization;
using StockApplication.Core.Tests;
using StockApplication.Core.Tests.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;
using static System.Decimal;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

public class StockIndexService
{
    private readonly IStockDataRepository? _stockDataRepository;

    public StockIndexService()
    {
        
    }

    public StockIndexService(IStockDataRepository stockDataRepository)
    {
        _stockDataRepository = stockDataRepository;
    }
    
    public List<StocksAdapter> DisplayAllStocks(int pageNumber)
    {
        // Get Data
        using var unitOfWork = new UnitOfWork();
        IStockDataRepository stockDataRepository = _stockDataRepository ?? unitOfWork.StockRepository;
        var stockInfo = stockDataRepository
            .Get()
            .Skip(pageNumber * 20).Take(20);

        var stocksList = StocksAdapterConverter.ConvertFrom(stockInfo);

        return stocksList.ToList();
    }


}