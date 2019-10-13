using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class UnknownDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.UNKNOWN; }
        public override string Description { get => "Desconocido"; }
        public override double PrecipitacionLevel { get => 0; }

        public UnknownDay() { }
        public UnknownDay(int day) : base(day) { }

    }
}
