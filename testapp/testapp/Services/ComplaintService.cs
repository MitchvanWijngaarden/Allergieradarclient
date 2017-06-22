using Java.Lang;
using System.Net.Http;
using testapp.Helpers;
using testapp.Models;

namespace testapp.Services
{
    class ComplaintService
    {
        private static ComplaintService instance;

        private static string apiUrl = "complaints";

        private RequestHelper requestHelper;

        private ComplaintService() {
            requestHelper = new RequestHelper();
        }

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
            requestHelper.PostDataAsync(complaint, apiUrl);
        }


        public string GetAllComplaints()
        {
            try
            {   
                return requestHelper.GetData(apiUrl);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
