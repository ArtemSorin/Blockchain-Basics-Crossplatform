using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourthGamePage : ContentPage
    {
        public FourthGamePage()
        {
            InitializeComponent();

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            RadialGradientBrush radialGradientBrushSelected = new RadialGradientBrush();
            radialGradientBrushSelected.Radius = 1.5;
            radialGradientBrushSelected.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#FB0309"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#E10E53"), Offset = 1 }
            };

            bool begin = false;
            string[] qestions = new string[]
            {
                "dgj",
                "fsd",
                "fff",
                "nnp",
                "spp",
                "poo",
            };

            main.IsEnabled = false;
            startorstop.Background = radialGradientBrush;
            startorstop.Text = "Старт";
            startorstop.Clicked += startfunction;

            void startfunction(object sender, EventArgs e)
            {
                if (!begin)
                {
                    main.IsEnabled = true;
                    pos.Text = "Процесс запущен ( Текущая сумма: 0 )";
                    pos.TextColor = Color.Green;
                    startorstop.Background = radialGradientBrushSelected;
                    startorstop.Text = "Стоп";

                    begin = true;
                    Random rand = new Random();

                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            int randIndex = rand.Next(0, 5);
                            hashlabel.Text = qestions[randIndex];
                        });
                        return begin ? true : false; // runs again, or false to stop
                    });
                }

                else
                {
                    main.IsEnabled = false;

                    pos.Text = "Поцесс остановлен";
                    pos.TextColor = Color.Red;

                    startorstop.Background = radialGradientBrush;
                    startorstop.Text = "Старт";

                    begin = false;
                }
            }
        }
    }
}