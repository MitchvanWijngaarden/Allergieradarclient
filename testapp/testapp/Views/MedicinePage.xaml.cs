using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapp.Controllers;
using testapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MedicinePage : ContentPage
	{
        private VragenlijstController controller;

        private StackLayout layout;

        private ScrollView scrollview;

        public MedicinePage ()
		{
            controller = new VragenlijstController();

            layout = new StackLayout();

            scrollview = new ScrollView();

            FillLayout();
		}

        private void FillLayout()
        {
            Debug.WriteLine("FillLayout aangeroepen");

            AddMedicinesToLayout("Tablet/drank");
            AddMedicinesToLayout("Neussprays/druppels");
            AddMedicinesToLayout("Oogdruppels");
            AddMedicinesToLayout("Medicijnen voor astma");
            AddMedicinesToLayout("Combinatie inhalatiemedicatie bij astma");
            AddMedicinesToLayout("Antihistaminica, geschikt voor kinderen");
            AddMedicinesToLayout("Leukotriënenantagonisten");
            AddMedicinesToLayout("Immunotherapie extracten, geregistreerd in Nederland");

            Button nextButton = new Button();
            nextButton.Text = "Volgende vraag";
            nextButton.BackgroundColor = Color.DeepSkyBlue;
            nextButton.Clicked += Button_Next;

            layout.Children.Add(nextButton);

            layout.Padding = 50;
            layout.Spacing = 20;

            scrollview.Content = layout;

            Content = scrollview;
        }

        private void AddMedicinesToLayout(String medicinetype)
        {
            Label medicineTypeLabel = new Label();
            medicineTypeLabel.Text = medicinetype;
            layout.Children.Add(medicineTypeLabel);

            foreach (Medicine m in Medicines.Instance.GetMedicinesByMedicinetype(medicineTypeLabel.Text))
            {
                AddButtonToLayout(m.medicineID, m.medicinename);
            }
        }

        private void AddButtonToLayout(int medicineID, string medicinetype)
        {
            Button button = new Button();
            button.Margin = new Thickness(-10);
            button.ClassId = medicineID.ToString();
            button.Text = medicinetype;
            button.Clicked += ButtonAnswer;
            layout.Children.Add(button);
        }

        private void ButtonAnswer(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int medicineID = Int32.Parse(btn.ClassId);

            if (btn.BackgroundColor == Color.LimeGreen)
            {
                controller.DeleteUserMedicine(medicineID);
                btn.BackgroundColor = Color.Default;
            }
            else
            {
                controller.AddUserMedicine(medicineID);
                btn.BackgroundColor = Color.LimeGreen;
            }
        }

        private void Button_Next(object sender, EventArgs e)
        {
            if (controller.AreMedicinesValid())
            {
                Navigation.PopModalAsync();
                Navigation.PushModalAsync(new RemainingQuestions());
            }
            else
            {
                DisplayAlert("Antwoord klopt niet!", "Vraag is verkeerd/niet beantwoordt", "Ok");
            }
        }
    }
}