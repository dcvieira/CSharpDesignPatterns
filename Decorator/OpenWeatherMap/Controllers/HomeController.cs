using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Models;
using OpenWeatherMap.WeatherInterface;


namespace OpenWeatherMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }


        public async Task<IActionResult> Index(string location = "Chicago")
        {
            CurrentWeather conditions = await _weatherService.GetCurrentWeather(location);
            return View(conditions);
        }



        public async Task<IActionResult> Forecast(string location = "Chicago")
        {
            LocationForecast forecast = await _weatherService.GetForecast(location);
            return View(forecast);
        }

        public IActionResult ApiKey()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
