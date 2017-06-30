using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class UserMedicines
    {
        private static UserMedicines instance;

        public List<UserMedicine> usermedicines { get; set; }

        public UserMedicines()
        {
            usermedicines = new List<UserMedicine>();
        }

        public static UserMedicines Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserMedicines();
                }
                return instance;
            }
        }

        public void AddUserMedicine(int medicineID)
        {
            UserMedicine usermedicine = new UserMedicine(medicineID);
            usermedicines.Add(usermedicine);
        }

        public void DeleteUserMedicine(int medicineID)
        {
            usermedicines.RemoveAll(x => x.medicineID == medicineID);
        }
    }
}
