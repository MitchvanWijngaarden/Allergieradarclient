﻿﻿using System;
using System.Collections.Generic;
using testapp.Models;
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

            

			var page1 = new ViewModels.MenuPageViewModel() { Title = "Kaart", Icon = "001-map-location.png", TargetType = typeof(MapPage) };
			var page2 = new ViewModels.MenuPageViewModel() { Title = "Informatie", Icon = "tab_about.png", TargetType = typeof(InfoPage) };
            var page3 = new ViewModels.MenuPageViewModel() { Title = "Klachten melden", Icon = "itemIcon1.png", TargetType = typeof(ComplaintFormPage) };
            var weer = new ViewModels.MenuPageViewModel() { Title = "Weer", Icon = "001-sun.png", TargetType = typeof(WeatherPage) };
            var news = new ViewModels.MenuPageViewModel() { Title = "Nieuws", Icon = "003-newspaper.png", TargetType = typeof(RssFeedPage) };
            var loginPage = new ViewModels.MenuPageViewModel() { Title = "Inloggen", Icon = "001-login.png", TargetType = typeof(LoginPage)};
            var logoutPage = new ViewModels.MenuPageViewModel() { Title = "Uitloggen", Icon = "002-logout.png", TargetType = typeof(LogoutPage) };


            menuList.Add(page1);
			menuList.Add(weer);
            menuList.Add(news);
            menuList.Add(page2);

   

            if (string.IsNullOrEmpty(LoggedinUser.AccessToken))
            {
                menuList.Add(loginPage);
            }

            if (!string.IsNullOrEmpty(LoggedinUser.AccessToken))
            {
                menuList.Add(logoutPage);
            }
            

			navigationDrawerList.ItemsSource = menuList;


			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MapPage)));
		}


		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			var item = (ViewModels.MenuPageViewModel)e.SelectedItem;
			Type page = item.TargetType;

			Detail = new NavigationPage((Page)Activator.CreateInstance(page));
			IsPresented = false;
		}

        public void ChangeLoginButton()
        {
            menuList.Clear();
            var page1 = new ViewModels.MenuPageViewModel() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(MapPage) };
            var page2 = new ViewModels.MenuPageViewModel() { Title = "Informatie", Icon = "tab_about.png", TargetType = typeof(InfoPage) };
            //var page3 = new ViewModels.MenuPageViewModel() { Title = "Klachten melden", Icon = "itemIcon1.png", TargetType = typeof(ComplaintFormPage) };
            navigationDrawerList.ItemsSource = menuList;


            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MapPage)));
        }
	}
}
