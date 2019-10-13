using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;

namespace WeatherForecastTests
{
    public class PlanetTests
    {
        [Test]
        public void PositionPlanetTest()
        {
            var planet = new Planet("Mercurio", 90, Direction.COUNTERCLOCKWISE, 100);

            Assert.That(Math.Round(planet.GetPositionForDay(1).X), Is.EqualTo(0));
            Assert.That(Math.Round(planet.GetPositionForDay(1).Y, 2), Is.EqualTo(100));
        }
    }
}
