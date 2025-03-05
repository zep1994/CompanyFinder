using CompanyFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CompanyFinderAPI.Controllers
{
    [ApiController]
    [Route("api/chart")]
    public class ChartController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string baseUrl = "https://www.alphavantage.co/query";
        private readonly string apiKey = "FLW875WO7JXEYS29";

        public ChartController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("/get")]
        public IActionResult StockChart()
        {
            return View("~/Views/Chart/StockChart.cshtml");
        }

        [HttpGet("GetChartData")]
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
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var data = await JsonSerializer.DeserializeAsync<ChartResponse>(responseStream, options);

                        // Process the data for the chart
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

        private ChartData ProcessDataForChart(ChartResponse chartResponse)
        {
            var labels = new List<string>();
            var prices = new List<double>();

            // Loop over the data from the "Monthly Time Series"
            foreach (var item in chartResponse.TimeSeriesDaily)
            {
                labels.Add(item.Key);
                prices.Add(double.Parse(item.Value.Close));
            }

            // Reverse the arrays to have chronological order (oldest first)
            labels.Reverse();
            prices.Reverse();

            return new ChartData
            {
                Labels = labels.ToArray(),
                Prices = prices.ToArray()
            };
        }
    }
}
