using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class UnknownDay : DayWeather
    {
        public override WeatherType Weather { get => WeatherType.UNKNOWN; }
        public override string Description { get => "Desconocido"; }

        public UnknownDay() { }
        public UnknownDay(int day) : base(day) { }

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
