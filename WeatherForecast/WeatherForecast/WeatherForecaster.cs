﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherForecast.Weathers;

namespace WeatherForecast
{
    public class WeatherForecaster
    {
        public IEnumerable<Planet> Planets { get; set; }
        public Point Sun { get; set; }

        private int daysPerYear = 360;

        public WeatherForecaster(IEnumerable<Planet> planets, Point sun)
        {
            if (planets == null || !planets.Any() || sun == null)
                throw new ArgumentException("Planets and sun can not be null or empty");

            Planets = planets;
            Sun = sun;
        }

        public MeteorologicalDay WeatherForDay(int day)
        {
            var planetsPositions = Planets.Select(p => p.GetPositionForDay(day));

            if (PlanetsAndSunAligned(planetsPositions, Sun))
                return new MeteorologicalDay(day, new Drought(), planetsPositions);

            // Planets aligned but not aligned with the sun.
            if (PlanetsAligned(planetsPositions))
                return new MeteorologicalDay(day, new Optimal(), planetsPositions);

            if (new Triangle(planetsPositions).Contains(Sun))
                return new MeteorologicalDay(day, new Rain(), planetsPositions);

            return new MeteorologicalDay(day, new UnknownWeather(), planetsPositions);
        }

        public IEnumerable<MeteorologicalDay> GetDayWeatherForecastForYears(int years)
        {
            var days = new List<MeteorologicalDay>();

            for (int i = 0; i < (daysPerYear * years); i++)
            {
                days.Add(WeatherForDay(i));
            }

            return days;
        }

        public IEnumerable<WeatherPeriod> GetWeatherPeriodsForecastForYears(int years)
        {
            var weatherPeriods = new List<WeatherPeriod>();
            var periodDays = new List<MeteorologicalDay>();

            var day = this.WeatherForDay(0);
            var currentWeather = day.Weather;
            periodDays.Add(day);

            for (int i = 1; i < (daysPerYear * years); i++)
            {
                day = this.WeatherForDay(i);

                if (!day.Weather.IsTheSameWeatherType(currentWeather))
                {
                    weatherPeriods.Add(new WeatherPeriod(currentWeather, periodDays));
                    periodDays.Clear();

                    currentWeather = day.Weather;
                }

                periodDays.Add(day);
            }

            // We add the last period.
            weatherPeriods.Add(new WeatherPeriod(day.Weather, periodDays));

            return weatherPeriods;
        }

        public bool PlanetsAndSunAligned(IEnumerable<Point> planetsPositions, Point sun)
        {
            var points = new List<Point>(planetsPositions);
            points.Add(sun);

            return Collinearity.AreCollinear(points);
        }

        public bool PlanetsAligned(IEnumerable<Point> planetsPositions)
        {
            return Collinearity.AreCollinear(planetsPositions);
        }
    }
}
