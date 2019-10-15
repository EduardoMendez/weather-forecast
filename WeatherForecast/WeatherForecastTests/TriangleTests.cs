using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WeatherForecast;

namespace WeatherForecastTests
{
    public class TriangleTests
    {
        [Test]
        public void GetPerimeterTest()
        {
            /* Right Triangle
             * Side A = 6
             * Side B = 6
             * Side C = 8.458 (Calculated using Pitagoras)
             */
            var pointA = new Point(0,0);
            var pointB = new Point(6,0);
            var pointC = new Point(0,6);

            var triangle = new Triangle(pointA, pointB, pointC);
            var roundedPerimeter = Math.Round(triangle.GetPerimeter(), 3);

            Assert.That(roundedPerimeter, Is.EqualTo(20.485));
        }

        [Test]
        public void TriangleContainsPointTest()
        {
            var pointA = new Point(5,0);
            var pointB = new Point(-5,0);
            var pointC = new Point(0,5);

            var triangle = new Triangle(pointA, pointB, pointC);

            Assert.IsTrue(triangle.Contains(new Point(0,3)));
            Assert.IsFalse(triangle.Contains(new Point(-1,-7)));
        }
    }
}
