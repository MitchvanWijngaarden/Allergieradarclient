using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using testapp.Views;
using testapp.Models;
using testapp.Services;

namespace testapp.Controllers
{
    class ComplaintsController
    {
        private IGeolocator locator;
        private KlachtenPage view;
        private Position position;

        public ComplaintsController(KlachtenPage view)
        {
            this.view = view;

            ComplaintService.Instance.getAllComplaints();

        }

        public async System.Threading.Tasks.Task<bool> CheckLocationEnabledAsync()
        {
            try
            {
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationEnabled)
                {
                    position = await locator.GetPositionAsync(10000);
                    view.gpsEnabled = true;
                    return true;
                }
                else
                {
                    view.gpsEnabled = false;
                    return false;
                }
            }
            catch (Exception le) 
            {
                view.gpsEnabled = false;
                return false;
            }
        }

        public void submitComplaint(Complaint complaint)
        {
            complaint.latitude = position.Latitude.ToString();
            complaint.longtitude = position.Longitude.ToString();

            ComplaintService.Instance.SubmitComplaintAsync(complaint);
            view.showAlert("Melding", "Uw klacht is succesvol verzonden.");

        }
    }
}
