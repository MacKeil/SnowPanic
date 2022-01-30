using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace NorthernAlarmClock.Helpers
{
    class LocationHelper
    {
        private Location location;
        private bool enabled;


        static bool warned;

        public LocationHelper()
        {
            GetLocation();
        }

        public Location Location { 
            get { return location; }
            set { location = value; }
         }

        public bool Enabled
        {
            get { return enabled; }
        }

        async void GetLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Low);

                location = await Geolocation.GetLocationAsync(request);

                enabled = true;

                if (location != null)
                {
                    if (location.IsFromMockProvider)
                    {
                        enabled = false;
                    }
                }

            }
            catch (FeatureNotEnabledException fnee)
            {
                if (warned)
                {
                    enabled = false;
                }
                else
                {
                    //do the warning
                    warned = true;
                }
            }
            catch (FeatureNotSupportedException fnse)
            {
                enabled = false;
            }
            catch (PermissionException pme)
            {
                //Alert user they need to enable permissions
                
            }
        }
    }
}
