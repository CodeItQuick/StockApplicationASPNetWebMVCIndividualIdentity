using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class GenericRepositoryTests<TRepository, TEntity> 
    where TRepository : IRepository<TEntity>
    where TEntity : class, new()
{
    private TRepository repository;
    private UnitOfWork _unitOfWork;
    private TEntity? entry;
    private IEnumerable<TEntity> entries;

    public GenericRepositoryTests(TRepository repository, UnitOfWork unitOfWork)
    {
        this.repository = repository;
        _unitOfWork = unitOfWork;
        var fixture = new Fixture();
        entry = fixture.Create<TEntity>();
        entries = fixture.Create<IEnumerable<TEntity>>();
    }

    public void CanAddEntryToRepository()
    {
        repository.Add(entry);
        _unitOfWork.SaveChanges();
        var count = repository.Find(x => true).Count();
        Assert.Equal(4, count);


    }
    
    public void CanAddRangeOfEntriesToRepository()
    {
        repository.AddRange(entries);
        _unitOfWork.SaveChanges();
    
        Assert.Equal(
            6, 
            repository.GetAll().Count());
    
    }
    public void CanRemoveEntryToRepository()
    {
        var deletedItem = repository.GetAll().First();
    
        repository.Remove(deletedItem);
        _unitOfWork.SaveChanges();
    
        Assert.Equal(2, repository.GetAll().Count());
    }
    
    public void CanRemoveRangeEntryToRepository()
    {
        var deletedItem = repository.GetAll();
    
        repository.RemoveRange(deletedItem);
        _unitOfWork.SaveChanges();
    
        Assert.Empty(repository
            .GetAll());
    }
    
    public void CanRemoveEntityEntryToRepository()
    {
        var removedItems = repository.GetAll();
    
        repository.RemoveEntity(removedItems.First());
        _unitOfWork.SaveChanges();
    
        Assert.Equal(2, repository
            .GetAll().Count());
    }
    
    public void CanUpdateEntryToRepository(
        TEntity entityToUpdate,
        string result)
    {

        repository.UpdateEntity(entityToUpdate);
        _unitOfWork.SaveChanges();

        Assert.Equal("New Ticker", result);
    }
}