using System.Collections;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using StockApplicationASPNetWebMVCIndividualIdentity.Views.Checkout;
using Stripe;
using Stripe.Checkout;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Checkout;

[Authorize]
public class CheckoutController : Controller
{
    private readonly ILogger<CheckoutController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly CustomerRetrievalService<CheckoutController> _customerRetrievalService;
    private readonly InvoicesService _invoices;
    private readonly SubscriptionsService _subscriptions;
    const string endpointSecret = "whsec_9886e456919af0c3ad92ba5d093d585d1d9ebf6e7d4140d62690afc7939d7828";

    public CheckoutController(ILogger<CheckoutController> logger,
        IConfiguration configuration,
        UserManager<ApplicationUser> userManager, 
        StockContext subscriptionsService)
    {
        _logger = logger;
        _userManager = userManager;
        StripeConfiguration.ApiKey = configuration["StripeAPIKey"];
        _customerRetrievalService =
            new CustomerRetrievalService<CheckoutController>(logger, userManager, configuration);
        _invoices = new InvoicesService(new UnitOfWork());
        _subscriptions = new SubscriptionsService(subscriptionsService);
    }

    [Route("/create-checkout")]
    [HttpGet]
    public IActionResult CreateCheckout()
    {
        return View();
    }

    [Route("/success")]
    [HttpGet]
    public IActionResult SuccessCheckout()
    {
        return View();
    }

    [Route("/cancel")]
    [HttpGet]
    public IActionResult CancelCheckout()
    {
        return View();
    }

    [Route("/manage-subscriptions")]
    [HttpGet]
    public IActionResult ManageSubscriptions()
    {
        var service = new SubscriptionService();
        StripeList<Subscription> subscriptions = service.List(new SubscriptionListOptions());

        return View(subscriptions);
    }
    
    [Route("/create-checkout-session")]
    [HttpPost]
    public IActionResult CreateCheckoutReq(string subscriptionType)
    {
    
        var domain = "https://localhost:7006";
        var customerId = _customerRetrievalService.HandleRetrieveCustomerId(User);
    
        var options = new InvoiceItemCreateOptions()
        {
            Price = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ",
            Customer = customerId,
            Description = subscriptionType,
        };
        var service = new InvoiceItemService();
        var invoiceItem = service.Create(options);
    
        return Redirect("/Shortlist");
    }

    //TODO: Fix identity stuff
    [Route("/cancel-subscription")]
    [HttpPost]
    public IActionResult CancelSubscription([FromForm] CancelRequest req)
    {
        var domain = "https://localhost:7006";
        var userIdentity = _userManager.GetUserAsync(User).Result;
        var customerId = userIdentity.StripeCustomerId;
        var service = new SubscriptionService();
        var subscription = service.Cancel(req.subscriptionid);
    
        return Redirect("/manage-subscriptions");
    }
    
    [HttpGet]
    public IActionResult UpdateShippingAddress()
    {
        var customerService = new CustomerService();
        var customerId = _customerRetrievalService.HandleRetrieveCustomerId(User);
    
        var customerAddress = customerService.Get(customerId);
        return View(new UpdateShippingAddressModel()
        {
            Address = customerAddress?.Address ?? new Address(),
            Name = customerAddress?.Shipping?.Name ?? ""
        });
    }
    [HttpPost]
    public IActionResult PerformUpdateShippingAddress(
        string name,
        string line1, 
        string city, 
        string state, 
        string country,
        string postalcode)
    {
        var customerService = new CustomerService();
        var customerId = _customerRetrievalService.HandleRetrieveCustomerId(User);
    
        customerService.Update(customerId, new CustomerUpdateOptions()
        {
            Address = new AddressOptions()
            {
                City = city,
                Line1 = line1,
                Line2 = null,
                Country = country,
                State = state,
                PostalCode = postalcode
            },
            Shipping = new ShippingOptions()
            {
                Address = new AddressOptions()
                {
                    City = city,
                    Line1 = line1,
                    Country = country,
                    State = state,
                    PostalCode = postalcode
                },
                Name = name,
                Phone = "1-902-569-3246"
            }
        });
        
        return Redirect("/checkout/UpdateShippingAddress");
    }
    
