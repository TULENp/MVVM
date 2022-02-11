using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    class Page1VM : BindableObject
    {
        private Color frameColor;

        public Color FrameColor
        {
            get => frameColor;
            set
            {
                if (frameColor != value)
                {
                    frameColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ChangeColor => new Command(OnChangeColor);
        public ICommand Push => new Command(OnPush);
        private void OnPush()
        {
            App.Current.MainPage.Navigation.PushAsync(new Page3());
        }
        private void OnChangeColor()
        {
            FrameColor = Color.FromRgb(new Random().Next(255), new Random().Next(255), new Random().Next(255));
        }
    }
}
