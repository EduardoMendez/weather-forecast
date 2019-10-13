using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.Weathers;

namespace WeatherForecast
{
    public class MeteorologicalDay
    {
        public int Day { get; set; }
        public WeatherType Weather { get; }
        public Point Sun { get; }
        public IEnumerable<Point> PlanetsPositions { get; set; }

        public MeteorologicalDay() { }

        public MeteorologicalDay(int day, WeatherType weatherType, IEnumerable<Point> planets)
        {
            Day = day;
            Weather = weatherType;
            PlanetsPositions = planets;
        }

        public bool HasTheSameWeather(MeteorologicalDay day)
        {
            return this.Weather.IsTheSameWeatherType(day.Weather);
        }

        public double CalculatePrecipitations()
        {
            return this.Weather.CalculatePrecipitations(PlanetsPositions);
        }


        public bool IsRain()
        {
            return Weather.IsRain();
        }

        public bool IsDrought()
        {
            return Weather.IsDrought();
        }

        public bool IsOptimal()
        {
            return Weather.IsOptimal();
        }

        public bool IsUnknown()
        {
            return Weather.IsUnknown();
        }
    }
}
