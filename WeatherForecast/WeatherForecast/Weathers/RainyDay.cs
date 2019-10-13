using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    class RainyDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.RAIN; }
        public override string Description { get => "lluvia"; }
        public override double PrecipitacionLevel { get => precipitationLevel; }

        private readonly double precipitationLevel;

        public RainyDay() { }
        public RainyDay(int day, IEnumerable<Point> planets) : base(day) 
        { 
            precipitationLevel = new Triangle(planets).GetPerimeter();
        }
    }
}
