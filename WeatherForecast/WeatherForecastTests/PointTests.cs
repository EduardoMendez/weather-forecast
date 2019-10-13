using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;

namespace WeatherForecastTests
{
    public class PointTests
    {
        [Test]
        public void DistanceBetweenTwoPointsOnTheXAxisTest()
        {
            var pointA = new Point(0,0);
            var pointB = new Point(6,0);

            Assert.That(pointA.DistanceTo(pointB), Is.EqualTo(6));
        }

        [Test]
        public void DistanceBetweenTwoPointsTest()
        {
            var pointA = new Point(3, 5);
            var pointB = new Point(6, 1);

            Assert.That(pointA.DistanceTo(pointB), Is.EqualTo(5));
        }
    }
}
