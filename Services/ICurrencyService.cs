using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyModel> GetCurrencyDataAsync(string baseCurrency);
    }

}
