using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Net;
using testapp.Models;
using Java.Sql;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KlachtenPage : ContentPage
    {
        IGeolocator locator;

        public KlachtenPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            /*if (((Slider)sender) == sliderNose )
            {
                valueLabelNose.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if(((Slider)sender) == sliderLungs)
            {
                valueLabelLungs.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            } else if (((Slider)sender) == sliderEyes)
            {
                valueLabelEyes.Text = Convert.ToInt16(((Slider)sender).Value).ToString();
            }*/
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Position position = null;
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                // Get the current device position. Leave it null if geo-location is disabled,
                // return position (0, 0) if unable to acquire.
                if (locator.IsGeolocationEnabled)
                {
                    // Allow ten seconds for geo-location determination.                    
                    position = await locator.GetPositionAsync(10000);
                    debugText.Text = "Position: " + position.Latitude + "lat" + position.Longitude + "long";
                }
                else
                {
                    debugText.Text = ("Location could not be acquired, geolocator is disabled.");
                }
            }
            catch (Exception le)
            {
                debugText.Text = ("Location could not be acquired.") + le.Message + " " + le.StackTrace;
            }
            try
            {
                submitData();


                /*WebRequest req = WebRequest.Create("http://145.101.90.240:8080/api/complaints");
                req.Method = "POST";
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("test:test"));
                


                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                debugText.Text = resp.GetResponseStream().ToString();

                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(resp.GetResponseStream(), encoding))
                {
                    debugText.Text = reader.ReadToEnd();
                }*/

 



                /*using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    result = client.UploadString(url, "POST", json);
                }
                debugText.Text = result;*/

                /*WebRequest req = WebRequest.Create("http://145.101.90.240:8080/api/complaints");
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("test:test"));
                req.ContentType = "application/json; charset=utf-8";
                req.Method = "POST";

                using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                using (var streamReader = new StreamReader(resp.GetResponseStream()))
                {
                    debugText.Text = streamReader.ReadToEnd();
                } */



            } catch (Exception ex)
            {
                //debugText.Text = ex.ToString();
            }

        }

        public async void submitData()
        {
            try
            {

                Complaint complaint = new Complaint();
                complaint.complaintID = 2;
                
                complaint.eyes = 1;
                complaint.nose = 2;
                complaint.lungs = 7;
                complaint.medicine = 0;
                complaint.longtitude = "-18.5333";
                complaint.latitude = "65.9667";

                String json = JsonConvert.SerializeObject(complaint);


                string apiUrl= "http://145.101.90.211:8080/api/complaints";

                /*
                 var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                 httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("test:test"));
                 httpWebRequest.ContentType = "application/json; charset=utf-8";
                 httpWebRequest.Method = "POST";

                 using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                 {

                     streamWriter.Write(json);
                     streamWriter.Flush();
                 }
                 var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                 using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                 {
                     var responseText = streamReader.ReadToEnd();
                     debugText.Text = responseText;


                     //Now you have your response.
                     //or false depending on information in the response     
                 } */


                HttpResponseMessage response;
                String messageBody = json;
                if (String.IsNullOrEmpty(apiUrl))
                {
                    throw new ApplicationException("apiUrl required");
                }

                using (var httpClient = new HttpClient())
                {
                    var request = new StringContent(messageBody);
                    request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var credentials = Encoding.ASCII.GetBytes("test:test");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                    response = await httpClient.PostAsync(new Uri(apiUrl), request);
                    debugText.Text = messageBody;
                }
                
            }
            catch (WebException ex)
            {
                /*debugText.Text = ex.Message;*/
            }
        }
    }
}