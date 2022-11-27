using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class InvoicePaymentSucceededService
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoicePaymentSucceededService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool AddToInvoicePaymentSucceeded(InvoicePaymentSucceededDto invoicePaymentSucceededDto)
    {   
        try
        {
            _unitOfWork.InvoicePaymentSucceededRepository.Add(invoicePaymentSucceededDto);
            var saveChanges = _unitOfWork.SaveChanges();
            return saveChanges;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}