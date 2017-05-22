using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlachtenPage : ContentPage
    {
        IGeolocator locator;

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
                Position position = null;
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                // Get the current device position. Leave it null if geo-location is disabled,
                // return position (0, 0) if unable to acquire.
                if (locator.IsGeolocationEnabled)
                {
                    // Allow ten seconds for geo-location determination.                    
                    //position = await locator.GetPositionAsync(10000);
                    debugText.Text = "Position: " + position.Latitude + "lat" + position.Longitude + "long";
                }
                else
                {
                    Console.WriteLine("Location could not be acquired, geolocator is disabled.");
                }
            }
            catch (Exception le)
            {
                // TODO: Log this error.
                Console.WriteLine("Location could not be acquired.");
                Console.WriteLine(le.Message);
                Console.WriteLine(le.StackTrace);
                // position = new Position() { Latitude = 0, Longitude = 0 };
            }
        }
    }
}