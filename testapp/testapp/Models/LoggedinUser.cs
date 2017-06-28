using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace testapp.Models
{
    public static class LoggedinUser
    {
        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("AccessToken", value);
            }
        }
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
    }
}
