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
        
        [Route("/create-checkout-session")]
        [HttpPost]
        public IActionResult CreateCheckoutReq()
        {
            var domain = "https://localhost:7006";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                        Price = "price_1LjPRXHVaJrn1f0GzqNdtNsW",
                        Quantity = 1,
                    },
                },
                Mode = "subscription",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        [Route("/Checkout/AddSubscription")]
        [HttpGet]
        public IActionResult Index()
        {
            var optionsProduct = new ProductCreateOptions
            {
                Name = "Starter Subscription",
                Description = "$12/Month subscription",
            };
            var serviceProduct = new ProductService();
            Product product = serviceProduct.Create(optionsProduct);
            Console.Write("Success! Here is your starter subscription product id: {0}\n", product.Id);

            var optionsPrice = new PriceCreateOptions
            {
                UnitAmount = 1200,
                Currency = "usd",
                Recurring = new PriceRecurringOptions
                {
                    Interval = "month",
                },
                Product = product.Id
            };
            var servicePrice = new PriceService();
            Price price = servicePrice.Create(optionsPrice);
            Console.Write("Success! Here is your starter subscription price id: {0}\n", price.Id);

            var model = new CheckoutResponseModel()
            {
                Product = product,
                Price = price,
            };

            return View(model);
        }

}

public class CheckoutResponseModel
{
    public Product Product { get; set; }
    public Price Price { get; set; }
}