using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testapp.Helpers;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
            DeleteLoginData();

            Navigation.PushModalAsync(new RootPage());
        }

        private async void DeleteLoginData()
        {
            Settings.Username = null;
            Settings.Password = null;
            await DisplayAlert("gelukt!", "U bent nu ingelogd", "Ok");

        }

    }
}