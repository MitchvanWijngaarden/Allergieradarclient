using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async void PostDataAsync(object o, string location)
        {
            HttpResponseMessage response;

            using (httpClient)
            {
                try
                {
                    String messageBody = JsonConvert.SerializeObject(o);
                    request = new StringContent(messageBody);
                    request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = await httpClient.PostAsync(new Uri(location), request);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }
            }
        }

        public async System.Threading.Tasks.Task<HttpResponseMessage> GetDataAsync(string location)
        {
            using (httpClient)
            {
                HttpResponseMessage response = null;
                try
                {
                    response = await httpClient.GetAsync(location);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                }
                return response;
            }
        }
    }
}
