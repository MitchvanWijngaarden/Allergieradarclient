﻿using System;
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
			NavigationPage.SetTitleIcon(this, "allergieradar_logo.png");

			var browser = new BaseUrlWebView (); // temporarily use this so we can custom-render in iOS

			var htmlSource = new HtmlWebViewSource ();

			htmlSource.Html = @"<html>
<head>
<link rel=""stylesheet"" href=""default.css"">
<script>
window.location.replace(""country.html"");
</script>
</head>
<body>

</body>
</html>";

			htmlSource.BaseUrl = DependencyService.Get<IBaseUrl> ().Get ();


			browser.Source = htmlSource;


            Content = browser;



        }
	}
}

