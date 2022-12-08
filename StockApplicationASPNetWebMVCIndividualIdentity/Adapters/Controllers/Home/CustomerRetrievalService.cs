using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Checkout;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.RatiosTTM;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using Stripe;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class CustomerRetrievalService<TController> // TODO: in the future do this - : ServiceCollection, ICustomerRetrievalService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomerRetrievalService(
        ILogger<TController> logger,
        UserManager<ApplicationUser> userManager, 
        IConfiguration config)
    {
        _userManager = userManager;
            
        StripeConfiguration.ApiKey = config["StripeAPIKey"];
    }
    public string? HandleRetrieveCustomerId(ClaimsPrincipal user)
    {
        var userIdentity = _userManager.GetUserAsync(user).Result;
        var customerId = userIdentity.StripeCustomerId;

        // Chain of responsibility would make sense here, keep calling "handlers" until something can handle the
        // request
        if (customerId != null && customerId?.Length > 0)
        {
            return customerId;
        };
        var customerService = new CustomerService();
        var searchResult = customerService.Search(new CustomerSearchOptions()
        {
            Query = $"email:'{userIdentity.Email}'"
        });

        // For Existing Customers
        if (searchResult.Any())
        {
            customerId = searchResult.First().Id;
            if (customerId != null)
            {
                var tempUser = _userManager.FindByIdAsync(userIdentity.Id).Result;
                tempUser.StripeCustomerId = customerId;
                var identityResult = _userManager.UpdateAsync(tempUser).Result;
                return customerId;
            }
        };
        
        // Create Customer
        var customer = customerService.Create(new CustomerCreateOptions()
        {
            Email = userIdentity.Email
        });

        return customer.Id;
    }
}