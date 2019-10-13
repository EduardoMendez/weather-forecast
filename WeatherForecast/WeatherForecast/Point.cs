using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point point)
        {
            return Math.Sqrt(
                Math.Pow(point.X - this.X, 2) + Math.Pow(point.Y - this.Y, 2)
            );
        }
    }
}
