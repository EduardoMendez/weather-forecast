using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast;
using WeatherForecast.Weathers;

namespace WeatherForecastTests
{
    public class MeteorologicalDayTests
    {
        [Test]
        public void TwoRainyDaysAreTheSameWeatherTest()
        {
            var day1 = new MeteorologicalDay(1, new Rain(), null);
            var day2 = new MeteorologicalDay(2, new Rain(), null);

            Assert.IsTrue(day1.HasTheSameWeather(day2));
        }

        [Test]
        public void ARainyDayAndADroughtDayAreNotTheSameWeatherTest()
        {
            var rainyDay = new MeteorologicalDay(1, new Rain(), null);
            var droughtDay = new MeteorologicalDay(2, new Drought(), null);

            Assert.IsFalse(rainyDay.HasTheSameWeather(droughtDay));
        }
    }
}
