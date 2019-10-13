using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherForecast
{
    public class CalculationUtils
    {
        public static bool AreCollinear(Point point1, Point point2, Point point3)
        {
            /*
            * Three points lie on the straight line if the area formed by the triangle of these three points is zero.
            *
            * Formula for area of triangle is : 
            *   0.5 * [x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)]
            */

            /* We can skipped multiplication with 0.5 because we only want to know if it is equals to zero */
            var a = point1.X * (point2.Y - point3.Y) +
                    point2.X * (point3.Y - point1.Y) +
                    point3.X * (point1.Y - point2.Y);

            /*
             * Because all operations are floating, the chances of being exactly zero are very very low. 
             * We will take a range close to zero in which the points will be considered collinear.
             * Ideally, the condition should be 
             *      a == 0
             */
            return a.IsBetween(-0.0001, 0.0001);
        }

        public static bool AreCollinear(IEnumerable<Point> points)
        {
            if (points.Count() < 3)
                return true;

            bool areCollinear = true;

            for(int i = 0; i < points.Count() - 2; i++)
            {
                areCollinear = areCollinear && AreCollinear(points.ElementAt(i), points.ElementAt(i + 1), points.ElementAt(i + 2));

                if (!areCollinear)
                    break;
            }

            return areCollinear;
        }
    }
}
