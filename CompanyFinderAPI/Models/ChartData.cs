using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class ChartData
    {
        public string[] Labels { get; set; }
        public double[] Prices { get; set; }
    }
}
