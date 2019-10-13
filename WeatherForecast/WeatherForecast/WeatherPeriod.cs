﻿using System;
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
        public MeteorologicalDay PeakDay { get; set; }
        public WeatherType Weather { get; set; }

        public WeatherPeriod(WeatherType weatherType, IList<MeteorologicalDay> days)
        {
            Weather = weatherType;

            StartDay = days.OrderBy(d => d.Day).First().Day;
            EndDay = days.OrderByDescending(d => d.Day).First().Day;

            if (MustCalculatePeakDay())
                PeakDay = this.GetPeakDay(days);
        }

        private bool MustCalculatePeakDay()
        {
            return Weather.IsRain();
        }

        public bool HasPeakDay()
        {
            return PeakDay != null;
        }

        public MeteorologicalDay GetPeakDay(IList<MeteorologicalDay> days)
        {
            return days.OrderBy(x => x.CalculatePrecipitations()).First();
        }
    }
}
