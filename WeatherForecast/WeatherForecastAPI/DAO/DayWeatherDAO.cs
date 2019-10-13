using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Context;
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

        public dynamic GetDayWeather(long id)
        {
           return _context.Days.Find(id);
        }

        public void AddDayWeather(DayWeather day)
        {
            _context.Days.Add(day);
            _context.SaveChanges();
        }
    }
}
