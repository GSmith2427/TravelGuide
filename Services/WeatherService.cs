using Newtonsoft.Json.Linq;
using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherModel> GetWeatherAsync(string location)
        {
            var response = await _httpClient.GetAsync($"http://api.weatherapi.com/v1/current.json?key=94e921daa7ee44d7b7f93124230506&q={location}&aqi=no");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var weatherJson = JObject.Parse(data);

            return new WeatherModel
            {
                Location = weatherJson["location"]["name"].ToString(),
                Temperature = double.Parse(weatherJson["current"]["temp_c"].ToString()),
                Condition = weatherJson["current"]["condition"]["text"].ToString(),
                Country = weatherJson["location"]["country"].ToString()
            };
        }
    }

}
