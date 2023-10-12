using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class Chart
    {

        public string[] Labels { get; set; }
        public double[] Prices { get; set; }
    }
}
