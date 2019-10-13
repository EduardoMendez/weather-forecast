using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class DroughtDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.DROUGHT; }
        public override string Description { get => "Sequía"; }

        public DroughtDay(int day) : base(day) { }

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
