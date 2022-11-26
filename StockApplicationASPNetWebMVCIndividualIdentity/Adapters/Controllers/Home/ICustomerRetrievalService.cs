using System.Security.Claims;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Checkout;

public interface ICustomerRetrievalService
{
    public string? HandleRetrieveCustomerId(ClaimsPrincipal user);
}