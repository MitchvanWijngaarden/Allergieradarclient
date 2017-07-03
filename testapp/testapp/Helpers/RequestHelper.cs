using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using testapp.Models;

namespace testapp.Helpers
{
	class RequestHelper
	{

		private string apiURL = Settings.URL;
		private string authenticationToken = LoggedinUser.AccessToken;
		private StringContent request;
		private HttpResponseMessage response;


		/// <summary>
		/// Posts Object O and Apilocation to the API, example: Complaint c to /complaints/
		/// </summary>
		/// <param name="o"></param>
		/// <param name="apiLocation"></param>
		public async void PostDataAsync(object o, string apiLocation)
		{
			HttpClient httpClient = new HttpClient();
			using (httpClient)
			{
				try
				{
					String messageBody = JsonConvert.SerializeObject(o);
					//Debug.Write("Object post:" + messageBody);
					request = new StringContent(messageBody);
					request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
					var credentials = Encoding.ASCII.GetBytes(authenticationToken);
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

					response = await httpClient.PostAsync(new Uri(apiURL + apiLocation), request);


				}
				catch (Exception ex)
				{
					Debug.Write("Post error:" + ex.Message);
				}
			}
		}

		/// <summary>
		/// Gets JSON as a string from the api location specified.
		/// </summary>
		/// <param name="apiLocation"></param>
		/// <returns></returns>
		public string GetData(string apiLocation)
		{
			HttpClient httpClient = new HttpClient();
			using (httpClient)
			{
				try
				{
					var credentials = Encoding.ASCII.GetBytes(authenticationToken);
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
					response = httpClient.GetAsync(apiURL + apiLocation).Result;
				}
				catch (Exception ex)
				{
					Debug.Write(ex.Message);
				}
				return response.Content.ReadAsStringAsync().Result;
			}
		}
	}
}