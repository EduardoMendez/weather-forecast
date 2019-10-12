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
    }
}
