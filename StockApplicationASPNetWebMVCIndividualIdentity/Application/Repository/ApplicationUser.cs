using Microsoft.AspNetCore.Identity;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

public class ApplicationUser : IdentityUser
{
    public string? StripeCustomerId { get; set; }
}