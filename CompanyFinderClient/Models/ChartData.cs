using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class ChartData
    {
        public string[] Dates { get; set; }

        [JsonPropertyName("4. close")]
        public double[] Prices { get; set; }
    }
}
