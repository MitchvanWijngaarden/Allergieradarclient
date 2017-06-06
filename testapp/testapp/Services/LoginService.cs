using testapp.Models;

using RestSharp.Authenticators;
using RestSharp;
using System;
using RestSharp.Deserializers;
using System.Threading.Tasks;
using System.Net.Http;

namespace testapp.Services
{
    public class LoginService<T>
    {
        private const string MainWebServiceUrl = "http://10.0.3.2:8080/";
        private const string LoginWebServiceUrl = MainWebServiceUrl + "api/users/me?";




        // This code matches the HTTP Request that we included in our api controller
        //public async Task<bool> checkLogin(string username, string password)
        //{


           // var httpClient = new HttpClient();
            
            //var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);

            //return response.IsSuccessStatusCode; // return either true or false


      




        //}
    }
}