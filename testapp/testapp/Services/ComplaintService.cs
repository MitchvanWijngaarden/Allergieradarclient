using testapp.Helpers;
using testapp.Models;

namespace testapp.Services
{
    class ComplaintService
    {
        private static ComplaintService instance;

        private static string apiUrl = SettingsSingleton.getApiUrl() + "complaints";

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

        public void SubmitComplaint(Complaint complaint)
        {
            RequestHelper requestHelper = new RequestHelper();
            requestHelper.PostDataAsync(complaint, apiUrl);
        }


        /*public async void getAllComplaints()
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
            }*/
            

    }
}
