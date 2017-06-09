using System;
using Xamarin.Forms;

namespace WorkingWithWebview
{

	public interface IBaseUrl { string Get(); }

	// required temporarily for iOS, due to BaseUrl bug
	public class BaseUrlWebView : WebView { }

	public class MapPage : ContentPage
	{
		public MapPage ()
		{
			var browser = new BaseUrlWebView (); // temporarily use this so we can custom-render in iOS

			var htmlSource = new HtmlWebViewSource ();

			htmlSource.Html = @"<html>
<head>
<link rel=""stylesheet"" href=""default.css"">
<script>

</script>
</head>
<body>
<iframe src=""country.html"" frameborder=""0"" style=""overflow: hidden; height: 100%; width: 100%"" height=""100%"" width=""100%""></iframe>
</body>
</html>";

			htmlSource.BaseUrl = DependencyService.Get<IBaseUrl> ().Get ();


			browser.Source = htmlSource;


            Content = browser;



        }
	}
}

