using AutoFixture.Xunit2;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;

namespace StockApplication.Core.Tests.Application;

public class CashFlowStatementServiceTests
{
    [Theory, AutoData]
    public void CanAddRangeToCashFlowStatementRepositoryUsingDbContextMock(CashFlowStatementDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var service = new CashFlowStatementService(unitOfWork);
        entry.Id = 4;

        service.AddToCashFlowStatement(new List<CashFlowStatementDto>() { entry });

        Assert.Equal(4, unitOfWork.CashFlowStatementRepository.GetAll().Count());

    }
    [Theory, AutoData]
    public void CanRetrieveCashFlowStatementRepositoryUsingDbContextMock(CashFlowStatementDto entry)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();
        var service = new CashFlowStatementService(unitOfWork);
        entry.Id = 4;

        service.RetrieveIndividualStocks("ABC");

        Assert.Equal(3, unitOfWork.CashFlowStatementRepository.GetAll().Count());

    }

}