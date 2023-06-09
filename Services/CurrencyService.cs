using Newtonsoft.Json.Linq;
using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyModel> GetCurrencyDataAsync(string baseCurrency)
        {
            var response = await _httpClient.GetAsync($"https://api.currencyapi.com/v3/latest?apikey=dZzUGTrUZ0oYbdh0YTZe2cya5GOiJAWB0LhWoTEY&currencies=EUR,USD,JPY&base={baseCurrency}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var currencyJson = JObject.Parse(data);

            return new CurrencyModel
            {
                BaseCurrency = currencyJson["base"].ToString(),
                ConversionRates = new Dictionary<string, double>
            {
                { "EUR", double.Parse(currencyJson["rates"]["EUR"].ToString()) },
                { "USD", double.Parse(currencyJson["rates"]["USD"].ToString()) },
                { "JPY", double.Parse(currencyJson["rates"]["JPY"].ToString()) },
            }
            };
        }
    }

}
