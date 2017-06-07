using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Helpers
{
    class SettingsSingleton
    {
        private static SettingsSingleton instance;

        private static string apiUrl = "http://145.101.89.97:8080/api/";

        private SettingsSingleton() { }

        public static SettingsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsSingleton();
                }
                return instance;
            }
        }

        public static string getApiUrl()
        {
            return apiUrl;
        }
    }
}
