﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class CalculationUtils
    {
        public static bool AreCollinear(Point point1, Point point2, Point point3)
        {
            return ((point3.Y - point2.Y) * (point2.X - point1.X) ==
                (point2.Y - point1.Y) * (point3.X - point2.X));
        }

        public static bool AreCollinear(Point point1, Point point2, Point point3, Point point4)
        {
            return AreCollinear(point1, point2, point3) && AreCollinear(point1, point2, point4);
        }

        // TODO
        public static bool AreCollinear(IEnumerable<Point> points)
        {
            return true;
        }

        public static bool PointInTriangle(Point point, Point trianglePoint1, Point trianglePoint2, Point trianglePoint3)
        {
            double denominator = ((trianglePoint2.Y - trianglePoint3.Y) * (trianglePoint1.X - trianglePoint3.X) + (trianglePoint3.X - trianglePoint2.X) * (trianglePoint1.Y - trianglePoint3.Y));
            double a = ((trianglePoint2.Y - trianglePoint3.Y) * (point.X - trianglePoint3.X) + (trianglePoint3.X - trianglePoint2.X) * (point.Y - trianglePoint3.Y)) / denominator;
            double b = ((trianglePoint3.Y - trianglePoint1.Y) * (point.X - trianglePoint3.X) + (trianglePoint1.X - trianglePoint3.X) * (point.Y - trianglePoint3.Y)) / denominator;
            double c = 1 - a - b;

            return (0 <= a && a <= 1) && (0 <= b && b <= 1) && (0 <= c && c <= 1);
        }
    }
}