using AutoFixture.Xunit2;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;

namespace StockApplication.Core.Tests.Application;

public class ShortlistServiceTests
{
    [Theory, AutoData]
    public void CanAddToShortlistRepositoryUsingDbContextMock(ShortlistDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var service = new ShortlistService(unitOfWork);

        service.AddToShortlist(entry);
        
        var shortlistDto = unitOfWork.ShortListRepository.Get(entry.Id);
        Assert.NotNull(shortlistDto);

    }
}