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

        public DayWeather GetDayWeatherById(long id)
        {
           return _context.DayWeathers.Find(id);
        }

        public DayWeather GetDayWeatherByDay(long dayNumber)
        {
            return _context.DayWeathers.FirstOrDefault(d => d.Day == dayNumber);
        }

        public void AddDayWeather(DayWeather day)
        {
            _context.DayWeathers.Add(day);
            _context.SaveChanges();
        }
    }
}
