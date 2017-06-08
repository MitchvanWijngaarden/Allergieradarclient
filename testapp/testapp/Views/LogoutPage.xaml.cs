using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Logout : ContentPage
	{
        public Logout()
        {
            InitializeComponent();
            DeleteLoginData();

            Navigation.PushModalAsync(new RootPage());
        }

        public void DeleteLoginData()
        {
            Settings.Username = null;
            Settings.Password = null;

        }

	}
}