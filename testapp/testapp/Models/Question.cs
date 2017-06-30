using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

namespace testapp.Models
{
    class Question
    {
        public String questiontext { get; set; }

        public String questionnumber { get; set; }

        public List<Possibleanswer> possibleanswers { get; set; }

        public Question(dynamic json)
        {
            questionnumber = json.questionnumber;
            questiontext = json.questiontext;

            possibleanswers = new List<Possibleanswer>();

            foreach (dynamic p in json.possibleanswers)
            {
                int answerID = p.answerID;
                String answertext = p.answertext;

                Possibleanswer possibleanswer = new Possibleanswer(answerID, answertext);
                possibleanswers.Add(possibleanswer);
            }
        }
    }
}
