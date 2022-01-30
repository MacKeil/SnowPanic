using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;


namespace NorthernAlarmClock.Helpers
{
    class NetworkHelper
    {
        private ConnectionProfile profile;



        public ConnectionProfile Profile
        {
            get { return profile; }
        }

        public bool hasInternetAccess()
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            return (current == NetworkAccess.Internet);
        }

        public void loadProfile()
        {
            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi))
            {
                profile = ConnectionProfile.WiFi;
            } else if (profiles.Contains(ConnectionProfile.Cellular))
            {
                profile = ConnectionProfile.Cellular;
            }
        }
    }
}
