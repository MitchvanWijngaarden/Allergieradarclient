using System;
namespace testapp.Models
{
    public class Weather
    {
       
            public String locationNr { get; set; }
            public String location { get; set; }
            public String text { get; set; }
            public int minTemp { get; set; }
            public int maxTemp { get; set; }
            public int icon { get; set; }

    }
}
