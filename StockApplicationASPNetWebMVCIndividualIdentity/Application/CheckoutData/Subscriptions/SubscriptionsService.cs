using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class SubscriptionsService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool AddToInvoicePaymentSucceeded(SubscriptionsDto subscriptionDto)
    {   
        try
        {
            _unitOfWork.SubscriptionsRepository.Add(subscriptionDto);
            var saveChanges = _unitOfWork.SaveChanges();
            return saveChanges;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public IEnumerable<SubscriptionsDto> Retrieve()
    {
        try
        {
            var subscriptionsDtos = _unitOfWork.SubscriptionsRepository.Get(null,null);
            return subscriptionsDtos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}