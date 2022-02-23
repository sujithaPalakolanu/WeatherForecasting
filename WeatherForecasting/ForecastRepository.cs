using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecasting.Models;

namespace WeatherForecasting
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly IConfiguration _config;
        public ForecastRepository( IConfiguration config)
        {
            _config = config;
        }

        public async Task<OpenWeatherApiResponse> GetWeatherReportasync(string city)
        {
            var apiKey = _config["ApiKey"];

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={apiKey}");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<JToken>(res);

                    return jsonResponse.ToObject<OpenWeatherApiResponse>();
                }
                return null;
            }
        }
    }
}
