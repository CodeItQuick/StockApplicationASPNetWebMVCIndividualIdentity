using Microsoft.AspNetCore.Mvc;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.DBService;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Models;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;
using Stripe;
using Stripe.Checkout;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Checkout;

public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger, IConfiguration configuration)
        {
            _logger = logger;
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
        [Route("/create-checkout-session")]
        [HttpPost]
        public IActionResult CreateCheckoutReq(string subscriptionType)
        {
            var domain = "https://localhost:7006";
            var subscriptionsAttached = new List<SessionLineItemOptions>();
            
            if (subscriptionType.Equals("Gold"))
            {
                subscriptionsAttached.Add(new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1Ljj4wHVaJrn1f0GHOuO8y4N",
                    Quantity = 1,
                });
            } else if (subscriptionType.Equals("Silver"))
            {
                subscriptionsAttached.Add(
                new SessionLineItemOptions
                {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1LjPGMHVaJrn1f0GsKEBN6g6",
                    Quantity = 2,
                });
            }
            var options = new SessionCreateOptions
            {
                AutomaticTax = new SessionAutomaticTaxOptions() { Enabled = true },
                LineItems = subscriptionsAttached,
                Mode = "subscription",
                SuccessUrl = domain + "/success",
                CancelUrl = domain + "/cancel",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


}

public class CheckoutResponseModel
{
    public Product Product { get; set; }
    public Price Price { get; set; }
}