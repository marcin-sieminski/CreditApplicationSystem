using CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CreditApplicationSystem.Tests
{
    [TestClass]
    public class CurrencyExchangeRatesConnectorTests
    {
        [TestMethod]
        [Priority(1)]
        public void CurrencyExchangeRatesConnector_Returns_Valid_Exchange_Rates()
        {
            var connector = new CurrencyExchangeRatesConnector();
            var expected1 = new CurrencyExchangeRatesTable
            {
                Table = "A",
                Currency = "euro",
                Code = "EUR",
                Rates = new Rate[]
                {
                    new Rate()
                    {
                        No = "131/A/NBP/2021",
                        EffectiveDate = "2021-07-09",
                        Mid = 4.5467f
                    }
                }
            };
            var expected2 = new CurrencyExchangeRatesTable
            {
                Table = "A",
                Currency = "dolar amerykański",
                Code = "USD",
                Rates = new Rate[]
                {
                    new Rate()
                    {
                        No = "127/A/NBP/2021",
                        EffectiveDate = "2021-07-05",
                        Mid = 3.7979f
                    }
                }
            };

            var result1 = connector.Fetch("EUR", new DateTime(2021, 7, 9)).Result;
            var result2 = connector.Fetch("USD", new DateTime(2021, 7, 5)).Result;

            Assert.AreEqual(expected1.Rates[0].Mid, result1.Rates[0].Mid);
            Assert.AreEqual(expected2.Rates[0].Mid, result2.Rates[0].Mid);
        }
    }
}
