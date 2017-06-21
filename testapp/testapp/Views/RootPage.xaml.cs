﻿using System;
using System.Collections.Generic;
using testapp.Helpers;
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

            

			var page1 = new ViewModels.MenuPageViewModel() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(MapPage) };
			var page2 = new ViewModels.MenuPageViewModel() { Title = "Informatie", Icon = "tab_about.png", TargetType = typeof(InfoPage) };
            var page3 = new ViewModels.MenuPageViewModel() { Title = "Klachten melden", Icon = "itemIcon1.png", TargetType = typeof(KlachtenPage) };
            var loginPage = new ViewModels.MenuPageViewModel() { Title = "Inloggen", Icon = "itemIcon1.png", TargetType = typeof(LoginPage)};
            var logoutPage = new ViewModels.MenuPageViewModel() { Title = "Uitloggen", Icon = "itemIcon1.png,", TargetType = typeof(LogoutPage) };


            menuList.Add(page1);
			menuList.Add(page2);
            menuList.Add(page3);

            if (string.IsNullOrEmpty(Settings.Password))
            {
                menuList.Add(loginPage);
            }

            if (!string.IsNullOrEmpty(Settings.Password))
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
            var page3 = new ViewModels.MenuPageViewModel() { Title = "Klachten melden", Icon = "itemIcon1.png", TargetType = typeof(KlachtenPage) };
            navigationDrawerList.ItemsSource = menuList;


            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MapPage)));
        }
	}
}
