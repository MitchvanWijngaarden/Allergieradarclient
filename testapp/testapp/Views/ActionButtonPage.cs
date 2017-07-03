using System;

using Xamarin.Forms;

namespace testapp.Views
{
	public class ActionButtonPage: ContentPage
	{
		private Command _command;

		public ActionButtonPage ()
		{
			Title = "ActionButton";
			BackgroundColor = Color.White;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			var layout = new RelativeLayout ();
			Content = layout;

			var ab = new NControl.Controls.ActionButton
            {
				ButtonColor = Color.FromHex("#E91E63"),
				ButtonIcon = NControl.Controls.FontAwesomeLabel.FAThumbsUp,
			};
			layout.Children.Add(ab, () => new Rectangle((layout.Width/4)-(56/2), (layout.Height/2)-(56/2), 56, 56));


		}

		/// <summary>
		/// The IsToggled property.
		/// </summary>
		public static BindableProperty IsToggledProperty = 
			BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(ActionButtonPage), false,
				propertyChanged: (bindable, oldValue, newValue) => {
					var ctrl = (ActionButtonPage)bindable;
					ctrl.IsToggled = (bool)newValue;
				});

		/// <summary>
		/// Gets or sets the IsToggled of the ActionButtonPage instance.
		/// </summary>
		/// <value>The color of the buton.</value>
		public bool IsToggled {
			get{ return (bool)GetValue (IsToggledProperty); }
			set {
				SetValue (IsToggledProperty, value);
				_command.ChangeCanExecute ();
			}
		}

	}
}

