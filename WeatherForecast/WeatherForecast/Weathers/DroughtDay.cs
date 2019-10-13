using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class DroughtDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.DROUGHT; }
        public override string Description { get => "Sequía"; }
        public override double PrecipitacionLevel { get => 0; }

        public DroughtDay() { }

        public DroughtDay(int day) : base(day) { }
    }
}
