using System;
using testapp.Helpers;
using testapp.Models;

namespace testapp.Services
{
    class ComplaintService
    {
        private static ComplaintService instance;
        private static string apiUrl = "complaints";
        private RequestHelper requestHelper;


        /// <summary>
        /// Constructor creates a requesthelper for complaints.
        /// </summary>
        private ComplaintService() {
            requestHelper = new RequestHelper();
        }

        /// <summary>
        /// Gets the singleton service.
        /// </summary>
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

        /// <summary>
        /// Sends a complaint to the request helper.
        /// </summary>
        /// <param name="complaint"></param>
        public void SubmitComplaint(Complaint complaint)
        {
            requestHelper.PostDataAsync(complaint, apiUrl);
        }

        /// <summary>
        /// Gets all the complaints from the requesthelper, returns JSON as string.
        /// </summary>
        /// <returns></returns>
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
