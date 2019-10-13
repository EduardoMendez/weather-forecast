using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastAPI.Models
{
    public class DayWeather
    {
        public long Id { get; set; }
        public int Day { get; set; }
        public string Weather { get; set; }
    }
}
