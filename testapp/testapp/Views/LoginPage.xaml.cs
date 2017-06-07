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
        public LoginPage()
        {
            InitializeComponent();
            usernameEntry.Text = Settings.Username;
            passwordEntry.Text = Settings.Password;
            

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


                Settings.Username = usernameEntry.Text;
                Settings.Password = passwordEntry.Text;

            if (getLoginDetails)
            {
                await DisplayAlert("Login success", "You are login", "Okay", "Cancel");
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
            }
            catch (Exception ex)
            {
                debugText.Text = ex.Message;
            }
        }

      
        


    }
}