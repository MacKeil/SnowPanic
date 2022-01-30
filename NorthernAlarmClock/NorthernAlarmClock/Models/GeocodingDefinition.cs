using System;
using System.Collections.Generic;
using System.Text;

namespace NorthernAlarmClock.Models
{
    class GeocodingDefinition
    {
        public resultObj result { get; set; }
    }

    class resultObj
    {
        public inputObj input { get; set; }
        public IList<addressMatchObj> addressMatches { get; set; }

    }

    class inputObj
    {
        public benchmarkObj benchmark { get; set; }
        public addressObj address { get; set; }
    }


    class benchmarkObj
    {
        public string id { get; set; }
        public string benchmarkName { get; set; }
        public string benchmarkDescription { get; set; }
        public bool isDefault { get; set; }
    }

    class addressObj
    {
        public string address { get; set; }
    }

    class addressMatchObj
    {
        public string matchedAddress { get; set; }
        public coordinatesObj coordinates { get; set; }
        public tigerLineObj tigerLine { get; set; }
        public addressComponentsObj addressComponents { get; set; }
    }

    class coordinatesObj
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    class tigerLineObj
    {
        public string tigerLineId { get; set; }
        public string side { get; set; }
    }

    class addressComponentsObj
    {
        public string fromAddress { get; set; }
        public string toAddress { get; set; }
        public string preQualifier { get; set; }
        public string preDirection { get; set; }
        public string preType { get; set; }
        public string streetName { get; set; }
        public string suffixType { get; set; }
        public string suffixDirection { get; set; }
        public string suffixQualification { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }
}
