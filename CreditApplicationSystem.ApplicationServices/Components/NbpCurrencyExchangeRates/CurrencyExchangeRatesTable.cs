using System.Text.Json.Serialization;

namespace CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates
{
    public class CurrencyExchangeRatesTable
    {
        [JsonPropertyName("table")] public string Table { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("rates")] public Rate[] Rates { get; set; }
    }
}