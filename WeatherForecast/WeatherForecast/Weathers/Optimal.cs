﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast
{
    public class Optimal : WeatherType
    {
        public override string Description { get => "Optimo"; }

        public Optimal() { }

        public override bool IsOptimal()
        {
            return true;
        }

    }
}
