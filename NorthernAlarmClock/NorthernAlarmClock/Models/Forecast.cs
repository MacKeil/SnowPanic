using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthernAlarmClock.Models
{
    class Forecast
    {
        public int number { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public bool isDaytime { get; set; }
        public int temperature { get; set; }
        public char temperatureUnit { get; set; }
        public dynamic temperatureTrend { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
        public string icon { get; set; }
        public string shortForecast { get; set; }
        public string detailedForecast { get; set; }

        public DateTime startDateTime()
        {
            return DateTime.Parse(startTime);
        }

        public DateTime endDateTime()
        {
            return DateTime.Parse(endTime);
        }

    }

    class ForecastHourly
    {
        public IEnumerable<Forecast> periods { get; set; }

        public Forecast getColdest()
        {
            return periods.Aggregate<Forecast>((p1, p2) => p1.temperature < p2.temperature ? p1 : p2);
        }

        public Forecast getWarmest()
        {
            return periods.Aggregate <Forecast>((p1, p2) => p1.temperature > p2.temperature ? p1 : p2);
        }
    }
}
