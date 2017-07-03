using System;
using Xamarin.Forms;
using WorkingWithWebview.Android;
using testapp.Views;

[assembly: Dependency (typeof (BaseUrl_Android))]
namespace WorkingWithWebview.Android 
{
	public class BaseUrl_Android : IBaseUrl 
	{
		public string Get () 
		{
			return "file:///android_asset/";
		}
	}
}