using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using testapp.Models;
using testapp.Services;
using testapp.Views;


namespace testapp.Controllers
{
    class QuestionController
    {
        public QuestionController()
        {

        }

        public Question GetQuestion(String questionnumber)
        {
            return (Questions.Instance.getQuestion(questionnumber));
        }

        public Boolean AreAnswersValid(String questionnumber)
        {
            List<UserAnswer> useranswers = UserAnswers.Instance.GetUserAnswersByQuestionnumber(questionnumber);

            int count = useranswers.Count;

            if(count > 0)
            {
                String q = questionnumber;

                if (q == "1" || q == "1d" || q == "2" || q == "2d" || q == "3" || q == "3d" || q == "4" ||
                    q == "4b" || q == "4c" || q == "5" || q == "6")
                {
                    if (count == 1)
                    {
                        return true;
                    }
                }
                else
                {
                    if (count >= 1)
                    {
                        return true;
                    }
                }
            }
            else
            {
                
            }
            return false;
        }

        public String GetNextQuestionnumber(String questionnumber)
        {
            String returnvalue = "";

            switch (questionnumber)
            {
                case "1":
                    returnvalue = (NextQuestionnumber(questionnumber, "Ja")) ? "1b" : "2";
                    break;
                case "1b":
                    returnvalue = "1c";
                    break;
                case "1c":
                    returnvalue = (NextQuestionnumber(questionnumber, "Dieren")) ? "1d" : "2";
                    break;
                case "1d":
                    returnvalue = "2";
                    break;
                case "2":
                    returnvalue = (NextQuestionnumber(questionnumber, "Ja")) ? "2b" : "3";
                    break;
                case "2b":
                    returnvalue = "2c";
                    break;
                case "2c":
                    returnvalue = (NextQuestionnumber(questionnumber, "Dieren")) ? "2d" : "3";
                    break;
                case "2d":
                    returnvalue = "3";
                    break;
                case "3":
                    if (NextQuestionnumber(questionnumber, "Ja"))
                    {
                        returnvalue = "3b";
                    }
                    else if (NextQuestionnumber("1", "Nee") && NextQuestionnumber("2", "Nee"))
                    {
                        returnvalue = "no";
                    }
                    else
                    {
                        returnvalue = "4";
                    }
                    break;
                case "3b":
                    returnvalue = "3c";
                    break;
                case "3c":
                    returnvalue = (NextQuestionnumber(questionnumber, "Dieren")) ? "3d" : "4";
                    break;
                case "3d":
                    returnvalue = "4";
                    break;
                case "4":
                    returnvalue = (NextQuestionnumber(questionnumber, "Ja")) ? "4b" : "4c";
                    break;
                case "4b":
                    returnvalue = "4c";
                    break;
                case "4c":
                    returnvalue = (NextQuestionnumber(questionnumber, "Ja")) ? "4d" : "4g";
                    break;
                case "4d":
                    returnvalue = (NextQuestionnumber(questionnumber, "Boompollen")) ? "4e" : (NextQuestionnumber(questionnumber, "Kruidpollen (bijv. bijvoet)")) ? "4f" : "5" ;
                    break;
                case "4e":
                    returnvalue = (NextQuestionnumber("4d", "Kruidpollen (bijv. bijvoet)")) ? "4f" : "5";
                    break;
                case "4f":
                    returnvalue = "5";
                    break;
                case "4g":
                    returnvalue = (NextQuestionnumber(questionnumber, "Boompollen")) ? "4h" : (NextQuestionnumber(questionnumber, "Kruidpollen (bijv. bijvoet)")) ? "4i" : "5";
                    break;
                case "4h":
                    returnvalue = (NextQuestionnumber("4g", "Kruidpollen (bijv. bijvoet)")) ? "4i" : "5";
                    break;
                case "4i":
                    returnvalue = "5";
                    break;
                case "5":
                    returnvalue = "6";
                    break;
                case "6":
                    returnvalue = (NextQuestionnumber(questionnumber, "Ja")) ? "6b" : "7";
                    break;
            }

            return returnvalue;
        }

        public bool NextQuestionnumber(String questionnumber, String answertext)
        {
            List<UserAnswer> useranswers = UserAnswers.Instance.GetUserAnswersByQuestionnumber(questionnumber);
            Question question = Questions.Instance.getQuestion(questionnumber);

            foreach (UserAnswer u in useranswers)
            {
                int answerID = u.answerID;

                foreach (Possibleanswer p in question.possibleanswers)
                {
                    if(p.answerID == answerID && p.answertext == answertext)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean AreMedicinesValid()
        {
            List<UserMedicine> usermedicines = UserMedicines.Instance.usermedicines;

            if (usermedicines.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void AddUserAnswer(String questionnumber, int answerID)
        {
            UserAnswers.Instance.AddUserAnswer(questionnumber, answerID);
        }

        public void DeleteUserAnswer(int answerID)
        {
            UserAnswers.Instance.DeleteUserAnswer(answerID);
        }

        public void AddUserMedicine(int medicineID)
        {
            UserMedicines.Instance.AddUserMedicine(medicineID);
        }

        public void DeleteUserMedicine(int medicineID)
        {
            UserMedicines.Instance.DeleteUserMedicine(medicineID);
        }

        public async Task SendData()
        {
            await SignUpService.Instance.SubmitUser(User.Instance);

            Task<int> t = SignUpService.Instance.GetUserIdByUsername();

            int userID = await t;

            Debug.WriteLine("userid in senddata = " + userID);

            foreach (UserAnswer ua in UserAnswers.Instance.useranswers)
            {
                SignUpService.Instance.SubmitUserAnswer(ua, userID);
            }
            foreach (UserMedicine um in UserMedicines.Instance.usermedicines)
            {
                SignUpService.Instance.SubmitUserMedicine(um, userID);
            }
        }
    }
}
