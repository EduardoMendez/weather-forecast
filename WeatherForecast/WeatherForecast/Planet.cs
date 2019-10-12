using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public enum Direction
    {
        CLOCKWISE, COUNTERCLOCKWISE
    }

    public class Planet
    {
        public string Name { get; set; }
        public double AngularSpeedInDegrees { get; set; }
        public Direction RotationDirection { get; set; }
        public int OrbitRadiusInKm { get; set; }

        private const int degreeCircumference = 360;

        public Planet(string name, double angularSpeedInDegrees, Direction rotationDirection, int orbitRadiusInKm)
        {
            Name = name;
            AngularSpeedInDegrees = angularSpeedInDegrees;
            RotationDirection = rotationDirection;
            OrbitRadiusInKm = orbitRadiusInKm;
        }

        public Point GetPositionForDay(int day)
        {
            var angleInDegrees = (day * AngularSpeedInDegrees) % degreeCircumference;

            // If the planet rotates counterclockwise, I must calculate 360 - angle.
            if (RotationDirection == Direction.CLOCKWISE && angleInDegrees > 0)
                angleInDegrees = degreeCircumference - angleInDegrees;

            var angleInRadians = angleInDegrees.ToRadians();

            // It goes from polar coordinates to rectangular coordinates.
            var x = OrbitRadiusInKm * Math.Cos(angleInRadians);
            var y = OrbitRadiusInKm * Math.Sin(angleInRadians);

            return new Point(x, y);
        }
    }
}
