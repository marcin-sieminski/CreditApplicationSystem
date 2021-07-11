using System;
using System.Threading.Tasks;

namespace CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates
{
    public interface ICurrencyExchangeRatesConnector
    {
        Task<CurrencyExchangeRatesTable> Fetch(string currencyCode, DateTime effectiveDate, string table);
    }
}