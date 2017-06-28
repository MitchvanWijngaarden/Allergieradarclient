using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using testapp.Models;
using testapp.ViewModels;
using testapp.Helpers;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string Username {  get; set;  }
        public string Password { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            Username = LoggedinUser.Username;
            Password = LoggedinUser.Password;
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {


                LoginViewModel services = new LoginViewModel();
                var getLoginDetails = await services.CheckLoginIfExists(usernameEntry.Text, passwordEntry.Text);
                // var accesstoken = await services.CheckLoginIfExists(usernameEntry.Text, passwordEntry.Text);
                //Settings.AccessToken = accesstoken;


                if (getLoginDetails)
                {
                    await DisplayAlert("gelukt!", "U bent nu ingelogd", "Ok");

                    LoggedinUser.Username = usernameEntry.Text;
                    LoggedinUser.Password = passwordEntry.Text;
                    LoggedinUser.AccessToken = usernameEntry.Text + ":" + passwordEntry.Text;


                    await Navigation.PushModalAsync(new RootPage());
                    // await RootPage.ChangeLoginButton();

                    

                }
                else
                {
                    await DisplayAlert("Inloggen mislukt!", "Gebruikersnaam en/of wachtwoord niet correct", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }





    }
}