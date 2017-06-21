using System;

using Xamarin.Forms;

namespace testapp.Views.AboutPages
{
    public class Hooikoorts_en_Pollen : ContentView
    {
        public Hooikoorts_en_Pollen()
        {
            Content = new Label { Text = "Hello Hooikoorts" };
        }

        public static implicit operator ContentPage(Hooikoorts_en_Pollen v)
        {
            throw new NotImplementedException();
        }
    }
}

