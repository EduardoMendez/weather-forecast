using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;
using static WeatherForecast.WeatherForecaster;
using System.Linq;

namespace WeatherForecast
{
    public class WeatherPeriod
    {
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public DayWeather PeakDay { get; set; }
        public WeatherType WeatherType { get; set; }

        public WeatherPeriod(WeatherType weatherType, IList<DayWeather> days)
        {
            WeatherType = weatherType;

            StartDay = days.OrderBy(d => d.Day).First().Day;
            EndDay = days.OrderByDescending(d => d.Day).First().Day;

            bool mustCalculatePeakDay = weatherType == WeatherType.RAIN;

            if (mustCalculatePeakDay)
                PeakDay = this.GetPeakDay(days);
        }

        public bool HasPeakDay()
        {
            return PeakDay != null;
        }

        public DayWeather GetPeakDay(IList<DayWeather> days)
        {
            return days.OrderBy(x => x.PrecipitacionLevel).First();
        }
    }
}
