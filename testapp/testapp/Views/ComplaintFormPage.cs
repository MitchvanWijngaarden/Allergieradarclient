using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testapp.Models;
using testapp.Controllers;
using System.Diagnostics;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplaintFormPage : ContentPage
    {
        private ComplaintsController controller;

        public ComplaintFormPage()
        {
            InitializeComponent();
            controller = new ComplaintsController(this);
            controller.CheckLocationEnabledAsync();
            this.BackgroundColor = new Color(0, 0, 0, 0.4);
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            valueLabelNose.Text = Convert.ToInt16(((Slider)sliderNose).Value).ToString();
            valueLabelLungs.Text = Convert.ToInt16(((Slider)sliderLungs).Value).ToString();
            valueLabelEyes.Text = Convert.ToInt16(((Slider)sliderEyes).Value).ToString();
        }

        public void CheckGPSEnabled(object sender, EventArgs e)
        {
            try
            {
                if (!controller.gpsEnabled)
                {
                    ShowAlert("Melding", "Uw locatie kan niet opgehaald worden, zet alstublieft uw GPS aan.");
                    return;
                }
                SubmitData();
            }
            catch (Exception ex)
            {
                debugText.Text = ex.Message;
            }

        }

        private void ReturnToMap()
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
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
                    medicine = Convert.ToByte(medicineSwitch.IsToggled),
                };

                controller.SubmitComplaint(complaint);
                ReturnToMap();
                
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }


        public void ShowAlert(String alertType, String alertMessage)
        {
            DisplayAlert(alertType, alertMessage, "OK");
        }
    }
}