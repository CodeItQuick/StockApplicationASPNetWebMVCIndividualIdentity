using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class SubscriptionsService
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public SubscriptionsService(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public bool AddToInvoicePaymentSucceeded(SubscriptionsDto subscriptionDto)
    {   
        try
        {
            _subscriptionsRepository.Add(subscriptionDto);
            return true;
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
            var subscriptionsDtos = _subscriptionsRepository.Get(null,null);
            return subscriptionsDtos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}