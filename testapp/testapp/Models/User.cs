using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    public class User
    {
        private static User instance;

        public static User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new User();
                }
                return instance;
            }
    }
        public String username { get; set; }
        
        public String emailadres { get; set; }

        public int year_of_birth { get; set; }

        public String gender { get; set; }

        public int zip_code { get; set; }
        
        public String password { get; set; }
    }
}
