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

    [Fact]
    public void CanDeleteFirstEntryFromShortlistRepository()
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var service = new ShortlistService(unitOfWork);
        var shortlistDtos = unitOfWork.ShortListRepository.Find(dto => true).First();
        Assert.NotNull(shortlistDtos);

        service.DeleteFromShortlist(shortlistDtos.Ticker, shortlistDtos.UserId);
        
        var deleted = unitOfWork.ShortListRepository.Find(dto => 
            shortlistDtos.Ticker == dto.Ticker &&
            shortlistDtos.UserId == dto.UserId).Count();
        Assert.Equal(2, deleted);
        
    }
}