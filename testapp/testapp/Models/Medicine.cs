using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class Medicine
    {
        public int medicineID { get; set; }

        public String medicinename { get; set; }

        public String medicinetype { get; set; }

        public Medicine(dynamic json)
        {
            medicineID = json.medicineID;
            medicinename = json.medicinename;
            medicinetype = json.medicinetype;
        }
    }
}
