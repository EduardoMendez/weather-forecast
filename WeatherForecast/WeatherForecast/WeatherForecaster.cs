using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForecast
{
    public class WeatherForecaster
    {
        public IEnumerable<Planet> Planets { get; set; }
        public Point Sun { get; set; }

        public WeatherForecaster(IEnumerable<Planet> planets, Point sun)
        {
            Planets = planets;
            Sun = sun;
        }

        public DayWeather WeatherForDay(int day)
        {
            var planetsPositions = Planets.Select(p => p.GetPositionForDay(day));

            if (PlanetsAndSunAligned(planetsPositions, Sun))
                return new DroughtDay(day);

            // Planets aligned but not aligned with the sun.
            if (PlanetsAligned(planetsPositions))
                return new OptimalDay(day);

            if (new Triangle(planetsPositions).Contains(Sun))
                return new RainyDay(day, planetsPositions);

            return new UnknownDay(day);
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
