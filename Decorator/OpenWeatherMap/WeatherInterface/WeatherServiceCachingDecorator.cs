﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMap.WeatherInterface
{
    public class WeatherServiceCachingDecorator : IWeatherService
    {


        public WeatherServiceCachingDecorator(IWeatherService weatherService, IMemoryCache cache)
        {
            _innerWeatehrService = weatherService;
            _cache = cache;
        }

        private IMemoryCache _cache;
        private IWeatherService _innerWeatehrService;


        public async Task<CurrentWeather> GetCurrentWeather(string location)
        {
            string cacheKey = $"WeatherConditions::{location}";
            if ( _cache.TryGetValue<CurrentWeather>(cacheKey, out var currentWeather))
            {
                return currentWeather;
            }
            else
            {
                var currentConditions = await _innerWeatehrService.GetCurrentWeather(location);
                _cache.Set<CurrentWeather>(cacheKey, currentConditions, TimeSpan.FromMinutes(30));
                return currentConditions;
            }
            
        }



        public async Task<LocationForecast> GetForecast(string location)
        {
            string cacheKey = $"WeatherForecast::{location}";
            if (_cache.TryGetValue<LocationForecast>(cacheKey, out var forecast))
            {
                return forecast;
            }
            else
            {
                var locationForecast = await _innerWeatehrService.GetForecast(location);
                _cache.Set<LocationForecast>(cacheKey, locationForecast, TimeSpan.FromMinutes(30));
                return locationForecast;

            }
        }

    }
}
