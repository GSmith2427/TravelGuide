using Newtonsoft.Json;
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
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "33942b936bmshcded9c9d9284ad8p1d1f0bjsn698a3615ff07");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com");
        }

        public async Task<CurrencyModel> GetCurrencyDataAsync(string baseCurrency)
        {
            var httpResponse = await _httpClient.GetAsync($"https://currency-conversion-and-exchange-rates.p.rapidapi.com/timeseries?start_date=2019-01-01&end_date=2019-01-02&from=USD&to=EUR%2CGBP");

        httpResponse.EnsureSuccessStatusCode();

        var currencyJson = await httpResponse.Content.ReadAsStringAsync();
        var currencyData = JsonConvert.DeserializeObject<CurrencyData>(currencyJson);

        return new CurrencyModel
        {
            BaseCurrency = currencyData.Base,
            ConversionRates = currencyData.Rates
        };
    }
    }

}
