using System.Linq.Expressions;
using Moq;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.IncomeStatements;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Domain;

namespace StockApplication.Core.Tests.Application;

public class IncomeStatementServiceTests
{
    [Fact]
    public void GivenAListOfIncomeStatementsCanAddData()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        List<IncomeStatementDto> incomeStatementDtos = new List<IncomeStatementDto>()
        {
            new()
            {
                Id = 1,
                Symbol = "AAPL",
            }
        };  
        unitOfWork.Setup(r => 
            r.IncomeStatementRepository.AddRange(incomeStatementDtos));
        unitOfWork.Setup(r => 
            r.SaveChanges());
        var service = new IncomeStatementService(unitOfWork.Object);
        
        service
            .AddToIncomeStatements(incomeStatementDtos);
        
        unitOfWork.Verify(r => 
                r.IncomeStatementRepository.AddRange(incomeStatementDtos),
            Times.Once);
        unitOfWork.Verify(r => 
                r.SaveChanges(),
            Times.Once);
        unitOfWork.VerifyNoOtherCalls();
        
    }
}