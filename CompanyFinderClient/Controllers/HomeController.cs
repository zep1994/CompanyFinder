using CompanyFinderAPI.Models;
using CompanyFinderClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CompanyFinderClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string _apiKey = "demo"; // Replace with your AlphaVantage API key
        private static readonly string ApiBaseUrl = "https://www.alphavantage.co/query?function=OVERVIEW&symbol=";


        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("search")]
        public IActionResult Search()
        {
            return View("Search");
        }

        public async Task<IActionResult> GetCompanyOverview(string symbol)
        {
            var apiKey = "demo";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Company>(responseStream);

                // Return the data to the view for displaying in a form
                return View(data); // Assumes you have a corresponding View named "GetCompanyOverview"
            }
            return BadRequest();
        }

        //private async Task<Company> GetCompany(string symbol)
        //{
        //    var apiUrl = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey=";
        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.GetAsync(apiUrl + symbol + "&apikey=" + _apiKey);
        //        response.EnsureSuccessStatusCode();`

        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        var companyOverview = JsonConvert.DeserializeObject<Company>(responseBody);
        //        return companyOverview;
        //    }
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}