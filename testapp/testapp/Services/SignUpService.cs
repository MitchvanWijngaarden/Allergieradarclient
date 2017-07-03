using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using testapp.Helpers;
using testapp.Models;

namespace testapp.Services
{
    class SignUpService
    {
        private static SignUpService instance;

        private static String apiUrl = "users";

        private RequestHelper requestHelper;

        private SignUpService()
        {
            requestHelper = new RequestHelper();
        }

        public static SignUpService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SignUpService();
                }
                return instance;
            }
        }

        public async Task SubmitUser(User user)
        {
            requestHelper.PostDataAsync(user, apiUrl);
            Debug.WriteLine("user verstuurd");
        }

        public void SubmitUserAnswer(UserAnswer useranswer, int userID)
        {
            useranswer.userID = userID;

            Debug.Write("questionnumber = " + useranswer.questionnumber);
            Debug.Write("userID = " + useranswer.userID);
            Debug.Write("answerID = " + useranswer.answerID);

            String apiUrlUserAnswer = apiUrl + "/useranswer";
            requestHelper.PostDataAsync(useranswer, apiUrlUserAnswer);
        }

        public void SubmitUserMedicine(UserMedicine usermedicine, int userID)
        {
            usermedicine.userID = userID;

            Debug.Write("medicineID = " + usermedicine.medicineID);
            Debug.Write("userID = " + usermedicine.userID);

            String apiUrlUserMedicine = apiUrl + "/usermedicine";
            requestHelper.PostDataAsync(usermedicine, apiUrlUserMedicine);
        }

        public async Task<int> GetUserIdByUsername()
        {
            await Task.Delay(1000);
            String username = User.Instance.username;
            String apiUrlUsername = apiUrl + "/userid/" + username;
            String result = requestHelper.GetData(apiUrlUsername);
            Debug.Write("result getidbyname = " + result);
            int userID = 0;
            if (!int.TryParse(result, out userID)) {
                Debug.WriteLine("TryParse mislukt");
            }
            
            return userID; 
        }

        public String getQuestions()
        {
            requestHelper = new RequestHelper();
            String apiUrlQuestion = apiUrl + "/questions";
            return (requestHelper.GetData(apiUrlQuestion));
        }

        public String getMedicines()
        {
            requestHelper = new RequestHelper();
            String apiUrlMedicine = apiUrl + "/medicines";
            return (requestHelper.GetData(apiUrlMedicine));
        }
    }
}
