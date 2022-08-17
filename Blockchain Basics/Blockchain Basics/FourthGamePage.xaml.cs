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

            bool begin = false;
            string[] qestions = new string[]
            {
                "f0afe84aa097f6fce31c0b76695ddb1fb980c7522f22482c0ac8e59f8a7e8065",
                "6959097001d10501ac7d54c0bdb8db61420f658f2922cc26e46d536119a31126",
                "b8d36eb35f075bd63a3bca0af6856dface40558edd3bd094302ed6869ea8a3fc",
                "0000000000c4b841dc6c5acdc68a9c2c3ee3f1f4014bafe82105067da0df7b68",
                "96488c5ba5e7871e65d467e40ffc8281c27964443da87581828e643edee8329e",
                "e4833e198a5a65d9c92f20ea56ad53c2a50cb316c8c47d4bfbe6652fe878c1e1",
            };

            main.IsEnabled = false;
            startorstop.BackgroundColor = Color.FromHex("");
            startorstop.Text = "Старт";
            startorstop.Clicked += startfunction;

            void startfunction(object sender, EventArgs e)
            {
                if (!begin)
                {
                    int count = 0, poscnt = 0;
                    main.IsEnabled = true;
                    pos.Text = "Процесс запущен ( Текущая сумма: 0 )";
                    pos.TextColor = Color.Green;
                    startorstop.BackgroundColor = Color.Red;
                    startorstop.Text = "Стоп";

                    begin = true;
                    Random rand = new Random();

                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            int randIndex = rand.Next(0, 5);
                            hashlabel.Text = qestions[randIndex];

                            main.Clicked += countclick;

                            if(randIndex == 3)
                            {
                                poscnt = 10;
                            }
                            else
                            {
                                poscnt = -5;
                            }

                            void countclick(object s, EventArgs end)
                            {
                                count += poscnt;

                                pos.Text = "Процесс запущен ( Текущая сумма: " + count.ToString() + " )";
                            }
                        });
                        return begin ? true : false; // runs again, or false to stop
                    });
                }

                else
                {
                    main.IsEnabled = false;

                    pos.Text = "Поцесс остановлен";
                    pos.TextColor = Color.Red;

                    startorstop.BackgroundColor = Color.FromHex("#2F9BDF");
                    startorstop.Text = "Старт";

                    begin = false;
                }
            }
        }
    }
}