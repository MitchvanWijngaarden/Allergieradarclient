using testapp.Helpers;

namespace testapp.Controllers
{
    class WeatherService
    {
        private static WeatherService instance;
        private static string locationApiURL = "";
        private static string weatherApiURL = "";
        private RequestHelper requestHelper;

        private WeatherService()
        {
            requestHelper = new RequestHelper();
        }
    }
}