using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecastAPI.Models;
using WeatherForecastAPI.DAO;

namespace WeatherForecastAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private DayWeatherDAO _repository;

        private Galaxy _galaxy = Galaxy.GetVulcanosFerengisBetasoidesGalaxy();

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DAO.DayWeatherDAO repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: /weatherforecast/weatherperiods?years=[number]
        [HttpGet("weatherperiods")]
        public dynamic GetWeatherPeriodsForecast(int years = 1)
        {
            var periods = new WeatherForecaster(_galaxy.Planets, _galaxy.Sun)
                .GetWeatherPeriodsForecastForYears(years);

            var droughtPeriods = periods.Count(p => p.Weather.IsDrought());
            var rainyPeriods = periods.Count(p => p.Weather.IsRain());
            var optimalPeriods = periods.Count(p => p.Weather.IsOptimal());
            var unknownPeriods = periods.Count(p => p.Weather.IsUnknown());

            var peakInfo = GetPeakInfo(periods);

            return new { 
                periodosDeSequia = droughtPeriods, 
                periodosDeLluvia = rainyPeriods,
                periodosDeCondicionesOptimas = optimalPeriods,
                periodosDeCondicionesDesconocidas = unknownPeriods,
                diasPicoMaximoDeLluvia = peakInfo.PeakDays,
                valorPicoMaximoDeLluvia = peakInfo.PeakLevel
            };
        }

        // GET: /weatherforecast/weatherdays?years=[number]
        [HttpGet("weatherdays")]
        public dynamic GetWeatherDaysForecast(int years = 1)
        {
            var periods = new WeatherForecaster(_galaxy.Planets, _galaxy.Sun)
                .GetWeatherPeriodsForecastForYears(years);

            int droughtDays = periods.Where(p => p.Weather.IsDrought()).Sum(p => p.GetDuration());
            int rainyDays = periods.Where(p => p.Weather.IsRain()).Sum(p => p.GetDuration());
            int optimalDays = periods.Where(p => p.Weather.IsOptimal()).Sum(p => p.GetDuration());
            int unknownDays = periods.Where(p => p.Weather.IsUnknown()).Sum(p => p.GetDuration());

            var peakInfo = GetPeakInfo(periods);

            return new
            {
                diasDeSequia = droughtDays,
                diasDeLluvia = rainyDays,
                diasDeCondicionesOptimas = optimalDays,
                diasDeCondicionesDesconocidas = unknownDays,
                diasPicoMaximoDeLluvia = peakInfo.PeakDays,
                valorPicoMaximoDeLluvia = peakInfo.PeakLevel
            };
        }

        // GET: /weatherforecast/weather?day=[number]
        [HttpGet("weather")]
        public dynamic GetWeatherForDay(long day = 0)
        {
            var dayWeather = _repository.GetDayWeatherByDay(day);

            if (dayWeather == null)
                return NotFound();

            return new
            {
                dia = dayWeather.Day,
                clima = dayWeather.Weather
            };
        }


        private PeakInfo GetPeakInfo(IEnumerable<WeatherPeriod> periods)
        {
            var peakDays = periods
                .Where(p => p.HasPeakDay())
                .Select(p => p.PeakDay);

            var maxPeakLevel = peakDays.Max(d => d.CalculatePrecipitations());

            var maxPeakDays = peakDays
                    .Where(pd => pd.CalculatePrecipitations() == maxPeakLevel)
                    .Select(d => d.Day);

            return new PeakInfo(maxPeakLevel, maxPeakDays);
        }
    }
}
