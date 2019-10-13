using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Weathers
{
    public class Drought : WeatherType
    {
        public override string Description { get => "Sequia"; }

        public Drought() { }

        public override bool IsDrought()
        {
            return true;
        }
    }
}
