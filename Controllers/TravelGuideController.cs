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

        public TravelGuideController(IWeatherService weatherService, ICurrencyService currencyService)
        {
            _weatherService = weatherService;
            _currencyService = currencyService;
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
            var currency = await _currencyService.GetCurrencyDataAsync(weather.Country);

            var model = new TravelGuideModel
            {
                Weather = weather,
                Currency = currency
            };

            return View(model);
        }
    }

}
