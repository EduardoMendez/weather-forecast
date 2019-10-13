using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast;

namespace WeatherForecastAPI
{
    public class Galaxy
    {
        public IEnumerable<Planet> Planets { get; set; }
        public Point Sun { get; set; }

    }
}
