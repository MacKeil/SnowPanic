using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Essentials;
using NorthernAlarmClock.Helpers;
using System.Threading.Tasks;

namespace NorthernAlarmClock.Network
{
    class ForecastServices
    {
        #region Properties
        private HttpClient client;
        private NetworkHelper networkHelper;
        private LocationHelper locationHelper;
        private Uri NWS;
        private Uri NWSHourly;
        private Uri NWSForecast;
        private Uri geocoding;
        private bool cacheRequests;
        private bool needsAddress;
        private bool locationLoaded;
        private string address;
        private double latitude;
        private double longitude;
        private string station;
        private int gridX;
        private int gridY;

        public bool NeedsAddress
        {
            get { return needsAddress; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        #region Constructors
        public ForecastServices()
        {
            client = new HttpClient();
            locationHelper = new LocationHelper();
            cacheRequests = false;
            locationLoaded = false;
            if (locationHelper.Enabled)
            {
                needsAddress = false;

            } else
            {
                needsAddress = true;
            }
        }

        public ForecastServices(bool checkPreferences)
        {
            client = new HttpClient();
            locationHelper = new LocationHelper();
            locationLoaded = false;
            if (checkPreferences)
            {
                if (Preferences.ContainsKey("WiFi_Only"))
                {
                    networkHelper.loadProfile();
                    if (networkHelper.Profile != ConnectionProfile.WiFi)
                    {
                        //cache the request, and wait some time before requesting permission
                        cacheRequests = true;
                    }
                    else
                    {
                        //go ahead and get our URI's ready
                        cacheRequests = false;
                    }

                }
            }

            if (locationHelper.Enabled)
            {
                needsAddress = false;
            } else
            {
                needsAddress = true;
            }
        }
        #endregion

        #region Methods

        #region Public Methods
        public async Task<dynamic> getSnowFallAsync()
        {
            ensureNWSLoaded();
            HttpResponseMessage response = await client.GetAsync(NWS);
            return "TODO";
        }

        public dynamic getSnowFall()
        {
            return "TODO";
        }

        public async Task<dynamic> getForecastAsync()
        {
            return "TODO";
        }

        public dynamic getForecast()
        {
            return "TODO";
        }
        #endregion


        #region Private Methods
        private bool useLocationToCheck()
        {
            if(!needsAddress && !cacheRequests)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void getLocation()
        {
            if (useLocationToCheck())
            {
                latitude = locationHelper.Location.Latitude;
                longitude = locationHelper.Location.Longitude;
                locationLoaded = true;

            }else
            {
                if (cacheRequests)
                {
                    //TODO: create requests cache
                } else
                {
                    address = loadAddress();
                    geocoding = new Uri(Constants.geoCodingBaseURL + "onelineaddress?address=" + Uri.EscapeDataString(address));
                    Task<double[]> task = locationRequest();
                    double[] coordinates = task.Result;
                    if (coordinates[0] != 300.00 && coordinates[1] != 300.00)
                    {
                        latitude = coordinates[0];
                        longitude = coordinates[1];
                    }
                }
            }
        }

        private string loadAddress()
        {
            return Preferences.ContainsKey(Constants.key_useStoredAddress) ? Preferences.Get(Constants.key_storedAddress, "") : address;
        }

        private async Task<double[]> locationRequest()
        {
            HttpResponseMessage response = await client.GetAsync(geocoding);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Models.GeocodingDefinition something = JsonConvert.DeserializeObject<Models.GeocodingDefinition>(content);
                double[] retVal = { something.result.addressMatches[0].coordinates.x, something.result.addressMatches[0].coordinates.y };
                return retVal;
            }
            else
            {
                //return an impossible lat and long pair
                double[] retVal = { 300.00, 300.00 };
                return retVal;
            }
        }

        private void ensureNWSLoaded()
        {
            if(NWS.ToString().Length <= 32 && locationLoaded)
            {
                string loc = String.Format("{0},{1}", latitude, longitude);
                NWS = new Uri(String.Format("{0}{1}{2}", Constants.nationalWeatherServiceBaseURL, Constants.initNWS, loc));
            }
        }

        private void ensureNWSHourlyLoaded()
        {

        }

        private void ensureNWSForecastLoaded()
        {
            if (NWSForecast.ToString().Length < 25)
            {
                
            }
        }
        #endregion
        #endregion
    }
}
