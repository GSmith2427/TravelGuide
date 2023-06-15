using Newtonsoft.Json;
using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly HttpClient _httpClient;

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "33942b936bmshcded9c9d9284ad8p1d1f0bjsn698a3615ff07");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "hotels4.p.rapidapi.com");
        }

        public async Task<HotelModel> GetHotelDataAsync(string location)
        {
           var httpResponse = await _httpClient.GetAsync($"https://hotels4.p.rapidapi.com/locations/v3/search?q=new%20york&locale=en_US&langid=1033&siteid=300000001");

           httpResponse.EnsureSuccessStatusCode();  
            

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var hotelResponse = JsonConvert.DeserializeObject<HotelModel>(jsonResponse);

            return hotelResponse;

            
        }
    }

}
