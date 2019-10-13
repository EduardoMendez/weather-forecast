using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private Galaxy _galaxy;
        private DAO.DayWeatherDAO _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DAO.DayWeatherDAO repository)
        {
            _logger = logger;
            _repository = repository;
            InitGalaxy();
        }

        [HttpGet]
        [HttpGet("periodYearsForecast")]
        public dynamic GetYearsForecast(int years = 1)
        {
            var periods = new WeatherForecaster(_galaxy.Planets, _galaxy.Sun).
                GetWeatherPeriodsForecastForYears(years);

            var droughtPeriods = periods.Count(p => p.Weather.IsDrought());
            var rainnyPeriods = periods.Count(p => p.Weather.IsRain());
            var optimalPeriods = periods.Count(p => p.Weather.IsOptimal());
            var unknownPeriods = periods.Count(p => p.Weather.IsUnknown());

            var peakDays = periods
                .Where(p => p.HasPeakDay())
                .Select(p => p.PeakDay);

            var maxPeakLevel = peakDays.Max(d => d.CalculatePrecipitations());
            var maxPeakDays = peakDays
                .Where(pd => pd.CalculatePrecipitations() == maxPeakLevel)
                .Select(d => d.Day);

            return new { 
                periodosDeSequia = droughtPeriods, 
                periodosDeLluvia = rainnyPeriods,
                periodosDeCondicionesOptimas = optimalPeriods,
                periodosDeCondicionesDesconocidas = unknownPeriods,
                diasPicoMaximoDeLluvia = maxPeakDays,
                valorPicoMaximoDeLluvia = maxPeakLevel
            };
        }

        [HttpGet]
        [HttpGet("clima")]
        public dynamic GetWeatherForDay(long day)
        {
            var dayWeather = _repository.GetDayWeather(day);

            return new
            {
                dia = dayWeather.Day,
                clima = dayWeather.Weather
            };
        }

        private void InitGalaxy()
        {
            _galaxy = new Galaxy();

            var ferengi = new Planet("ferengi", 1, Direction.CLOCKWISE, 500);
            var vulcano = new Planet("vulcano", 5, Direction.COUNTERCLOCKWISE, 1000);
            var betasoide = new Planet("betasoide", 3, Direction.CLOCKWISE, 2000);

            _galaxy.Planets = new List<Planet>()
            {
                ferengi, vulcano, betasoide
            };

            _galaxy.Sun = new Point(0, 0);
        }
    }
}
