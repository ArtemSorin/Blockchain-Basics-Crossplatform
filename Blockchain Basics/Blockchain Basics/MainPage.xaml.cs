using Android.Content.Res;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Blockchain_Basics
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(int ID)
        {
            InitializeComponent();

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            var data = App.Database.GetItem(ID);

            MyUserName.Text = data.UserName;
            progressbar.Progress = data.UserProgress;
            label_courses.Text = $"{data.UserLessonsProgress}/6";
            label_games.Text = $"{data.UserGamesProgress}/4";

            Frame[] mas_frame = new Frame[]
            {
                frame1, frame2, frame3, frame4, frame5, frame6, frame7, frame8
            };

            Button[] mas_btn_add = new Button[]
            {
                add1, add2, add3, add4, add5, add6, add7, add8
            };

            bool[] mas_bools = new bool[]
            {
                false, false, false, false, false, false, false, false
            };

            int pos = 0;

            for (int i = 0; i < 8; i++)
            {
                if (data.UserSelectedLessons[i] == '1')
                {
                    emptylabel.IsVisible = false;
                    mas_frame[i].IsVisible = true;
                    stacbtn.Children.Add(mas_frame[i], pos, 0);

                    mas_btn_add[i].BackgroundColor = Color.LightGray;
                    mas_btn_add[i].Text = "Добавлено";
                    mas_bools[i] = true;

                    pos++;
                }
            }

            if (pos == 0)
            {
                emptylabel.IsVisible = true;
            }

            ICommand refreshCommand = new Command(() =>
            {
                MyUserName.Text = data.UserName;
                progressbar.Progress = data.UserProgress;
                label_courses.Text = $"{data.UserLessonsProgress}/6";
                label_games.Text = $"{data.UserGamesProgress}/4";
                refreshView.IsRefreshing = false;
            });

            refreshView.Command = refreshCommand;

            add1.Clicked += (s, e) => btn_add_click(add1, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add2.Clicked += (s, e) => btn_add_click(add2, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add3.Clicked += (s, e) => btn_add_click(add3, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add4.Clicked += (s, e) => btn_add_click(add4, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add5.Clicked += (s, e) => btn_add_click(add5, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add6.Clicked += (s, e) => btn_add_click(add6, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add7.Clicked += (s, e) => btn_add_click(add7, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);
            add8.Clicked += (s, e) => btn_add_click(add8, mas_btn_add, mas_frame, ref pos, ID, ref mas_bools);

            button_game_1.Clicked += (sender, e) => Navigation.PushAsync(new FirstGamePage(ID));
            button_game_2.Clicked += (sender, e) => Navigation.PushAsync(new SecondGamePage(ID));
            button_game_3.Clicked += (sender, e) => Navigation.PushAsync(new ThirdGamePage(ID));
            button_game_4.Clicked += (sender, e) => Navigation.PushAsync(new FourthGamePage());

            outbtn.Clicked += (sender, e) => Navigation.PopAsync();
        }
        private void btn_add_click(Button add, Button[] mas_btn, Frame[] mas_frame, ref int pos, int ID, ref bool[] stacpos)
        {
            var data = App.Database.GetItem(ID);

            for (int i = 0; i < 8; i++)
            {
                if (!stacpos[i] && add == mas_btn[i])
                {
                    emptylabel.IsVisible = false;
                    mas_frame[i].IsVisible = true;
                    stacbtn.Children.Add(mas_frame[i], pos, 0);

                    char[] charStr = data.UserSelectedLessons.ToCharArray();
                    charStr[i] = '1';
                    string drb = new string(charStr);

                    data.UserSelectedLessons = drb;

                    add.BackgroundColor = Color.LightGray;
                    add.Text = "Добавлено";
                    pos++;

                    stacpos[i] = true;

                    break;
                }
                else if (stacpos[i] && add == mas_btn[i])
                {
                    mas_frame[i].IsVisible = false;
                    stacbtn.Children.Remove(mas_frame[i]);

                    for (int j = i; j < 7; j++)
                    {
                        if (mas_frame[j + 1].IsVisible == true)
                        {
                            stacbtn.Children.Add(mas_frame[j + 1], j, 0);
                        }
                    }

                    char[] charStr = data.UserSelectedLessons.ToCharArray();
                    charStr[i] = '0';
                    string drb = new string(charStr);

                    data.UserSelectedLessons = drb;

                    add.BackgroundColor = Color.FromHex("#2F9BDF");
                    add.Text = "Добавить";

                    pos--;
                    stacpos[i] = false;

                    break;
                }
            }
            int posselect = 0;
            for (int i = 0; i < 8; i++)
            {
                if (data.UserSelectedLessons[i] == '1')
                {
                    emptylabel.IsVisible = false;
                    mas_frame[i].IsVisible = true;
                    stacbtn.Children.Add(mas_frame[i], posselect, 0);

                    mas_btn[i].BackgroundColor = Color.LightGray;
                    mas_btn[i].Text = "Добавлено";
                    stacpos[i] = true;

                    posselect++;
                }
            }

            App.Database.SaveItem(data);
        }
    }
}
