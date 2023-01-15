using AutoFixture.Xunit2;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

namespace StockApplication.Core.Tests.Application;

public class RepositoryInheritedMethodTestsWithInvoiceRepositoryTests
{
    [Theory, AutoData]
    public void CanAddEntryToInvoicesRepository(InvoicesDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();

        unitOfWork.InvoicesRepository.Add(entry);
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .Find(x => x.Id == entry.Id).FirstOrDefault();
        Assert.NotNull(invoicesDto);

    }
    [Theory, AutoData]
    public void CanAddRangeOfEntriesToInvoicesRepository(IEnumerable<InvoicesDto> entries)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();

        unitOfWork.InvoicesRepository.AddRange(entries);
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .GetAll();
        Assert.Equal(6, invoicesDto.Count());

    }
    [Theory, AutoData]
    public void CanRemoveEntryToInvoicesRepository()
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var deletedItem = unitOfWork.InvoicesRepository.GetAll().First();

        unitOfWork.InvoicesRepository.Remove(deletedItem);
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .Find(x => x.Id == deletedItem.Id).FirstOrDefault();
        Assert.Null(invoicesDto);
    }
    
    [Theory, AutoData]
    public void CanRemoveRangeEntryToInvoicesRepository()
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var deletedItem = unitOfWork.InvoicesRepository.GetAll();

        unitOfWork.InvoicesRepository.RemoveRange(deletedItem);
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .GetAll();
        Assert.Empty(invoicesDto);
    }
    [Theory, AutoData]
    public void CanRemoveEntityEntryToInvoicesRepository()
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var removedItems = unitOfWork.InvoicesRepository.GetAll();
    
        unitOfWork.InvoicesRepository.RemoveEntity(removedItems.First());
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .GetAll();
        Assert.Equal(2, invoicesDto.Count());
    }

    [Theory, AutoData]
    public void CanUpdateEntryToInvoicesRepository(InvoicesDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var item = unitOfWork.InvoicesRepository
            .GetAll()
            .First();
        
        unitOfWork.InvoicesRepository.UpdateEntity(new InvoicesDto()
        {
            Id = item.Id,
            AmountPaid = item.AmountPaid,
            AmountDue = item.AmountDue,
            AmountRemaining = item.AmountRemaining,
            Paid = item.Paid,
            Subscription = "changed_subscription"
        });
        unitOfWork.SaveChanges();
        
        var invoicesDto = unitOfWork.InvoicesRepository
            .Find(x => x.Id == item.Id).FirstOrDefault();
        Assert.Equal("changed_subscription", invoicesDto?.Subscription);
    }
}