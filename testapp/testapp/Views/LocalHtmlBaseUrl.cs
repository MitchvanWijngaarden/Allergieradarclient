using System;
using Xamarin.Forms;

namespace WorkingWithWebview
{

	public interface IBaseUrl { string Get(); }

	// required temporarily for iOS, due to BaseUrl bug
	public class BaseUrlWebView : WebView { }

	public class LocalHtmlBaseUrl : ContentPage
	{
		public LocalHtmlBaseUrl ()
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
<<<<<<< HEAD
<iframe src=""country.html"" frameborder=""0"" style=""overflow: hidden; height: 100%; width: 100%"" height=""100%"" width=""100%""></iframe>
=======
<iframe src=""country.html"" frameborder=""0"" style=""overflow: hidden; height: 100%; width: 100%"" height=""100%"" width=""100%""></iframe>
>>>>>>> a67c4bc67de96d4b56cff45f4aed225ee6095f25
</body>
</html>";

			htmlSource.BaseUrl = DependencyService.Get<IBaseUrl> ().Get ();


<<<<<<< HEAD
			browser.Source = htmlSource;


            Content = browser;



=======
			browser.Source = htmlSource;


            Content = browser;



>>>>>>> a67c4bc67de96d4b56cff45f4aed225ee6095f25
        }
	}
}

