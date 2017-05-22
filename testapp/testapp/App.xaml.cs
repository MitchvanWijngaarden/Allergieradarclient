using testapp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace testapp
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();
			MainPage = new Views.RootPage();
			
		}


	}
}
