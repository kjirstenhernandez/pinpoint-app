using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pinpoint_app.Services
{
    
    public class ConnectivityService : Interfaces.IConnectivityService
    {
        public ConnectivityService()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.ConnectionProfiles;
           
            if (access != NetworkAccess.Internet)
                ShowAlert("No Internet Access.  Please check your connection.");
            
            
        }

        public bool HasInternetAccess()
        {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        private void ShowAlert(string message)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.DisplayAlert("Connectivity", message, "OK");
            });
        }
    }
}
