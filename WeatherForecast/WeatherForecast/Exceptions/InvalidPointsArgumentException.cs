using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Exceptions
{
    public class InvalidPointsArgumentException : Exception
    {
        public InvalidPointsArgumentException(string message) : base(message) { }
    }
}
