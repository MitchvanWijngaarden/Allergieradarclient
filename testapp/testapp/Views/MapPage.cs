using System;
using testapp.Views;
using testapp.Views.Components;
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
            //NavigationPage.HeightProperty(this,50);
			var browser = new BaseUrlWebView (); // temporarily use this so we can custom-render in iOS

			var htmlSource = new HtmlWebViewSource ();

			htmlSource.Html = @"
                <html>
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

            AbsoluteLayout simpleLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            var bottomRightLabel = new ActionButton();
            bottomRightLabel.Margin = 5;

            var command = new Command(() => testGeval() );

            bottomRightLabel.Command = command;


            AbsoluteLayout.SetLayoutFlags(bottomRightLabel,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutFlags(bottomRightLabel,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(bottomRightLabel,
                new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));



            AbsoluteLayout.SetLayoutFlags(browser,
                AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(browser,
                new Rectangle(0, 0, 1, 1));


            simpleLayout.Children.Add(browser);
            simpleLayout.Children.Add(bottomRightLabel);

            Content = simpleLayout;

        }

        async void testGeval()
        {
            var detailPage = new KlachtenPage();
            await Navigation.PushModalAsync(detailPage);
        }
	}
}

