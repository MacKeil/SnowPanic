using System;
using System.Collections.Generic;
using System.Text;

namespace NorthernAlarmClock.Models
{
    class Time
    {

        private DateTime initialTime;
        private TimeSpan timeSpan;
        private int hour_initial;
        private int minutes_initial;
        private int seconds_initial;



        Time()
        {
            initialTime = new DateTime();
            DateTime temp = initialTime.ToLocalTime();
            hour_initial = temp.Hour;
            minutes_initial = temp.Minute;
            seconds_initial = temp.Second;
        }


        void setTargetTime(DateTime dt)
        {
            initialTime = dt;
            dt = dt.ToLocalTime();
            hour_initial = dt.Hour;
            minutes_initial = dt.Minute;
            seconds_initial = dt.Second;
        }

        DateTime getTargetTime()
        {
            return initialTime.ToLocalTime();
        }

    }
}
