using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using testapp.Views;
using testapp.Models;
using testapp.Services;
using System.Diagnostics;

namespace testapp.Controllers
{
    class ComplaintsController
    {
        private IGeolocator locator;
        private ComplaintFormPage view;
        private Position position;
        public bool gpsEnabled { get; set; }

        public ComplaintsController(ComplaintFormPage view)
        {
            this.view = view;


        }

        public async void CheckLocationEnabledAsync()
        {
            try
            {
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (!locator.IsGeolocationEnabled)
                {
                    gpsEnabled = false;
                    return;
                }
                position = await locator.GetPositionAsync(10000);
                gpsEnabled = true;
            }
            catch (Exception le) 
            {
                Debug.Write(le.Message);
                gpsEnabled = false;
            }
        }

        public void SubmitComplaint(Complaint complaint)
        {
            complaint.latitude = position.Latitude.ToString();
            complaint.longtitude = position.Longitude.ToString();

            ComplaintService.Instance.SubmitComplaint(complaint);
            view.ShowAlert("Melding", "Uw klacht is succesvol verzonden.");
        }
    }
}
