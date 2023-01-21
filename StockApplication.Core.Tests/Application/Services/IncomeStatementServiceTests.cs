using AutoFixture.Xunit2;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;

namespace StockApplication.Core.Tests.Application;

public class IncomeStatementServiceTests
{
    [Theory, AutoData]
    public void GivenAListOfIncomeStatementsCanAddData(IncomeStatementDto incomeStatementDto)
    {
        var databaseMethods = new DatabaseMethods();
        var unitOfWork = databaseMethods.CreateTestUnitOfWork();  
        var service = new IncomeStatementService(unitOfWork);
        
        service
            .AddToIncomeStatements(new List<IncomeStatementDto>()
            {
                incomeStatementDto
            });

        Assert.Equal(4, unitOfWork.IncomeStatementRepository.GetAll().Count());
    }
}