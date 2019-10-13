using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast;

namespace WeatherForecastAPI
{
    public class Galaxy
    {
        public IEnumerable<Planet> Planets { get; set; }
        public Point Sun { get; set; }

        public static Galaxy GetVulcanosFerengisBetasoidesGalaxy()
        {
            var galaxy = new Galaxy();

            var ferengi = new Planet("ferengi", 1, Direction.CLOCKWISE, 500);
            var vulcano = new Planet("vulcano", 5, Direction.COUNTERCLOCKWISE, 1000);
            var betasoide = new Planet("betasoide", 3, Direction.CLOCKWISE, 2000);

            galaxy.Planets = new List<Planet>()
            {
                ferengi, vulcano, betasoide
            };

            galaxy.Sun = new Point(0, 0);

            return galaxy;
        }

    }
}
