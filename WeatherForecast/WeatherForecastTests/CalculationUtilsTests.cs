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

        [Test]
        public void FivePointsOfLineAreCollinear()
        {
            var points = new List<Point>
            {
                // Points of line y = 2x + 1
                new Point(0,1),
                new Point(2,5),
                new Point(4,9),
                new Point(7,15),
                new Point(12,25)
            };

            Assert.IsTrue(CalculationUtils.AreCollinear(points));
        }

        [Test]
        public void FivePointsNonAlignedAreNotCollinear()
        {
            var points = new List<Point>
            {
                // Points of line y = 2x + 1
                new Point(0,1),
                new Point(2,5),
                // Points of line y = 3x + 5
                new Point(4,17),
                new Point(5,20),
                // Another point
                new Point(10,10)
            };

            Assert.IsFalse(CalculationUtils.AreCollinear(points));
        }
    }
}
