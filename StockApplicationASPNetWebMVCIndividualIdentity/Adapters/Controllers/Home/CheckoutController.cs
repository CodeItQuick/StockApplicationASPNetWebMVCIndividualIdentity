using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public CheckoutController(
            ILogger<CheckoutController> logger, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            StripeConfiguration.ApiKey = configuration["StripeAPIKey"];
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
            var userIdentity = _userManager.GetUserAsync(User).Result;
            var customerId = userIdentity.StripeCustomerId;

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
            } else if (subscriptionType.Equals("Silver"))
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
            
            return Redirect("/");
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