    public IActionResult CreateCheckoutIndividualStockReq(string subscriptionType)
    {
        var domain = "https://localhost:7006";
        var customerId = _customerRetrievalService.HandleRetrieveCustomerId(User);
    
        var customerService = new CustomerService();
        var customer = customerService.Get(customerId);
    
        string findPrice = "";
    
        if (subscriptionType.Contains("Gold"))
        {
            if (String.IsNullOrEmpty(customer.Currency))
            {
                if (customer.Address is { Country: "CA" })
                {
                    findPrice = "price_1LzldCHVaJrn1f0GQx9Aiqmw";
                } else if (customer.Address is { Country: "US" })
                {
                    findPrice = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ";
                } else if (customer.Address is { Country: "GB" })
                {
                    findPrice = "price_1MD7ZhHVaJrn1f0Gz0DxnWdL";
                }
            }
            else if (customer.Currency.Equals("cad"))
            {
                findPrice = "price_1LzldCHVaJrn1f0GQx9Aiqmw";
            } else if (customer.Currency.Equals("usd"))
            {
                findPrice = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ";
            }  else if (customer.Currency.Equals("eur"))
            {
                findPrice = "price_1MD7ZhHVaJrn1f0Gz0DxnWdL";
            } 
        }
        else
        {
            findPrice = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ";
        }
        
        var options = new SessionCreateOptions
        {
            AutomaticTax = new SessionAutomaticTaxOptions() { Enabled = true },
            LineItems = new List<SessionLineItemOptions>()
            {
                new()
                {
                    Price = findPrice, 
                    Quantity = 1,
                },
            },
            Mode = "subscription",
            SuccessUrl = domain + "/success",
            CancelUrl = domain + "/cancel",
            Customer = customerId,
            SubscriptionData = new()
            {
                Description = subscriptionType
            },
            CustomerUpdate = new SessionCustomerUpdateOptions()
            {
                Shipping = "auto"
            }
        };
        var service = new SessionService();
        Session session = service.Create(options);
        
        Response.Headers.Add("Location", session.Url);
        
        return new StatusCodeResult(303);
    }

    [AllowAnonymous]
    [Route("/webhook")]
    [HttpPost]
    public async Task<IActionResult> Webhook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {
            var stripeEvent = EventUtility.ConstructEvent(json,
                Request.Headers["Stripe-Signature"], endpointSecret);

            // Handle the event
            if (stripeEvent.Type is 
                Events.InvoicePaid or 
                Events.InvoiceCreated or 
                Events.InvoiceFinalized or 
                Events.InvoiceUpdated )
            {
                var stripeInvoice = stripeEvent.Data.Object as Invoice;
                var dbSucceed = _invoices.AddToInvoicePaymentSucceeded(
                    new InvoicesDto()
                    {
                        CreatedDate = stripeEvent.Created,
                        Customer = stripeInvoice?.CustomerId,
                        Subscription = stripeInvoice?.Lines.Data[0].Subscription,
                        CustomerName = stripeInvoice?.CustomerName,
                        Paid = stripeInvoice?.Paid ?? false,
                        AmountDue = stripeInvoice?.AmountDue ?? 0L, // TODO: fill in the remainder of the table  columns
                        AmountPaid = stripeInvoice?.AmountPaid ?? 0L,
                        AmountRemaining = stripeInvoice?.AmountRemaining ?? 0L,
                        CollectionMethod = stripeInvoice?.CollectionMethod,
                        CustomerEmail = stripeInvoice?.CustomerEmail,
                        LineItemPriceId = stripeInvoice?.Lines.Data[0].Price.Id, // only one line item with a price id
                        HostedInvoiceUrl = stripeInvoice?.HostedInvoiceUrl
                    });
            } 
            else if (stripeEvent.Type is 
                     Events.CustomerSubscriptionCreated or 
                     Events.CustomerSubscriptionDeleted or 
                     Events.CustomerSubscriptionUpdated)
            {
                var stripeSubscription = stripeEvent.Data.Object as Subscription;
                var dbSucceed = _subscriptions.AddToInvoicePaymentSucceeded(
                    new SubscriptionsDto()
                    {
                        SubscriptionId = stripeSubscription?.Id,
                        CreatedDate = stripeEvent.Created,
                        Customer = stripeSubscription?.CustomerId,
                        Description = stripeSubscription?.Description,
                        Status = stripeSubscription?.Status,
                        CancelAt = stripeSubscription?.CancelAt,
                        CanceledAt = stripeSubscription?.CanceledAt,
                        CreatedAt = stripeSubscription?.Created,
                        CurrentPeriodEnd = stripeSubscription?.CurrentPeriodEnd,
                        CurrentPeriodStart = stripeSubscription?.CurrentPeriodStart
                    });
            }
            // ... handle other event types
            else
            {
                Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
            }

            return Ok();
        }
        catch (StripeException e)
        {
            return BadRequest();
        }
    }

    public IActionResult InvoiceTransactions()
    {
        var invoices = _invoices.Retrieve();
        // Display/Adapter
        var model = new InvoiceTransactions()
        {
            Invoices = invoices
        };
        return View(model);
    }
}

public class CheckoutResponseModel
{
    public Product Product { get; set; }
    public Price Price { get; set; }
}

public class CancelRequest
{
    public string subscriptionid { get; set; }
}