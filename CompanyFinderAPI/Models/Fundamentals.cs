using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyFinderAPI.Models
{
    public class Fundamentals
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("annualReports")]
        public List<AnnualReports>? AnnualReports { get; set; }

        [JsonPropertyName("annualEarnings")]
        public List<AnnualEarnings>? AnnualEarnings { get; set; }

        [JsonPropertyName("Global Quote")]
        public List<GlobalQuote>? GlobalQuote { get; set; }
    }
    
    public class GlobalQuote
        {
            [JsonPropertyName("02. open")]
            public string? Open { get; set; }

            [JsonPropertyName("03. high")]
            public string? High { get; set; }

            [JsonPropertyName("04. low")]
            public string? Low { get; set; }

            [JsonPropertyName("05. price")]
            public string? Price { get; set; }

            [JsonPropertyName("06. volume")]
            public string? Volume { get; set; }

            [JsonPropertyName("07. latest trading day")]
            public string? LatestTradingDay { get; set; }

            [JsonPropertyName("08. previous close")]
            public string? PreviousClose { get; set; }

            [JsonPropertyName("09. change")]
            public string? Change { get; set; }

            [JsonPropertyName("10. change percent")]
            public string? ChangePercent { get; set; }
        }

        public class AnnualReports
        {
            [JsonPropertyName("operatingIncome")]
            public string? OperatingIncome { get; set; }

            [JsonPropertyName("fiscalDateEnding")]
            public string? FiscalDateEnding { get; set; }

            [JsonPropertyName("grossProfit")]
            public string? GrossProfit { get; set; }

            [JsonPropertyName("totalRevenue")]
            public string? TotalRevenue { get; set; }

            [JsonPropertyName("netIncome")]
            public string? NetIncome { get; set; }

            [JsonPropertyName("cashflowFromInvestment")]
            public string? CashflowFromInvestment { get; set; }

            [JsonPropertyName("cashflowFromFinancing")]
            public string? CashflowFromFinancing { get; set; }

            [JsonPropertyName("changeInOperatingLiabilities")]
            public string? ChangeInOperatingLiabilities { get; set; }

            [JsonPropertyName("changeInOperatingAssets")]
            public string? ChangeInOperatingAssets { get; set; }

            [JsonPropertyName("industry")]
            public string? Industry { get; set; }

            [JsonPropertyName("operatingCashflow")]
            public string? OperatingCashflow { get; set; }

            [JsonPropertyName("profitLoss")]
            public string? ProfitLoss { get; set; }

            [JsonPropertyName("capitalExpenditures")]
            public string? CapitalExpenditures { get; set; }

            [JsonPropertyName("changeInReceivables")]
            public string? ChangeInReceivables { get; set; }

            [JsonPropertyName("changeInInventory")]
            public string? ChangeInInventory { get; set; }

        }


        public class AnnualEarnings
        {
            [JsonPropertyName("fiscalDateEnding")]
            public string? FiscalDateEnding { get; set; }

            [JsonPropertyName("reportedEPS")]
            public string? ReportedEPS { get; set; }
        }
  }