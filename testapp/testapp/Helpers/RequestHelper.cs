using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace testapp.Helpers
{
    class RequestHelper
    {
        private string authenticationToken = Settings.Username + ":" + Settings.Password;
        private HttpClient httpClient = new HttpClient();
        private StringContent request;

        public RequestHelper()
        {
            var credentials = Encoding.ASCII.GetBytes(authenticationToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }

        public async void PostDataAsync(object o, string apiLocation)
        {
            HttpResponseMessage response;

            using (httpClient)
            {
                try
                {
                    String messageBody = JsonConvert.SerializeObject(o);
                    request = new StringContent(messageBody);
                    request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = await httpClient.PostAsync(new Uri(apiLocation), request);
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
                HttpResponseMessage response = null;
                try
                {
                    response = httpClient.GetAsync(apiLocation).Result;
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
