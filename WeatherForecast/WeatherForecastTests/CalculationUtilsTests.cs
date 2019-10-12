using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;

namespace WeatherForecastTests
{
    public class CalculationUtilsTests
    {
        [Test]
        public void PointsOfBasicLineAreCollinear()
        {
            // Points of line y = x
            var pointA = new Point(1, 0);
            var pointB = new Point(2, 0);
            var pointC = new Point(3, 0);

            Assert.IsTrue(CalculationUtils.AreCollinear(pointA, pointB, pointC));
        }

        [Test]
        public void PointsOfLineAreCollinear()
        {
            // Points of line y = 5x + 3
            var pointA = new Point(0, 3);
            var pointB = new Point(3, 18);
            var pointC = new Point(8, 43);

            Assert.IsTrue(CalculationUtils.AreCollinear(pointA, pointB, pointC));
        }

        [Test]
        public void PointsOfATriangleAreNotCollinear()
        {
            var pointA = new Point(1, 0);
            var pointB = new Point(5, 0);
            var pointC = new Point(3, 5);

            Assert.IsFalse(CalculationUtils.AreCollinear(pointA, pointB, pointC));
        }
    }
}
