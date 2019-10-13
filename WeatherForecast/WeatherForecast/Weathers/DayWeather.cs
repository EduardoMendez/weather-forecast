using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public enum WeatherType
    {
        DROUGHT,
        RAIN,
        OPTIMAL,
        UNKNOWN
    }

    public abstract class DayWeather
    {
        public int Day { get; set; }
        public virtual WeatherType Weather { get; }
        public virtual string Description { get; }
        public virtual double PrecipitacionLevel { get; }

        public DayWeather() { }

        public DayWeather(int day)
        { 
            Day = day; 
        }

        public bool HasTheSameWeather(DayWeather day)
        {
            return this.Weather == day.Weather;
        }

    }
}
