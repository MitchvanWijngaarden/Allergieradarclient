using testapp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace testapp
{
	public partial class App : Application
	{

        public static bool IsUserLoggedIn { get; set; }
        public App()
		{
			InitializeComponent();

	

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                SetMainPage();
            }
        }

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new KlachtenPage())
                    {
                        Title = "Klachten",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new LoginPage())
                    {
                        Title = "Inloggen",
                        Icon = Device.OnPlatform<string>("tab_about.png", null,null)
                    }
                }
            };
        }
	}
}
