using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
[assembly:ExportRenderer(typeof(ListView),typeof(testapp.Views.CustomList))]

namespace testapp.Views
{
    public class CustomList : ListViewRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);

			if (this.Control == null) return;

			this.Control.TableFooterView = new UIView();
		}
    }
}

