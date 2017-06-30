using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.Models
{
    class Possibleanswer
    {
        public int answerID { get; set; }

        public String answertext { get; set; }

        public Possibleanswer(int answerID, String answertext)
        {
            this.answerID = answerID;
            this.answertext = answertext;
        }
    }
}
