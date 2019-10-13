using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public static class Extensions
    {
        public static double ToRadians(this double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public static bool IsBetween(this double number, double min, double max)
        {
            return (number >= min) && (number <= max);
        }
    }
}
