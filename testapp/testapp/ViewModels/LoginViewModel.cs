using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using testapp.ViewModels;
using testapp.Models;
using testapp.Services;
using System.Threading.Tasks;

namespace testapp.ViewModels
{
    public class LoginViewModel : ContentPage
    {

      
        LoginService<User> loginService = new LoginService<User>();

        // Boolean function with the following parameters of username & password.
        public async Task<Boolean> CheckLoginIfExists(string username, string password)
        {
            var check = await loginService.checkLogin(username, password);

            return check;
        }

        


    }

}
