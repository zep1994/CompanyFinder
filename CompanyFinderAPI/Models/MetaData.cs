using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class MetaData
    {
        [JsonPropertyName("2.Symbol")]
        public string Symbol { get; set; }
    }
}
