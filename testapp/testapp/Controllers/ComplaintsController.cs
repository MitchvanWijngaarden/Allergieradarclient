using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using testapp.Views;
using testapp.Models;
using testapp.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace testapp.Controllers
{
    class ComplaintsController
    {
        private IGeolocator locator;
        private ComplaintFormPage view;
        private Position position;
        public bool gpsEnabled { get; set; }

        /// <summary>
        /// Constructor for ComplaintFormPage
        /// </summary>
        /// <param name="view"></param>
        public ComplaintsController(ComplaintFormPage view)
        {
            this.view = view;
        }

        /// <summary>
        /// Extra empty constructor for mappage, mappage and ComplaintFormPage should have a view interface.
        /// </summary>
        public ComplaintsController()
        {
        }

        /// <summary>
        /// Atempts to get the users' GPS location with a preffered accuracy of at least 50 meters, could take a few seconds to acquire, hence why it's called
        /// this early.
        /// </summary>
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

        /// <summary>
        /// Uses the previously gathered latitude and longitude to finish the Complaint model, then submits it to the ComplaintService.
        /// </summary>
        /// <param name="complaint"></param>
        public void SubmitComplaint(Complaint complaint)
        {
            complaint.latitude = position.Latitude.ToString();
            complaint.longtitude = position.Longitude.ToString();

            ComplaintService.Instance.SubmitComplaint(complaint);
            view.ShowAlert("Melding", "Uw klacht is succesvol verzonden.");
        }

        /// <summary>
        /// Returns all the complaints found in the database.
        /// </summary>
        /// <returns></returns>
        public List<Complaint> GetComplaints()
        {
            List<Complaint> list = new List<Complaint>();
            var json = ComplaintService.Instance.GetAllComplaints();

            IEnumerable<Complaint> result = JsonConvert.DeserializeObject<IEnumerable<Complaint>>(json);

            foreach (Complaint c in result)
            {
                list.Add(c);
            }

            return list;

        }

    }
}
