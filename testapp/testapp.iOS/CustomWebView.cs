using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.Drawing;

[assembly: ExportRenderer(typeof(WebView), typeof(testapp.Views.CustomWebView))]
namespace testapp.Views
{
    public class CustomWebView : WebViewRenderer
    {
        public CustomWebView()
        {
        }
    }
}