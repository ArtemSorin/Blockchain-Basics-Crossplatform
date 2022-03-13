using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blockchain_Basics
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            button1.Clicked += (s, e) => Navigation.PushAsync(new PersonPage());
            button2.Clicked += (s, e) => Navigation.PushAsync(new LessonsPage());
            button3.Clicked += (s, e) => Navigation.PushAsync(new GamesPage());
        }
    }
}
