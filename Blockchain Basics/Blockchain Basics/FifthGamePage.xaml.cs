using BlockchainBasics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Blockchain_Basics.ThirdGamePage;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FifthGamePage : ContentPage
    {
        double value = 0.0f;
        double reskoef = 0.0f;
        int res = 0;

        UserRepository repos = new UserRepository();

        public SQLiteConnection conn;
        public User regmodel;

        public struct BTN
        {
            public Button btn;
            public bool flag;
        }
        public FifthGamePage(User user)
        {
            InitializeComponent();

            balance.Text = $"{user.UserPrimogames} AT";

            List<BTN> mas = new List<BTN>();

            mas.Add(new BTN() { btn = btn1, flag = false });
            mas.Add(new BTN() { btn = btn2, flag = false });
            mas.Add(new BTN() { btn = btn3, flag = false });
            mas.Add(new BTN() { btn = btn4, flag = false });
            mas.Add(new BTN() { btn = btn5, flag = false });
            mas.Add(new BTN() { btn = btn6, flag = false });
            mas.Add(new BTN() { btn = btn7, flag = false });
            mas.Add(new BTN() { btn = btn8, flag = false });

            mas[0].btn.Clicked += (sender, e) => onClick(0, mas, user);
            mas[1].btn.Clicked += (sender, e) => onClick(1, mas, user);
            mas[2].btn.Clicked += (sender, e) => onClick(2, mas, user);
            mas[3].btn.Clicked += (sender, e) => onClick(3, mas, user);
            mas[4].btn.Clicked += (sender, e) => onClick(4, mas, user);
            mas[5].btn.Clicked += (sender, e) => onClick(5, mas, user);
            mas[6].btn.Clicked += (sender, e) => onClick(6, mas, user);
            mas[7].btn.Clicked += (sender, e) => onClick(7, mas, user);

            start_btn.Clicked += (sender, e) => onClickStart(reskoef, user);
        }
        public async void onClickStart(double reskoef, User user)
        {
            Random rnd = new Random();

            int random = 0;
            int result_of_rand = 0;

            if (value >= 0 && value < 10)
            {
                random = 100;
                result_of_rand = rnd.Next(0, random);

                if(result_of_rand <= 10)
                {
                    if (!user.Games_completed[4])
                    {
                        user.Games_completed[4] = true;

                        user.UserProgress += 0.08;
                        user.UserGamesProgress++;
                        user.UserPrimogames += 100;

                        await repos.Update(user);
                    }

                    if (!user.Games_achivement[2])
                    {
                        user.Games_achivement[2] = true;

                        user.UserAchievements[2] = 1;

                        await repos.Update(user);
                    }

                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 10 && value < 20)
            {
                random = 90;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 20)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 20 && value < 30)
            {
                random = 80;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 30)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 30 && value < 40)
            {
                random = 70;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 30)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 40 && value < 50)
            {
                random = 60;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 30)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 50 && value < 60)
            {
                random = 50;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 20)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    user.UserPrimogames -= (int)(res);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 60 && value < 70)
            {
                random = 40;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 20)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }
            else if (value >= 70 && value <= 80)
            {
                random = 30;
                result_of_rand = rnd.Next(0, random);

                if (result_of_rand <= 20)
                {
                    user.UserPrimogames += (int)(res * reskoef);
                    await repos.Update(user);
                    await DisplayAlert("Уведомление", $"Успех!\n+{res * reskoef} AT", "ок");
                }
                else
                {
                    await DisplayAlert("Уведомление", "Неудача!", "ок");
                }
            }

            balance.Text = $"{user.UserPrimogames} AT";
        }
        public async void onClick(int index, List<BTN> mas, User user)
        {
            for (int i = 0; i < 8; i++)
            {
                if (mas[i].flag)
                {
                    mas[i].btn.BackgroundColor = Color.FromHex("#2F9BDF");
                    BTN bt = mas[i];
                    bt.flag = false;
                    mas[i] = bt;
                }
            }

            mas[index].btn.BackgroundColor = Color.FromHex("#60af21");
            BTN bt1 = mas[index];
            bt1.flag = true;
            mas[index] = bt1;

            switch(index)
            {
                case 0:
                    {
                        res = 5;
                        break;
                    }
                case 1:
                    {
                        res = 10;
                        break;
                    }
                case 2:
                    {
                        res = 25;
                        break;
                    }
                case 3:
                    {
                        res = 50;
                        break;
                    }
                case 4:
                    {
                        res = 100;
                        break;
                    }
                case 5:
                    {
                        res = 150;
                        break;
                    }
                case 6:
                    {
                        res = 300;
                        break;
                    }
                case 7:
                    {
                        res = 500;
                        break;
                    }
            }

            prise.Text = $"{res * reskoef}";
        }
        public void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            selected.Text = String.Format("Выбрано: {0:#,0}", e.NewValue);

            value = e.NewValue;

            reskoef = Math.Round(1 + (0.4 * (1 - value / 30)), 2);

            koeff.Text = $"{reskoef}";

            prise.Text = $"{res * reskoef}";
        }
    }
}