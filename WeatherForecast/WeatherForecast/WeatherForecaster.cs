using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForecast
{
    public class WeatherForecaster
    {
        public enum Weather
        {
            DROUGHT,
            RAIN,
            OPTIMAL,
            UNKNOWN
        }

        public IEnumerable<Planet> Planets { get; set; }
        public Point Sun { get; set; }

        public WeatherForecaster(IEnumerable<Planet> planets, Point sun)
        {
            Planets = planets;
            Sun = sun;
        }

        public Weather WeatherForDay(int day)
        {
            var planetsPositions = Planets.Select(p => p.GetPositionForDay(day));

            if (PlanetsAndSunAligned(planetsPositions, Sun))
                return Weather.DROUGHT;

            // Planets aligned but not aligned with the sun.
            if (PlanetsAligned(planetsPositions))
                return Weather.OPTIMAL;

            if (new Triangle(planetsPositions).Contains(Sun))
                return Weather.RAIN;

            return Weather.UNKNOWN;
        }

        public bool PlanetsAndSunAligned(IEnumerable<Point> planetsPositions, Point sun)
        {
            var points = new List<Point>(planetsPositions);
            points.Add(sun);

            return CalculationUtils.AreCollinear(points);
        }

        public bool PlanetsAligned(IEnumerable<Point> planetsPositions)
        {
            return CalculationUtils.AreCollinear(planetsPositions);
        }
    }
}
