using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class GenericRepositoryTests<TRepository, TEntity> 
    where TRepository : IRepository<TEntity>
    where TEntity : DatabaseTable, new()
{
    private TRepository repository;
    private UnitOfWork _unitOfWork;
    private TEntity? entry;
    private List<TEntity> entries;
    private Fixture _fixture;

    public GenericRepositoryTests(TRepository repository, UnitOfWork unitOfWork)
    {
        this.repository = repository;
        _unitOfWork = unitOfWork;
        _fixture = new Fixture();
        entry = _fixture
            .Build<TEntity>()
            .With(x => x.Id, 4)
            .Create();
        entry.Id = 4;
        entries = _fixture.Create<List<TEntity>>();
        entries[0].Id = 4;
        entries[1].Id = 5;
        entries[2].Id = 6;
    }

    public void CanAddEntryToRepository()
    {
        var entryType = new TEntity()
        {
            Id = entry.Id,
        };
        repository.Add(entryType);
        _unitOfWork.SaveChanges();
        var entities = repository.Find(x => true);
        Assert.Equal(1, entities.First().Id);
        Assert.Equal(4, entities.Count());
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
    
    // TODO Generic for symbol OR ticker very hard to produce
    // public void CanUpdateEntryToRepository(string result, string ticker)
    // {
    //     var entityDto = repository
    //         .GetAll()
    //         .First();
    //     var entity = _fixture.Build<TEntity>()
    //         .WithAutoProperties()
    //         .Create();
    //     
    //     repository.UpdateEntity(entity);
    //     _unitOfWork.SaveChanges();
    //
    //     Assert.Equal(repository.Get(entity.Id).Ticker, result);
    // }
}