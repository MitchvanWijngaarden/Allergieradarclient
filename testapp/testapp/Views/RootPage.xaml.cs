using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace testapp.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public List<ViewModels.MenuPageViewModel> menuList { get; set; }
        public RootPage()
        {
           
			InitializeComponent();

			menuList = new List<ViewModels.MenuPageViewModel>();

		
			var page1 = new ViewModels.MenuPageViewModel() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(HomePage) };
			var page2 = new ViewModels.MenuPageViewModel() { Title = "Informatie", Icon = "itemIcon1.png", TargetType = typeof(ItemsPage) };


			
			menuList.Add(page1);
			menuList.Add(page2);
		
			navigationDrawerList.ItemsSource = menuList;

			
			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }


		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			var item = (ViewModels.MenuPageViewModel)e.SelectedItem;
			Type page = item.TargetType;

			Detail = new NavigationPage((Page)Activator.CreateInstance(page));
			IsPresented = false;
		}
    }
}
