using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;

namespace WeatherForecastTests
{
    public class ExtensionsMethodsTests
    {
        [Test]
        public void FromDegreesToRadianTests()
        {
            double angleInDegrees = 90;
            var angleInRadians = angleInDegrees.ToRadians();

            Assert.That(angleInRadians, Is.EqualTo(0.5 * Math.PI));
        }

        [Test]
        public void IsBetweenTest()
        {
            double number = 50;

            Assert.IsTrue(number.IsBetween(0, 100));
            Assert.IsFalse(number.IsBetween(60, 80));
        }
    }
}
