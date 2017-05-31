using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using testapp.Models;

namespace testapp.Services
{
    class ComplaintService
    {
        private static ComplaintService instance;

        private static string apiUrl = "http://145.101.90.240:8080/api/complaint";

        private ComplaintService() { }

        public static ComplaintService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComplaintService();
                }
                return instance;
            }
        }

        public async void SubmitComplaintAsync(Complaint complaint)
        {
            HttpResponseMessage response;
            String messageBody = JsonConvert.SerializeObject(complaint);


            using (var httpClient = new HttpClient())
            {
                try
                {
                    var request = new StringContent(messageBody);
                    request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var credentials = Encoding.ASCII.GetBytes("test:test");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                    response = await httpClient.PostAsync(new Uri(apiUrl), request);

                }
                catch (Exception ex)
                {
                }
            }
        }


        public async void getAllComplaints()
        {
            try
            {
               // List<Complaint> complaintList = new List<Complaint>();

                HttpClient client = new HttpClient();

                var byteArray = Encoding.ASCII.GetBytes("test:test");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                HttpContent content = response.Content;

                // ... Check Status Code                                
                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                //Complaint m = JsonConvert.DeserializeObject<Complaint>(result);

                //complaintList.Add(m);

                Console.WriteLine("We hebben het volgende ontvangen:" + result);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }
    }
}
