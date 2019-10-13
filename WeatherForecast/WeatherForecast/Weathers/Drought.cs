using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class Drought : WeatherType
    {
        public override string Description { get => "Sequía"; }

        public Drought() { }

        public override bool IsDrought()
        {
            return true;
        }
    }
}
