using System.Linq.Expressions;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class ShortlistServiceTests
{
    [Fact]
    public void CanAddToShortlistRepository()
    {
        var repository = new Mock<IUnitOfWork>();
        ShortlistDto shortListDTO = new ShortlistDto()
        {
            Ticker = "new ticker"
        };
        repository.Setup(r => 
                r.ShortListRepository.Add(shortListDTO));
        repository.Setup(r => r.SaveChanges());
        var service = new ShortlistService(repository.Object);

        service.AddToShortlist(shortListDTO);

        repository.Verify(r => 
            r.ShortListRepository.Add(shortListDTO));
        repository.Verify(r => 
            r.SaveChanges());
        repository.VerifyNoOtherCalls();
        
    }

    [Fact]
    public void CanDeleteFromShortlistRepository()
    {
        var repository = new Mock<IUnitOfWork>();
        var shortlistStock = new List<ShortlistDto>()
        {
            new ()
            {
                Id = 1,
                StockInfoDataId = 1,
                Ticker = "AAPL"
            }
        };

    repository.Setup(r => 
            r.ShortListRepository.Find(It.IsAny<Expression<Func<ShortlistDto, bool>>>()))
            .Returns(shortlistStock);
        repository.Setup(r => 
            r.ShortListRepository
                .Remove(shortlistStock.Single()));
        repository.Setup(r => r.SaveChanges());
        var service = new ShortlistService(repository.Object);

        service.DeleteFromShortlist("AAPL", "");

        repository.Verify(r => 
            r.ShortListRepository.Find(It.IsAny<Expression<Func<ShortlistDto, bool>>>()), Times.Once);
        repository.Verify(r => 
            r.ShortListRepository.Remove(shortlistStock.Single()), Times.Once);
        repository.Verify(r => 
            r.SaveChanges(), Times.Once);
        repository.VerifyNoOtherCalls();
        
    }
}