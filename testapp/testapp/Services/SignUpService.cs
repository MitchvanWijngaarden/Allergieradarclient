using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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

        public void SubmitUser(User user)
        {
            requestHelper.PostDataAsync(user, apiUrl);
        }

        public void SubmitUserAnswer(UserAnswer useranswer)
        {
            Debug.Write("questionnumber = " + useranswer.questionnumber);
            Debug.Write("userID = " + useranswer.userID);
            Debug.Write("answerID = " + useranswer.answerID);

            useranswer.userID = GetUserIdByUsername();

            Debug.Write("userID = " + useranswer.userID);

            String apiUrlUserAnswer = apiUrl + "/useranswer";
            requestHelper.PostDataAsync(useranswer, apiUrlUserAnswer);
        }

        public void SubmitUserMedicine(UserMedicine usermedicine)
        {
            Debug.Write("medicineID = " + usermedicine.medicineID);
            Debug.Write("userID = " + usermedicine.userID);

            usermedicine.userID = GetUserIdByUsername();

            Debug.Write("userID = " + usermedicine.userID);

            String apiUrlUserMedicine = apiUrl + "/usermedicine";
            requestHelper.PostDataAsync(usermedicine, apiUrlUserMedicine);
        }

        public int GetUserIdByUsername()
        {
            requestHelper = new RequestHelper();
            String username = User.Instance.username;
            String apiUrlUsername = apiUrl + "/userid/" + username;
            int userID;
            if (!int.TryParse(requestHelper.GetData(apiUrlUsername), out userID)) {
                Debug.WriteLine("TryParse mislukt");
                userID = 0;
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
