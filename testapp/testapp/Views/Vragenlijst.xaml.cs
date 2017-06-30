using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using testapp.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using testapp.Models;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vragenlijst : ContentPage
	{
        private VragenlijstController controller;

        private ScrollView scrollview;

        private StackLayout layout;

        private Question question;

		public Vragenlijst (String questionnumber)
		{
            //InitializeComponent();

            scrollview = new ScrollView();

            layout = new StackLayout();

            this.controller = new VragenlijstController();

            FillLayoutByQuestion(questionnumber);
		}

        private void FillLayoutByQuestion(String questionnumber)
        {
            question = controller.GetQuestion(questionnumber);

            Label questionnumberLabel = new Label();
            questionnumberLabel.Text = "Vraag " + question.questionnumber;

            Label questiontextLabel = new Label();
            questiontextLabel.Text = question.questiontext;

            layout.Children.Add(questionnumberLabel);
            layout.Children.Add(questiontextLabel);
            
            foreach (Possibleanswer p in question.possibleanswers)
            {
                AddButtonToLayout(p.answerID, p.answertext);
            }

            AddDefaultButtonsToLayout();

            layout.Padding = 50;
            layout.Spacing = 20;

            scrollview.Content = layout;

            Content = scrollview;
        }

        private void AddButtonToLayout(int answerID, string answertext)
        {
            Button button = new Button();
            button.ClassId = answerID.ToString();
            button.Text = answertext;
            button.Clicked += ButtonAnswer;
            layout.Children.Add(button);
        }

        private void AddDefaultButtonsToLayout()
        {
            StackLayout layout2 = new StackLayout();
            layout2.Orientation = StackOrientation.Horizontal;
            layout2.HorizontalOptions = LayoutOptions.FillAndExpand;

            Button nextButton = new Button();
            nextButton.Text = "Volgende vraag";
            nextButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            nextButton.Clicked += Button_Next;

            layout2.Children.Add(nextButton);

            layout.Children.Add(layout2);
        }

        private void Button_Next(object sender, EventArgs e)
        {
            if (controller.AreAnswersValid(question.questionnumber))
            {
                String questionnumber = controller.GetNextQuestionnumber(question.questionnumber);

                Navigation.PopModalAsync();

                if (questionnumber == "6b")
                {
                    UserMedicines.Instance.usermedicines.Clear();
                    Navigation.PushModalAsync(new MedicinePage());
                }
                else if (questionnumber == "7")
                {
                    Navigation.PushModalAsync(new RemainingQuestions());
                }
                else if (questionnumber == "no")
                {
                    Navigation.PopModalAsync();
                    DisplayAlert("Geen profiel nodig!", "Volgens uw antwoorden heeft u geen allergie en daarom hoeft u geen profiel aan te maken", "Ok");
                }
                else
                {
                    Navigation.PushModalAsync(new Vragenlijst(questionnumber));
                }
            }
            else
            {
                DisplayAlert("Antwoord klopt niet!", "Vraag is verkeerd/niet beantwoordt", "Ok");
            }
        }

        private void ButtonAnswer(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            String questionnumber = question.questionnumber;
            int answerID = Int32.Parse(btn.ClassId);

            if (btn.BackgroundColor == Color.Red)
            {
                controller.DeleteUserAnswer(answerID);
                btn.BackgroundColor = Color.Default;
            }
            else
            {
                controller.AddUserAnswer(questionnumber, answerID);
                btn.BackgroundColor = Color.Red;
            }
        }
    }
}