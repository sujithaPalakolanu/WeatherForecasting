using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecasting.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage = "Please enter city name") ]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Please enter valid name.")]
        [Display(Name = "City Name:")]
        public string City { get; set; }

    }
}
