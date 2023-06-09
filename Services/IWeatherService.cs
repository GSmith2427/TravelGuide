using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherAsync(string location);
    }

}
