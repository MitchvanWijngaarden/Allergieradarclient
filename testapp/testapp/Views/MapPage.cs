using System;
using Xamarin.Forms;
using testapp.Helpers;
using testapp.Models;
using NControl.Controls;
namespace testapp.Views
{

    public interface IBaseUrl { string Get(); }

    // required temporarily for iOS, due to BaseUrl bug
    public class BaseUrlWebView : WebView { }

    public class MapPage : ContentPage
    {

        public MapPage()
        {
            NavigationPage.SetTitleIcon(this, "allergieradar_tab.png");
            //NavigationPage.HeightProperty(this,50);
            var browser = new BaseUrlWebView(); // temporarily use this so we can custom-render in iOS



            var htmlSource = new HtmlWebViewSource()
            {
                Html = @"
                <html>
                    <head>
                        <link rel=""stylesheet"" href=""default.css"">
                         <script>
                            window.location.replace(""country.html"");
                        </script>
                    </head>
                    <body>
                    </body>
                </html>",

                BaseUrl = DependencyService.Get<IBaseUrl>().Get()
            };

            browser.Source = htmlSource;

            AbsoluteLayout simpleLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            //var bottomRightLabel = new ActionButton()
            //{
            //	Margin = 5
            //};
            var bottomRightLabel = new NControl.Controls.ActionButton
            {
                ButtonColor = Color.FromHex("#E91E63"),
                ButtonIcon = FontAwesomeLabel.FAThumbsUp,
            };

            var command = new Command(() => OpenModal());

            bottomRightLabel.Command = command;

            //AbsoluteLayout.SetLayoutFlags(bottomRightLabel,
            //	AbsoluteLayoutFlags.PositionProportional);

            //AbsoluteLayout.SetLayoutFlags(bottomRightLabel,
            //AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(bottomRightLabel,
                new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(browser,
                AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(browser,
                new Rectangle(0, 0, 1, 1));

            simpleLayout.Children.Add(browser);

            if (!string.IsNullOrEmpty(LoggedinUser.Password))
                simpleLayout.Children.Add(bottomRightLabel, new Rectangle((simpleLayout.Width / 4) - (56 / 2), (simpleLayout.Height / 2) - (56 / 2), 56, 56));

            Content = simpleLayout;
        }

        async void OpenModal()
        {
            var detailPage = new ComplaintFormPage();
            await Navigation.PushModalAsync(detailPage);
        }
    }
}