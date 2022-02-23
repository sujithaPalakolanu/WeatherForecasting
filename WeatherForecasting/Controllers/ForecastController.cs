using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecasting.Models;

namespace WeatherForecasting.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IForecastRepository _forecastRepository;

        public ForecastController(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }
        public IActionResult SearchByCity()
        
        {
            var model = new SearchByCity();
            return View(model);
        }

        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("WeatherReport", "Forecast", new { city = model.City });
            }
            return View(model);
        }

        public async Task<IActionResult> WeatherReport(string city)
        {
            var weatherResponse = await _forecastRepository.GetWeatherReportasync(city);
            WeatherReport viewModel = new WeatherReport();
            if (weatherResponse != null)
            {
                viewModel.City = weatherResponse.name;
                viewModel.Humidity = weatherResponse.main.humidity;
                viewModel.Pressure = weatherResponse.main.pressure;
                viewModel.Temprature = weatherResponse.main.temp;
                viewModel.Wind = weatherResponse.wind.speed;
                viewModel.Weather = weatherResponse.weather[0].main;
            }
            else
            {
                return 
            }
            return View(viewModel);
        }
    }
}
