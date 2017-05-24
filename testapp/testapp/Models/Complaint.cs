using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class Complaint
    {
        public int complaintID { get; set; }
        //public DateTime date { get; set; }
        public int eyes { get; set; }
        public int lungs { get; set; }
        public int nose { get; set; }
        public int medicine { get; set; }
        public String latitude { get; set; }
        public String longtitude { get; set; }
    }
}