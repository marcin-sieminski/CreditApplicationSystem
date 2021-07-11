using System.Text.Json.Serialization;

namespace CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates
{
    public class Rate
    {
        [JsonPropertyName("no")] public string No { get; set; }
        [JsonPropertyName("effectiveDate")] public string EffectiveDate { get; set; }
        [JsonPropertyName("mid")] public float Mid { get; set; }
    }
}