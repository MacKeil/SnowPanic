using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NorthernAlarmClock.Models
{
    class Snowfall
    {

        public class valueObj
        {
            public string validTime { get; set; }
            public double value { get; set; }
            

            public double convertValueInvoices()
            {
                return (value * 0.0393700787);
            }

            public DateTime getDateTime()
            {
                return DateTime.Parse(validTime);
            }
        }

        public string uom { get; set; }
        public IList<valueObj> values { get; set; }

        public string getUOMType()
        {
            return uom.Replace("wmoUnit", "");
        }

        public double convertValueInches(int index)
        {
            return (values[index].value * 0.0393700787);
        }

        public double snowFallOverTime(int hours)
        {
            List<valueObj> objs = (List<valueObj>)values.Where(valObj => valObj.value > 0.00).Where(val => val.getDateTime() >= DateTime.Now && val.getDateTime() <= DateTime.Now.AddHours((double)hours));
            double accumulation = objs.Sum(obj => obj.value);
            return accumulation;
        }

        public double snowFallOverTimeInches(int hours)
        {
            double accumulation = snowFallOverTime(hours);
            return (accumulation * 0.0393700787);
        }

        public valueObj highestSnowfallTime()
        {
            return values.Aggregate((v1, v2) => v1.value > v2.value ? v1 : v2);
        }

    }
}
