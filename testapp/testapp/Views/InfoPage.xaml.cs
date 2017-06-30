using System;
using System.Collections.Generic;
using System.Diagnostics;
using testapp.Views.AboutPages;
using Xamarin.Forms;

namespace testapp.Views
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
			
				InitializeComponent();

				this.BindingContext = new[] { 
                "Allergie", "Hooikoorts en Pollen",                           
                "Hooikoortsveroorzakers","Over Allergieradar",                             
                "Onderzoekdoelen","Uitleg Allergieradar App",
                "Contact","Rechten en Privacy" };


			}

		void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
		{
				var pages = ((ListView)sender).SelectedItem;

            if (pages == null)
				{
					return;
				}

				ContentPage page = null;

            switch (pages)
				{
					case "Allergie":
						page = new Allergie();
						break;
					case "Hooikoorts en Pollen":
						page = new Hooikoorts_en_Pollen();
						break;
					case "Hooikoortsveroorzakers":
						page = new Hooikoortsveroorzakers();
						break;
					case "Over Allergieradar":
						page = new Over_Allergieradar();
						break;
					case "Onderzoekdoelen":
						page = new Onderzoekdoelen();
						break;
					case "Uitleg Allergieradar App":
						page = new Uitleg_Allergieradar_App();
						break;
					case "Contact":
						page = new Contact();
						break;
					case "Rechten en Privacy":
						page = new Rechten_en_Privacy();
						break;

				}

				page.BindingContext = pages;
				Navigation.PushAsync(page);
			
            ((ListView)sender).SelectedItem = null;
			Content = listView;

			}

        }
    }

