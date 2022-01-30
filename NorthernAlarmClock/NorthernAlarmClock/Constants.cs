using System;
using System.Collections.Generic;
using System.Text;

namespace NorthernAlarmClock
{
    static class Constants
    {
        public const string nationalWeatherServiceBaseURL = "https://api.weather.gov/";
        public const string geoCodingBaseURL = "https://geocoding.geo.census.gov/geocoder/locations/";
        public const string initNWS = "points/";
        public const string gp = "gridpoints/";
        public const string hourly = "forecast/hourly";
        
        
        
        public const string key_wifiOnly = "Wifi_Only";
        public const string key_checkHoursBefore = "Check_T_Minus";
        public const string key_minSnowfall = "Min_Snow_Fall";
        public const string key_autoEarlyWake = "Automatically_Wake_Early";
        public const string key_hoursEarly = "How_Early_Ring";
        public const string key_useStoredAddress = "Use_Stored_Address";
        public const string key_storedAddress = "Stored_Address";
    }
}
