using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapp.Controllers;
using testapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemainingQuestions : ContentPage
	{
        private QuestionController controller;

        public RemainingQuestions ()
		{
            InitializeComponent();
            controller = new QuestionController();
        }

        private void Button_End(object sender, EventArgs e)
        {
            int year_of_birth;
            int zip_code;

            if (yearEntry.Text.Length == 4 && int.TryParse(yearEntry.Text, out year_of_birth) && (genderEntry.Text == "m" || genderEntry.Text == "v") &&
                zipcodeEntry.Text.Length == 4 && int.TryParse(zipcodeEntry.Text, out zip_code))
            {
                Navigation.PopModalAsync();
                User.Instance.year_of_birth = year_of_birth;
                User.Instance.gender = genderEntry.Text;
                User.Instance.zip_code = zip_code;

                controller.SendData();

                Navigation.PopModalAsync();
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Missende/verkeerde gegevens!", "Vul alle gegevens volledig en correct in", "Ok");
            }
        }
    }
}