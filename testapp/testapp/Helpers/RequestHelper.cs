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

        /// <summary>
        /// Constructor that prepares the requests, adds authentication 
        /// </summary>
        public RequestHelper()
        {
            PrepareRequests();
            AddAuthentication();
        }

        /// <summary>
        /// Prepares the HttpClient to ensure Do not repeat yourself. 
        /// </summary>
        public void PrepareRequests()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Adds the base64 authentication code to the request, used for basic authentication API calls.
        /// </summary>
        public void AddAuthentication()
        {
            var credentials = Encoding.ASCII.GetBytes(authenticationToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }

        /// <summary>
        /// Posts Object O and Apilocation to the API, example: Complaint c to /complaints/
        /// </summary>
        /// <param name="o"></param>
        /// <param name="apiLocation"></param>
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

        /// <summary>
        /// Gets JSON as a string from the api location specified.
        /// </summary>
        /// <param name="apiLocation"></param>
        /// <returns></returns>
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
