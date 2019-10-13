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
