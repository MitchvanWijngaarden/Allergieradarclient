using testapp.Models;

using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System;
using testapp.Helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace testapp.Services
{
    public class LoginService<T>
    {
        private static string apiUrl = Settings.URL + "users/me";
        //private const string MainWebServiceUrl = "http://10.0.3.2:8080/";
        // private const string LoginWebServiceUrl = MainWebServiceUrl + "api/users/me?";

        // This code matches the HTTP Request that we included in our api controller
        public async Task<Boolean> checkLogin(string username, string password)
        {
            using (var client = new HttpClient())
            {

                var byteArray = Encoding.ASCII.GetBytes(""+ username + ":" + password + "");

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                HttpContent content = response.Content;

                // ... Check Status Code                                
               // Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

                // ... Read the string.
              //  var jwt = await response.Content.ReadAsStringAsync();

               // JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

                //var accessToken = jwtDynamic.Value<string>("access_token");

               // var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);

                return response.IsSuccessStatusCode; // return either true or false
                //return accessToken;
            }






        }
    }
}