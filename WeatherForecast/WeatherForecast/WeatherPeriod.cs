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
        public int? PeakDay { get; set; }
        public WeatherType WeatherType { get; set; }

        public WeatherPeriod(WeatherType weatherType, IList<DayWeather> days)
        {
            WeatherType = weatherType;

            StartDay = days.OrderBy(d => d.Day).First().Day;
            EndDay = days.OrderByDescending(d => d.Day).First().Day;

            if (MustCalculatePeakDay(days))
                PeakDay = this.GetPeakDay(days).Day;
        }

        private bool MustCalculatePeakDay(IList<DayWeather> days)
        {
            return days.Aggregate(true, (accumulated, next) => accumulated && next.HasPrecipitations());
        }

        public bool HasPeakDay()
        {
            return PeakDay != null;
        }

        public DayWeather GetPeakDay(IList<DayWeather> days)
        {
            return days.OrderBy(x => x.PrecipitacionLevel()).First();
        }
    }
}
