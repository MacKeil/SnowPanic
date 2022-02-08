using System;
using System.Collections.Generic;
using System.Text;

namespace NorthernAlarmClock.Models
{
    class Day
    {

        public bool Sunday {get; set;}
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }

        public DayOfWeek[] days;

        Day(DayOfWeek[] someDays)
        {
            days = someDays;
            foreach (DayOfWeek aDay in days)
            {
                switch (aDay)
                {
                    case (DayOfWeek.Sunday):
                        Sunday = true;
                        break;

                    case DayOfWeek.Monday:
                        Monday = true;
                        break;
                    case DayOfWeek.Tuesday:
                        Tuesday = true;
                        break;
                    case DayOfWeek.Wednesday:
                        Wednesday = true;
                        break;
                    case DayOfWeek.Thursday:
                        Thursday = true;
                        break;
                    case DayOfWeek.Friday:
                        Friday = true;
                        break;
                    case DayOfWeek.Saturday:
                        Saturday = true;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
