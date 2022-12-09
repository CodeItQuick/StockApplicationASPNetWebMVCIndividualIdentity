using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Adapters.Controllers.Home;

public class UpdateAddressResponse : PageModel
{
    public Address Address { get; set; } = new();

    public Dictionary<string, List<string>> States { get; } = new()
    {
        ["CA"] = new List<string>()
        {
            "BC",
            "AB",
            "MB",
            "SK",
            "ON",
            "QC",
            "NB",
            "NS",
            "PE",
            "NL",
            "YT",
            "NT",
            "NU",
        },
        ["US"] = new List<string>()
        {
            "AL",
            "AK",
            "AS",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FL",
            "GA",
            "GU",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "MP",
            "OH",
            "OK",
            "OR",
            "PA",
            "PR",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "VI",
            "WA",
            "WV",
            "WI",
            "WY"
        },
        ["GB"] = new List<string>()
        {
            "GB-CAM",
            "GB-CMA",
            "GB-DBY",
            "GB-DEV",
            "GB-DOR",
            "GB-ESX",
            "GB-ESS",
            "GB-GLS",
            "GB-HAM",
            "GB-HRT",
            "GB-KEN",
            "GB-LAN",
            "GB-LEC",
            "GB-LIN",
            "GB-NFK",
            "GB-NYK",
            "GB-NTT",
            "GB-OXF",
            "GB-SOM",
            "GB-STS",
            "GB-SFK",
            "GB-SRY",
            "GB-WAR",
            "GB-WSX",
            "GB-WOR"
        }
    };

    public string Name { get; set; }
}