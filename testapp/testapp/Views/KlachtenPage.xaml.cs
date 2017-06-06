<<<<<<< HEAD
﻿using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using testapp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using testapp.Services;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlachtenPage : ContentPage
    {
        IGeolocator locator;
        Position position = null;

        public KlachtenPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            if (((Slider)sender) == sliderNose )
            {
                valueLabelNose.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if(((Slider)sender) == sliderLungs)
            {
                valueLabelLungs.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if (((Slider)sender) == sliderEyes)
            {
                valueLabelEyes.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                // Get the current device position. Leave it null if geo-location is disabled,
                // return position (0, 0) if unable to acquire.
                if (locator.IsGeolocationEnabled)
                {
                    // Allow ten seconds for geo-location determination.                    
                    //position = await locator.GetPositionAsync(10000);
                    position = await locator.GetPositionAsync(10000);
                }
                else
                {
                    debugText.Text = ("Location could not be acquired, geolocator is disabled.");
                }
            }
            catch (Exception le)
            {
                debugText.Text = ("Location could not be acquired.") + le.Message + " " + le.StackTrace;
            }
            try
            {
                SubmitData();

            } catch (Exception ex)
            {
 
            }

        }

        public void SubmitData()
        {
            try
            {

                Complaint complaint = new Complaint()
                {
                    eyes = Convert.ToInt16(sliderEyes.Value),
                    nose = Convert.ToInt16(sliderNose.Value),
                    lungs = Convert.ToInt16(sliderLungs.Value),
                    medicine = Convert.ToInt16(medicineSwitch.IsToggled),
                    longtitude = position.Longitude.ToString(),
                    latitude = position.Latitude.ToString()
                };

                ComplaintService.Instance.SubmitComplaint(complaint);
                
            }
            catch (Exception ex)
            {
                debugText.Text = ex.Message;
            }
        }
    }
=======
﻿using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using testapp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using testapp.Services;
using testapp.Controllers;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlachtenPage : ContentPage
    {
        IGeolocator locator;
        Position position = null;
        private ComplaintsController controller;
        public Boolean gpsEnabled { get; set; }

        public KlachtenPage()
        {
            InitializeComponent();
            controller = new ComplaintsController(this);
            controller.CheckLocationEnabledAsync();

        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            if (((Slider)sender) == sliderNose )
            {
                valueLabelNose.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if(((Slider)sender) == sliderLungs)
            {
                valueLabelLungs.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if (((Slider)sender) == sliderEyes)
            {
                valueLabelEyes.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (gpsEnabled)
                {
                    SubmitData();
                } else
                {
                    showAlert("Melding", "Uw locatie kan niet opgehaald worden, zet alstublieft uw GPS aan.");
                }

            } catch (Exception ex)
            {
 
            }

        }

        public void SubmitData()
        {
            try
            {

                Complaint complaint = new Complaint()
                {
                    eyes = Convert.ToInt16(sliderEyes.Value),
                    nose = Convert.ToInt16(sliderNose.Value),
                    lungs = Convert.ToInt16(sliderLungs.Value),
                    medicine = Convert.ToInt16(medicineSwitch.IsToggled),
                };

                controller.submitComplaint(complaint);
                
            }
            catch (Exception ex)
            {
                debugText.Text = ex.Message;
            }
        }


        public void showAlert(String alertType, String alertMessage)
        {
            DisplayAlert(alertType, alertMessage, "OK");
        }
    }
>>>>>>> 4dd5491813f3d4a6907d8066097782ead7ef4ed7
}