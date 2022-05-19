using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMap.WeatherInterface
{
    public interface IWeatherService
    {

        Task<CurrentWeather> GetCurrentWeather(String location);


        Task<LocationForecast> GetForecast(String location);


    }
}
