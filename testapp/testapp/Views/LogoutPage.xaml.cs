using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testapp.Helpers;
using testapp.Models;

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
            LoggedinUser.Username = null;
            LoggedinUser.Password = null;
            LoggedinUser.AccessToken = null;
            await DisplayAlert("gelukt!", "U bent nu uitgelogd", "Ok");

        }

    }
}