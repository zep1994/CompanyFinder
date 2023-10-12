using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class ChartResponse
    {
        [JsonPropertyName("Monthly Time Series")]
        public Dictionary<string, DailyTimeSeries> TimeSeriesDaily { get; set; }
    }
}
