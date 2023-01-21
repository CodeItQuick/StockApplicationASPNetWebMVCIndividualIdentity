using AutoFixture.Xunit2;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplication.Core.Tests.Application;

public class IndividualServiceTests
{
    [Theory, AutoData]
    public void CanAddToShortlistRepositoryUsingDbContextMock(ShortlistDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var service = new IndividualStockService(unitOfWork);

        var stocks = service.RetrieveIndividualStocks("ABC");

        Assert.Equal(3, stocks.Count());

    }

}