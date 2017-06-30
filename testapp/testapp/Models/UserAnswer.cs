using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class UserAnswer
    {
        public String questionnumber { get; set; }
        public int userID { get; set; }
        public int answerID { get; set; }

        public UserAnswer(String questionnumber, int answerID)
        {
            this.questionnumber = questionnumber;
            this.answerID = answerID;
        }
    }
}
