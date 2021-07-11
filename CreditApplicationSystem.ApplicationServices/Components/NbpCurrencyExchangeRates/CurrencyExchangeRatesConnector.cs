using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates
{
    public class CurrencyExchangeRatesConnector : ICurrencyExchangeRatesConnector
    {
        private readonly string _baseUrl = "http://api.nbp.pl/api/exchangerates/rates/";
        private readonly DateTime _currencyDataBeginning = new DateTime(2002, 1, 2);
        private readonly RestClient _restClient;

        public CurrencyExchangeRatesConnector()
        {
            _restClient = new RestClient(_baseUrl);
        }

        public async Task<CurrencyExchangeRatesTable> Fetch(string currencyCode, DateTime date, string table = "A")
        {
            var effectiveDate = (date < _currencyDataBeginning ? DateTime.UtcNow : date);
            var year = effectiveDate.Year.ToString();
            var month = effectiveDate.Month < 10 ? $"0{effectiveDate.Month}" : effectiveDate.Month.ToString();
            var day = effectiveDate.Day < 10 ? $"0{effectiveDate.Day}" : effectiveDate.Day.ToString();
            var requestDateParameter = $"{year}-{month}-{day}";
            
            var request = new RestRequest($"{table}/{currencyCode}/{requestDateParameter}/", Method.GET);

            request.AddParameter("format", "json");
            var result = await _restClient.ExecuteAsync(request);
            var currencyExchangeRateTable = JsonConvert.DeserializeObject<CurrencyExchangeRatesTable>(result.Content);
            return currencyExchangeRateTable;
        }
    }
}