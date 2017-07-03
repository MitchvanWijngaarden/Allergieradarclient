using System;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using Color = Xamarin.Forms.Color;
using TextAlignment = Xamarin.Forms.TextAlignment;

namespace testapp.Views.Components
{

    public class ActionButton : NControlView
    {
        private readonly Label _label;
        private readonly NControlView _circles;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NControlDemo.Forms.Xamarin.Plugins.FormsApp.Controls.CircularButtonControl"/> class.
        /// </summary>
        public ActionButton()
        {
            HeightRequest = 66;
            WidthRequest = 66;

            _label = new Label
            {
                Text = "+",
                TextColor = Xamarin.Forms.Color.White,
                FontSize = 30,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
            };

            _circles = new NControlView
            {

                DrawingFunction = (canvas1, rect) => {
                    var fillColor = new NGraphics.Color(FillColor.R,
                        FillColor.G, FillColor.B, FillColor.A);

                    /*canvas1.FillEllipse(rect, fillColor);
                    rect.Inflate(new NGraphics.Size(-2, -2));
                    canvas1.FillEllipse(rect, Colors.White);*/
                    rect.Inflate(new NGraphics.Size(-4, -4));
                    canvas1.FillEllipse(rect, fillColor);
                }
            };

            Content = new Grid
            {
                Children = {
                    _circles,
                    _label,
                }
            };
        }

        /// <summary>
        /// The Command property.
        /// </summary>
        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ActionButton), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    var ctrl = (ActionButton)bindable;
                    ctrl.Command = (ICommand)newValue;
                });

        /// <summary>
        /// Gets or sets the Command of the CircularButtonControl instance.
        /// </summary>
        /// <value>The color of the buton.</value>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// The CommandParameter property.
        /// </summary>
        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ActionButton), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    var ctrl = (ActionButton)bindable;
                    ctrl.CommandParameter = newValue;
                });

        /// <summary>
        /// Gets or sets the CommandParameter of the CircularButtonControl instance.
        /// </summary>
        /// <value>The color of the buton.</value>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// The FillColor property.
        /// </summary>
        public static BindableProperty FillColorProperty =
            BindableProperty.Create(nameof(FillColor), typeof(Xamarin.Forms.Color), typeof(ActionButton),
                Xamarin.Forms.Color.Gray, BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ActionButton)bindable;
                    ctrl.FillColor = (Xamarin.Forms.Color)newValue;
                });

        /// <summary>
        /// Gets or sets the FillColor of the CircularButtonControl instance.
        /// </summary>
        /// <value>The color of the buton.</value>
        public Xamarin.Forms.Color FillColor
        {
            get { return (Xamarin.Forms.Color)GetValue(FillColorProperty); }
            set
            {
                SetValue(FillColorProperty, value);
                _circles.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the FA icon.
        /// </summary>
        /// <value>The FA icon.</value>
        public string FAIcon
        {
            get
            {
                return _label.Text;
            }
            set
            {
                _label.Text = value;
            }
        }

        public override bool TouchesBegan(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesBegan(points);
            this.ScaleTo(0.8, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesCancelled(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesCancelled(points);
            this.ScaleTo(1.0, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesEnded(System.Collections.Generic.IEnumerable<NGraphics.Point> points)
        {
            base.TouchesEnded(points);
            this.ScaleTo(1.0, 65, Easing.CubicInOut);
            if (Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);

            return true;
        }
    }
}
