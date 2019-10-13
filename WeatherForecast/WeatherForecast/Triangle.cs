using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForecast
{
    public class Triangle
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }

        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }

        public Triangle(IEnumerable<Point> points)
        {
            if (points.Count() != 3)
                throw new Exception("Invalid number of points.");

            PointA = points.ElementAt(0);
            PointB = points.ElementAt(1);
            PointC = points.ElementAt(2);
        }

        public double GetPerimeter()
        {
            return  PointA.DistanceTo(PointB) + 
                    PointA.DistanceTo(PointC) + 
                    PointB.DistanceTo(PointC);
        }

        public bool Contains(Point point)
        {
            /*
             * We apply the method based on the baricentric coordinate system 
             * It defines 3 scalars a, b, c such that:
                x = a * x1 + b * x2  + c * x3
                y = a * y1 + b * y2 + c * y3
                a + b + c = 1
             * 
             * A point lies in the triangle if and only if 
             *      0 <= a <= 1 and 
             *      0 <= b <= 1 and
             *      0 <= c <= 1
             * 
             */

            double denominator = ((PointB.Y - PointC.Y) * (PointA.X - PointC.X) + (PointC.X - PointB.X) * (PointA.Y - PointC.Y));
            double a = ((PointB.Y - PointC.Y) * (point.X - PointC.X) + (PointC.X - PointB.X) * (point.Y - PointC.Y)) / denominator;
            double b = ((PointC.Y - PointA.Y) * (point.X - PointC.X) + (PointA.X - PointC.X) * (point.Y - PointC.Y)) / denominator;
            double c = 1 - a - b;

            return (0 <= a && a <= 1) && (0 <= b && b <= 1) && (0 <= c && c <= 1);
        }
    }
}
