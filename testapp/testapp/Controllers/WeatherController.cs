using System;
using System.Collections.Generic;
using testapp.Models;
using testapp.Views;
using Newtonsoft.Json;

namespace testapp.Controllers
{
    public class WeatherController
    {
        private WeatherPage view;

        public WeatherController(WeatherPage view)
        {
            this.view = view;
        }

		public WeatherController()
		{
			
		}

		public List<Weather> GetWeather()
		{
			List<Weather> list = new List<Weather>();
			var json = WeatherService.Instance.GetAllComplaints();

			IEnumerable<Weather> result = JsonConvert.DeserializeObject<IEnumerable<Weather>>(json);

			foreach (Weather w in result)
			{
				list.Add(w);
			}

			return list;

		}

    }
}
