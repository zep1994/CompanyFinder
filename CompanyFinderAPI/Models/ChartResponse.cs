using Microsoft.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class ChartResponse
    {
        [JsonPropertyName("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonPropertyName("Monthly Time Series")]
        public Dictionary<string, TimeSeriesMonthly> MonthlyTimeSeries { get; set; }

    }
}