using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using testapp.ViewModels;
using testapp.Models;
using testapp.Controllers;
using System.Diagnostics;
using testapp.Services;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
        private SignUpController controller;

		public SignUpPage ()
		{
			InitializeComponent ();
            controller = new SignUpController(this);
		}

        public async Task OnSignUpButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text)
                && !string.IsNullOrWhiteSpace(emailEntry.Text) && emailEntry.Text.Contains("@"))
            {
                User.Instance.username = usernameEntry.Text;
                User.Instance.password = passwordEntry.Text;
                User.Instance.emailadres = emailEntry.Text;

                Task<int> t = SignUpService.Instance.GetUserIdByUsername();

                int userID = await t;

                if (userID == 0)
                {
                    UserAnswers.Instance.useranswers.Clear();
                    Navigation.PushModalAsync(new QuestionPage("1"));
                    //Navigation.PushModalAsync(new MedicinePage());
                }
                else
                {
                    DisplayAlert("Gebruikersnaam al in gebruik!", "De ingevulde gebruikersnaam is al in gebruik. Kies een andere", "Ok");
                }
            }
            else
            {
                DisplayAlert("Missende/verkeerde gegevens!", "Vul alle gegevens volledig en correct in", "Ok");
            }
            
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                username = usernameEntry.Text,
                password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPageModel(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.username == Constants.Username && user.password == Constants.Password;
        }
    }
}
