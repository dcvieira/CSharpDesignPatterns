using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMap.WeatherInterface
{
    public class WeatherServiceLoggingDecorator : IWeatherService
    {
        public WeatherServiceLoggingDecorator(IWeatherService weatherService, ILogger<WeatherServiceLoggingDecorator> logger)
        {
            _innerWeatherService = weatherService;
            _logger = logger;
        }


        private IWeatherService _innerWeatherService;
        private ILogger<WeatherServiceLoggingDecorator> _logger;

        public async Task<CurrentWeather> GetCurrentWeather(string location)
        {
            var sw = Stopwatch.StartNew();
            var currentWeather = await _innerWeatherService.GetCurrentWeather(location);
            sw.Stop();
            var elapsedMillis = sw.ElapsedMilliseconds;
            _logger.LogWarning("Retrieved weather data for {location} - Elapsed ms: {} {@currentWeather}", location, elapsedMillis, currentWeather);

            return currentWeather;
        }

        public Task<LocationForecast> GetForecast(string location)
        {
            return _innerWeatherService.GetForecast(location);
        }
    }
}
