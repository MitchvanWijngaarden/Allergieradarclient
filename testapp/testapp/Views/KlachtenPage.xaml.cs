
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
            this.BackgroundColor = new Color(0, 0, 0, 0.4);

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

        private void SubmitData(object sender, EventArgs e)
        {

            try
            {
                if (gpsEnabled)
                {
                    SubmitData();
                    Navigation.PopModalAsync();
                } else
                {
                    showAlert("Melding", "Uw locatie kan niet opgehaald worden, zet alstublieft uw GPS aan.");
                }

            } catch (Exception ex)
            {
 
            }

        }

        private void ReturnToMap(object sender, EventArgs e)
        {

            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
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

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}