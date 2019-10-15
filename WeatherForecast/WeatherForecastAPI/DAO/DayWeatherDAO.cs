using System.Linq;
using WeatherForecastAPI.Models;

namespace WeatherForecastAPI.DAO
{
    public class DayWeatherDAO
    {
        private readonly WeatherDbContext _context;

        public DayWeatherDAO(WeatherDbContext context)
        {
            _context = context;
        }

        public DayWeather GetDayWeatherByDay(long dayNumber)
        {
            return _context.DayWeathers.FirstOrDefault(d => d.Day == dayNumber);
        }
    }
}
