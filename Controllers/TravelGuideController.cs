using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelGuideAPI.Models;
using TravelGuideAPI.Services;

namespace TravelGuideAPI.Controllers
{
    [Authorize]
    public class TravelGuideController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly ICurrencyService _currencyService;
        private readonly IHotelService _hotelService; 

        public TravelGuideController(IWeatherService weatherService, ICurrencyService currencyService,IHotelService hotelService)
        {
            _weatherService = weatherService;
            _currencyService = currencyService;
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string location)
        {
            var weather = await _weatherService.GetWeatherAsync(location);
            var currency = await _currencyService.GetCurrencyDataAsync(weather.Location);
            HotelModel hotel = await _hotelService.GetHotelDataAsync(location);

            var model = new TravelGuideModel
            {
                Weather = weather,
                Currency = currency,
                Hotel = hotel,
            };

            return View(model);
        }
    }

}
