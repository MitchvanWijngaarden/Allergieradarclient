using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using testapp.Models;

namespace testapp.Services
{
    class ComplaintService
    {
        private static ComplaintService instance;

        private static string apiUrl = "http://145.101.90.211:8080/api/complaints";

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

        public async void SubmitComplaint(Complaint complaint)
        {
            HttpResponseMessage response;
            String messageBody = JsonConvert.SerializeObject(complaint);


            using (var httpClient = new HttpClient())
            {
                var request = new StringContent(messageBody);
                request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var credentials = Encoding.ASCII.GetBytes("test:test");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                response = await httpClient.PostAsync(new Uri(apiUrl), request);
            }
        }

        public List<Complaint> GetAllComplaints()
        {
            List<Complaint> complaintList = new List<Complaint>();

            using (var httpClient = new HttpClient())
            {
                var credentials = Encoding.ASCII.GetBytes("test:test");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                //response = await httpClient.PostAsync(new Uri(apiUrl), request);
            }

            return complaintList;


        }
    }
}
