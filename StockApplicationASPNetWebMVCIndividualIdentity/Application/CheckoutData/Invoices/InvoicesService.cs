using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.CashFlowStatement;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;

public class InvoicesService
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoicesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool AddToInvoicePaymentSucceeded(InvoicesDto invoicesDto)
    {   
        try
        {
            _unitOfWork.InvoicesRepository.Add(invoicesDto);
            var saveChanges = _unitOfWork.SaveChanges();
            return saveChanges;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public IEnumerable<InvoicesDto> Retrieve()
    {
        return _unitOfWork.InvoicesRepository.GetAll();
    }
}