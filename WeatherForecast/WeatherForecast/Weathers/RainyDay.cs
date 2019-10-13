using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    class RainyDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.RAIN; }
        public override string Description { get => "lluvia"; }
        private readonly double precipitationLevel;

        public RainyDay(int day, IEnumerable<Point> planets) : base(day) 
        { 
            precipitationLevel = new Triangle(planets).GetPerimeter();
        }

        public override bool HasPrecipitations()
        {
            return true;
        }

        public override double PrecipitacionLevel()
        {
            return precipitationLevel;
        }
    }
}
