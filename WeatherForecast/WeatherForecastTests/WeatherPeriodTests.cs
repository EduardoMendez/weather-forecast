using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WeatherForecast;
using WeatherForecast.Weathers;

namespace WeatherForecastTests
{
    public class WeatherPeriodTests
    {
        [Test]
        public void GetDurationOfPeriodTest()
        {
            var periodDays = new List<MeteorologicalDay>()
            {
                new MeteorologicalDay(1, new Drought(), null),
                new MeteorologicalDay(2, new Drought(), null),
                new MeteorologicalDay(3, new Drought(), null),
                new MeteorologicalDay(4, new Drought(), null),
                new MeteorologicalDay(5, new Drought(), null),
            };

            var period = new WeatherPeriod(new Drought(), periodDays);

            Assert.That(period.GetDuration(), Is.EqualTo(5));
        }
    }
}
