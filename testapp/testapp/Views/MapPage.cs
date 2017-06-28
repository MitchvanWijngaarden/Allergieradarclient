using System;
using Xamarin.Forms;
using testapp.Helpers;
using testapp.Views.Components;
using testapp.Models;
using testapp.Controllers;
using System.Diagnostics;

namespace testapp.Views
{

	public interface IBaseUrl { string Get(); }

	// required temporarily for iOS, due to BaseUrl bug
	public class BaseUrlWebView : WebView { }


    public class MapPage : ContentPage
	{

    
	
		    private Label globalComplaintScore;

        public MapPage ()
		{
			NavigationPage.SetTitleIcon(this, "allergieradar_tab.png");

            //NavigationPage.HeightProperty(this,50);
			var browser = new BaseUrlWebView (); // temporarily use this so we can custom-render in iOS



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

            var bottomRightLabel = new ActionButton()
            {
                Margin = 20,
                FillColor = Color.FromHex("#2196F3")

            };

            var command = new Command(() => OpenModal() );

            bottomRightLabel.Command = command;

            globalComplaintScore = new Label()
            {
                Margin = 15,
                Text = "10",
                FontSize = 40,
                TextColor = Color.White,
                IsVisible = true
            };

            GetGlobalComplaintScore();

            Label globalComplaintText = new Label()
            {
                Margin = 15,
                Text = "Landelijke\nklachtenscore",
                FontSize = 16,
                TextColor = Color.White,
                IsVisible = true
            };

            AbsoluteLayout.SetLayoutFlags(bottomRightLabel,
                AbsoluteLayoutFlags.PositionProportional);
    
            AbsoluteLayout.SetLayoutBounds(bottomRightLabel,
                new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(browser,
                AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(browser,
                new Rectangle(0, 0, 1, 1));

            AbsoluteLayout.SetLayoutBounds(globalComplaintScore,
                new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(globalComplaintText,
                new Rectangle(0f, 50f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            simpleLayout.Children.Add(browser);
            simpleLayout.Children.Add(globalComplaintScore);
            simpleLayout.Children.Add(globalComplaintText);

            if (!string.IsNullOrEmpty(LoggedinUser.Password))
                simpleLayout.Children.Add(bottomRightLabel);

            Content = simpleLayout;
        }

        async void OpenModal()
        {
            var detailPage = new ComplaintFormPage();
            await Navigation.PushModalAsync(detailPage);
        }

        void GetGlobalComplaintScore()
        {
            ComplaintsController controller = new ComplaintsController();

            int totalComplaints = 0;
            int totalLungs = 0;
            int totalEyes = 0;
            int totalNose = 0;

            try
            {
                foreach (Complaint complaint in controller.GetComplaints())
                {
                    string format = "dd-MM-yyyy";
                    var todayDate = DateTime.Now.ToString(format);
                    var complaintDate = complaint.date.ToString(format);

                    if (complaintDate == todayDate)
                    {
                        totalNose += complaint.nose;
                        totalEyes += complaint.eyes;
                        totalLungs += complaint.lungs;

                        totalComplaints++;
                    }

                }
                int averageLungs = (totalLungs / totalComplaints);
                int averageEyes = (totalEyes / totalComplaints);
                int averageNose = (totalNose / totalComplaints);

                Debug.WriteLine("Average lungs : " + averageLungs);
                Debug.WriteLine("Average eyes: " + averageEyes);
                Debug.WriteLine("Average nose : " + averageNose);

                int totalAverage = (averageEyes + averageLungs + averageNose) / 3;

                globalComplaintScore.Text = totalAverage.ToString();
            } catch (Exception ex)
            {
                Debug.WriteLine("FFF " + ex);
            }
            
        }
	}
}
