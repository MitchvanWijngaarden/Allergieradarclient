using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using testapp.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(testapp.Services.MockDataStore))]
namespace testapp.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}
        public String getText(string file)
        {
            
            var content = File.ReadAllText(file);
       

            return content;
        }

		public async Task InitializeAsync()
		{
          
			if (isInitialized)
				return;

			items = new List<Item>();
			var _items = new List<Item>
			{
                new Item { Id = Guid.NewGuid().ToString(), Text = "Allergie", Description= getText("Data/Allergie.txt")},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Hooikoorts en pollen", Description= getText("Data/Hooikoorts veroorzakende pollen.txt")},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Hooikoortsveroorzakers", Description= getText("Data/Hooikoortsenpollen.txt")},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Over Allergieradar", Description= getText("Data/Over AllergieRadar.txt")},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Onderzoekdoelen", Description= getText("Data/Rechten en Privacy.txt")},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Uitleg Allergieradar App", Description= getText("Data/Uitleg van de Allergieradar App.txt")},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Contact", Description= getText("Data/Contact.txt")},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rechten en Privacy",Description= getText("Data/Rechten en Privacy.txt")},
			};

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
