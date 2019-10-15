using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastAPI
{
    public class PeakInfo
    {
        public double PeakLevel { get; set; }
        public IEnumerable<int> PeakDays { get; set; }

        public PeakInfo(double peakLevel, IEnumerable<int> peakDays)
        {
            PeakLevel = peakLevel;
            PeakDays = peakDays;
        }
    }
}
