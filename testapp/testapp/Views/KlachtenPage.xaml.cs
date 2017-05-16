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

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlachtenPage : ContentPage
    {
        public KlachtenPage()
        {
			InitializeComponent ();
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
    }
}