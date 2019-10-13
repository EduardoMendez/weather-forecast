using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Weathers
{
    public class Rain : WeatherType
    {
        public override string Description { get => "Lluvia"; }

        public Rain() { }

        public override bool IsRain()
        {
            return true;
        }

        public override double CalculatePrecipitations(IEnumerable<Point> planets)
        {
            return new Triangle(planets).GetPerimeter();
        }


    }
}
