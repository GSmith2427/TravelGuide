using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TravelGuideAPI.Models;

namespace TravelGuideAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(Login model)
        {
            if (model.Username == "Admin" && model.Password == "Admin") // Replace with your credentials
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Username)
        };

                var userIdentity = new ClaimsIdentity(claims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "TravelGuide");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GuestLogin()
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, "Guest")
    };

            var userIdentity = new ClaimsIdentity(claims, "Guest Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "TravelGuide");
        }

    }

}