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
                MainPage = new Views.RootPage();
            }
            else
            {
                MainPage = new Views.RootPage();
            }

            

        }


    }
}