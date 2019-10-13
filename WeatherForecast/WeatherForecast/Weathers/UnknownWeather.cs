using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class UnknownWeather : WeatherType
    {
        public override string Description { get => "Desconocido"; }

        public UnknownWeather() { }

        public override bool IsUnknown()
        {
            return true;
        }

    }
}
