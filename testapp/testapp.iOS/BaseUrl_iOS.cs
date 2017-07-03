using Xamarin.Forms;
using WorkingWithWebview.iOS;
using Foundation;

[assembly: Dependency (typeof (BaseUrl_iOS))]

namespace WorkingWithWebview.iOS 
{
	public class BaseUrl_iOS : testapp.Views.IBaseUrl
    {
		public string Get () 
		{
			return NSBundle.MainBundle.BundlePath;
		}
	}
}