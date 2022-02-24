using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecasting.Models
{
    public class WeatherReport
    {
        [Required]
        [Display(Name = "City Name: ") ]
        public string  City { get; set; }

        [Display(Name = "Temprature: ")]
        public float  Temprature { get; set; }

        [Display(Name = "Humidity: ")]
        public int Humidity { get; set; }

        [Display(Name = "Pressure: ")]
        public int Pressure{ get; set; }

        [Display(Name = "Wind Speed: ")]
        public float Wind  { get; set; }

        [Display(Name = "Weather Condition: ")]
        public string Weather { get; set; }

    }
}
