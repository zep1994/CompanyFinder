using CompanyFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Reflection.Emit;


namespace CompanyFinderAPI.Controllers
{


    public class ChartController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string baseUrl = "https://www.alphavantage.co/query";
        private readonly string apiKey = "FLW875WO7JXEYS29";

        public ChartController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("/chart")]
        [HttpGet]
        public async Task<IActionResult> GetChartData()
        {
            try
            {
                var requestUrl = $"{baseUrl}?function=TIME_SERIES_MONTHLY&symbol=IBM&apikey={apiKey}";

                using (var client = _clientFactory.CreateClient())
                using (var response = await client.GetAsync(requestUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseStream = await response.Content.ReadAsStreamAsync();
                        var data = await JsonSerializer.DeserializeAsync<ChartResponse>(responseStream);

                        // Process the data and prepare it for the line graph
                        var chartData = ProcessDataForChart(data);

                        return Ok(chartData);
                    }
                    else
                    {
                        return BadRequest("Failed to fetch data from Alpha Vantage API");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
         private Chart ProcessDataForChart(ChartResponse chartResponse)
        {
           

            var labels = new List<string>();
            var prices = new List<double>();

            foreach (var item in chartResponse.MonthlyTimeSeries)
            {
                // Assuming that the date is the key in the dictionary
                labels.Add(item.Key);
                prices.Add(double.Parse(item.Value.Close));
            }

            var chartData = new Chart
            {
                Labels = labels.ToArray(),
                Prices = prices.ToArray()
            };

            return chartData;
        }
    }



}
