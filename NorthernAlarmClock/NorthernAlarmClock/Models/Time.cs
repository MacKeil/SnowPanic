using System;
using System.Collections.Generic;
using System.Text;

namespace NorthernAlarmClock.Models
{
    class Time
    {
        public enum OffsetType { Hour, Minute };

        private DateTime initialTime;
        private DateTime offsetDate;
        private TimeSpan timeSpan;
        private int offset;
        private int hour_initial;
        private int minutes_initial;
        private int seconds_initial;
        private OffsetType offsetType;


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

        void setTemporaryOffset(int offsetTime, OffsetType type)
        {
            offset = offsetTime;
            offsetDate = DateTime.Now;
            offsetType = type;
        }

        DateTime getTargetTime()
        {
            return (Within24Hrs()) ? TimePlusOffset() : initialTime;
        }


        private bool Within24Hrs()
        {
            bool isWithin;
            TimeSpan ts = DateTime.Now - offsetDate;

            isWithin = (ts.Hours <= 24);

            return isWithin;
        }

        private DateTime TimePlusOffset()
        {
            DateTime retVar;
            if (offsetType == OffsetType.Hour)
            {
                retVar = new DateTime(initialTime.Year, initialTime.Month, initialTime.Day, hour_initial - offset, minutes_initial, seconds_initial, 0);
            }
            else if (offsetType == OffsetType.Minute)
            {
                int hourOffset = 0;
                if (offset >= 60)
                {
                    hourOffset = offset / 60;
                    offset = offset % 60;
                }

                retVar = new DateTime(initialTime.Year, initialTime.Month, initialTime.Day, hour_initial - hourOffset, minutes_initial - offset, seconds_initial, 0);
            }
            else
            {
                retVar = initialTime;
            }

            return retVar;
        }

    }
}
