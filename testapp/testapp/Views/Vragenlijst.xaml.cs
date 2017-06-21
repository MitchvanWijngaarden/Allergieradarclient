using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vragenlijst : ContentPage
	{
		public Vragenlijst ()
		{
			InitializeComponent ();
		}

        private void Button_Next(object sender, EventArgs e)
        {

        }

        private void Button_Back(object sender, EventArgs e)
        {

        }
    }
}