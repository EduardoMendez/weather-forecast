using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Weathers
{

    public abstract class WeatherType
    {
        public virtual string Description { get; }

        public WeatherType() { }

        public virtual double CalculatePrecipitations(IEnumerable<Point> planets)
        {
            return 0;
        }

        public virtual bool IsRain()
        {
            return false;
        }

        public virtual bool IsDrought()
        {
            return false;
        }

        public virtual bool IsOptimal()
        {
            return false;
        }

        public virtual bool IsUnknown()
        {
            return false;
        }
    }
}
