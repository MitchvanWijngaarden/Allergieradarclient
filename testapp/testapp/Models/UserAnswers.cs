using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace testapp.Models
{
    class UserAnswers
    {
        private static UserAnswers instance;

        public List<UserAnswer> useranswers { get; set; }

        public UserAnswers()
        {
            useranswers = new List<UserAnswer>();
        }

        public static UserAnswers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserAnswers();
                }
                return instance;
            }
        }

        public void AddUserAnswer(String questionnumber, int answerID)
        {
            UserAnswer useranswer = new UserAnswer(questionnumber, answerID);
            useranswers.Add(useranswer);
        }

        public void DeleteUserAnswer(int answerID)
        {
            useranswers.RemoveAll(x => x.answerID == answerID);
        }

        public List<UserAnswer> GetUserAnswersByQuestionnumber(String questionnumber)
        {
            List<UserAnswer> returnlist = new List<UserAnswer>();
            foreach(UserAnswer u in useranswers)
            {
                if (u.questionnumber == questionnumber)
                {
                    returnlist.Add(u);
                }
            }

            return (returnlist);
        }

    }
}
