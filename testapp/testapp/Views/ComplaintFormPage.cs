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

        /// <summary>
        /// 
        /// </summary>
        public ComplaintFormPage()
        {
            InitializeComponent();
            controller = new ComplaintsController(this);
            controller.CheckLocationEnabledAsync();
            this.BackgroundColor = new Color(0, 0, 0, 0.4);
        }

        /// <summary>
        /// This function gets called when eyes,lungs and nose sliders get touched by the user. Changes the values of the label next to them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            valueLabelNose.Text = Convert.ToInt16(((Slider)sliderNose).Value).ToString();
            valueLabelLungs.Text = Convert.ToInt16(((Slider)sliderLungs).Value).ToString();
            valueLabelEyes.Text = Convert.ToInt16(((Slider)sliderEyes).Value).ToString();
        }

        /// <summary>
        /// Checks if the users' GPS is enabled, if GPS is enabled call the SubmitData method.
        /// </summary>
        public void CheckGPSEnabled()
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

        /// <summary>
        /// Closes the modal the + button on the map page opens.
        /// </summary>
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

 
        /// <summary>
        /// Creates a complaint model from the values entered in the form, sends the created complaint to the controller.
        /// </summary>
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

        /// <summary>
        /// Shows a DisplayAlert on the screen, used so the controller can show messages on the view.
        /// </summary>
        /// <param name="alertType"></param>
        /// <param name="alertMessage"></param>
        public void ShowAlert(String alertType, String alertMessage)
        {
            DisplayAlert(alertType, alertMessage, "OK");
        }
    }
}