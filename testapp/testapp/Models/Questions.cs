using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using testapp.Services;

namespace testapp.Models
{
    class Questions
    {
        private static Questions instance;

        public List<Question> questions { get; set; }

        public static Questions Instance
        {
            get
            {
                if (instance == null)
                {
                    String json = SignUpService.Instance.getQuestions();
                    instance = new Questions(json);
                }
                return instance;
            }
        }

        public Questions(String json)
        {
            questions = new List<Question>();

            Debug.WriteLine("json = " + json);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);

            Debug.WriteLine("results = " + results);

            foreach (dynamic q in results)
            {
                Question question = new Question(q);
                questions.Add(question);
            }

        }

        public Question getQuestion(String questionnumber)
        {
            Question question = null;

            foreach (Question q in questions)
            {
                if (q.questionnumber == questionnumber)
                {
                    question = q;
                }
            }

            return (question);
        }
    }
}
