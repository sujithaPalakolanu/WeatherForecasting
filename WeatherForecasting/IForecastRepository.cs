using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecasting.Models;

namespace WeatherForecasting
{
    public interface IForecastRepository
    {
        public  Task<OpenWeatherApiResponse> GetWeatherReportasync(string city);
    }
}
