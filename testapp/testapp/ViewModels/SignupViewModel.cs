using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Xamarin.Forms;
using testapp.ViewModels;
using testapp.Models;

namespace testapp.ViewModels
{
    class SignupViewModel : ContentPage
    {
        Entry usernameEntry, passwordEntry, emailEntry;
        Label messageLabel;

        public SignupViewModel()
        {
            messageLabel = new Label();
            usernameEntry = new Entry
            {
                Placeholder = "username"
            };
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            emailEntry = new Entry();
            var signUpButton = new Button
            {
                Text = "Sign Up"
            };
            signUpButton.Clicked += OnSignUpButtonClicked;

            Title = "Sign Up";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Username" },
                    usernameEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    new Label { Text = "Email address" },
                    emailEntry,
                    signUpButton,
                    messageLabel
                }
            };
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                username = usernameEntry.Text,
                password = passwordEntry.Text,
                emailadres = emailEntry.Text
            };

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPageModel(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.username) && !string.IsNullOrWhiteSpace(user.password) && !string.IsNullOrWhiteSpace(user.emailadres) && user.emailadres.Contains("@"));
        }
    }

}
