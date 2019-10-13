using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class OptimalDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.OPTIMAL; }
        public override string Description { get => "Optimo"; }
        public override double PrecipitacionLevel { get => 0; }

        public OptimalDay() { }
        public OptimalDay(int day) : base(day) { }
    }
}
