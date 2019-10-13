using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class OptimalDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.OPTIMAL; }
        public override string Description { get => "Optimo"; }

        public OptimalDay(int day) : base(day) { }

        public override bool HasPrecipitations()
        {
            return false;
        }

        public override double PrecipitacionLevel()
        {
            return 0;
        }
    }
}
