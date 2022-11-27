using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.CheckoutData.InvoicePaymentSucceeded;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
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

    public CheckoutController(
        ILogger<CheckoutController> logger,
        IConfiguration configuration,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
        StripeConfiguration.ApiKey = configuration["StripeAPIKey"];
        _customerRetrievalService =
            new CustomerRetrievalService<CheckoutController>(logger, userManager, configuration);
        _invoices = new InvoicesService(new UnitOfWork());
        _subscriptions = new SubscriptionsService(new UnitOfWork());
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

        var subscriptionsAttached = new List<SessionLineItemOptions>();
        var subscriptionDescription = "unknown";

        if (subscriptionType.Equals("Gold"))
        {
            subscriptionsAttached.Add(
                new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ",
                    Quantity = 1,
                });
        }
        else if (subscriptionType.Equals("Silver"))
        {
            subscriptionsAttached.Add(
                new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    // Price = "price_1LjPGMHVaJrn1f0GsKEBN6g6",
                    // Quantity = 2,
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        Product = "prod_MSJuHWVPzcmaaf",
                        Currency = "USD",
                        Recurring = new SessionLineItemPriceDataRecurringOptions()
                        {
                            Interval = "month"
                        },
                        TaxBehavior = "inclusive",
                        UnitAmount = 1200L
                    },
                    Quantity = 2
                });
        }

        var options = new SessionCreateOptions
        {
            AutomaticTax = new SessionAutomaticTaxOptions() { Enabled = true },
            LineItems = subscriptionsAttached,
            Mode = "subscription",
            SuccessUrl = domain + "/success",
            CancelUrl = domain + "/cancel",
            Customer = customerId
        };
        var service = new SessionService();
        Session session = service.Create(options);

        Response.Headers.Add("Location", session.Url);
        return new StatusCodeResult(303);
    }

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

    public IActionResult CreateCheckoutIndividualStockReq(string subscriptionType)
    {
        var domain = "https://localhost:7006";
        var customerId = _customerRetrievalService.HandleRetrieveCustomerId(User);

        var subscriptionsAttached = new List<SessionLineItemOptions>();

        if (subscriptionType.Contains("Gold"))
        {
            subscriptionsAttached.Add(
                new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1LjkmDHVaJrn1f0G9Cu2gJyJ",
                    Quantity = 1,
                });
        }
        else if (subscriptionType.Contains("Silver"))
        {
            subscriptionsAttached.Add(
                new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1LjPGMHVaJrn1f0GsKEBN6g6",
                    Quantity = 1,
                    // TaxRates =
                    // Currency = 
                    // Specify the PriceData instead of above
                    // PriceData = new SessionLineItemPriceDataOptions()
                    // {
                    //     Product = "prod_MSJuHWVPzcmaaf",
                    //     Currency = "USD",
                    //     Recurring = new SessionLineItemPriceDataRecurringOptions()
                    //     {
                    //         Interval = "month"
                    //     },
                    //     TaxBehavior = "inclusive",
                    //     UnitAmount = 1200L
                    // },
                    // Quantity = 2
                });
        }

        var options = new SessionCreateOptions
        {
            AutomaticTax = new SessionAutomaticTaxOptions() { Enabled = true },
            LineItems = subscriptionsAttached,
            Mode = "subscription",
            SuccessUrl = domain + "/success",
            CancelUrl = domain + "/cancel",
            Customer = customerId,
            SubscriptionData = new()
            {
                Description = subscriptionType
            }
        };
        var service = new SessionService();
        Session session = service.Create(options);

        Response.Headers.Add("Location", session.Url);
        return new StatusCodeResult(303);
    }
    // This is your Stripe CLI webhook secret for testing your endpoint locally.

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