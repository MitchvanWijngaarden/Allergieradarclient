using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class UserMedicine
    {
        public int userID { get; set; }
        public int medicineID { get; set; }

        public UserMedicine(int medicineID)
        {
            this.medicineID = medicineID;
        }
    }
}
