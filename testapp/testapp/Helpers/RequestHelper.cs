using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using testapp.Models;

namespace testapp.Helpers
{
    class RequestHelper {

        private string apiURL = Settings.URL;
        private string authenticationToken = LoggedinUser.AccessToken;
        private HttpClient httpClient;
        private StringContent request;
        private HttpResponseMessage response;

        public RequestHelper()
        {
            PrepareRequests();
            AddAuthentication();
        }

        public void PrepareRequests()
        {
            httpClient = new HttpClient();
        }

        public void AddAuthentication()
        {
            var credentials = Encoding.ASCII.GetBytes(authenticationToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }

        public async void PostDataAsync(object o, string apiLocation)
        {
            using (httpClient)
            {
                try
                {
                    String messageBody = JsonConvert.SerializeObject(o);
                    request = new StringContent(messageBody);
                    request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = await httpClient.PostAsync(new Uri(apiURL + apiLocation), request);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }
            }
        }

        public string GetData(string apiLocation)
        {
            using (httpClient)
            {
                try
                {
                    response = httpClient.GetAsync(apiURL +  apiLocation).Result;
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
