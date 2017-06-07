using System;
using System.Collections.Generic;
using WorkingWithWebview;
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


			var page1 = new ViewModels.MenuPageViewModel() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(LocalHtmlBaseUrl) };
			var page2 = new ViewModels.MenuPageViewModel() { Title = "Informatie", Icon = "tab_about.png", TargetType = typeof(ItemsPage) };
            var page3 = new ViewModels.MenuPageViewModel() { Title = "Klachten melden", Icon = "itemIcon1.png", TargetType = typeof(KlachtenPage) };
            var loginPage = new ViewModels.MenuPageViewModel() { Title = "Inloggen", Icon = "itemIcon1.png", TargetType = typeof(LoginPage)};
             


			menuList.Add(page1);
			menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(loginPage);

			navigationDrawerList.ItemsSource = menuList;


			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(LocalHtmlBaseUrl)));
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
