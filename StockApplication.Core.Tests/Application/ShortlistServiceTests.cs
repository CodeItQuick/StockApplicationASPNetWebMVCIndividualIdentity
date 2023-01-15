using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.IndividualStockView;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

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
        Assert.Equal(0, deleted);
        
    }
}