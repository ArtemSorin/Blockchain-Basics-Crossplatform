using BlockchainBasics;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        UserRepository repos = new UserRepository();

        public MainPage(User user)
        {
            InitializeComponent();

            string ID = user.Id;

            MyUserName.Text = user.UserName;
            progressbar.Progress = user.UserProgress;
            label_courses.Text = $"{user.UserLessonsProgress}/6";
            label_games.Text = $"{user.UserGamesProgress}/4";
            profile.Source = user.UserProfile;
            progress.Text = $"Текущий прогресс: {user.UserProgress * 100}%";

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
                if (user.UserSelectedLessons[i] == '1')
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
                ID = user.Id;

                MyUserName.Text = user.UserName;
                progressbar.Progress = user.UserProgress;
                label_courses.Text = $"{user.UserLessonsProgress}/6";
                label_games.Text = $"{user.UserGamesProgress}/4";
                profile.Source = user.UserProfile;
                progress.Text = $"Текущий прогресс: {user.UserProgress * 100}%";
                refreshView.IsRefreshing = false;
            });

            refreshView.Command = refreshCommand;

            add1.Clicked += (s, e) => { animation_add(add1); btn_add_click(add1, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add2.Clicked += (s, e) => { animation_add(add2); btn_add_click(add2, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add3.Clicked += (s, e) => { animation_add(add3); btn_add_click(add3, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add4.Clicked += (s, e) => { animation_add(add4); btn_add_click(add4, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add5.Clicked += (s, e) => { animation_add(add5); btn_add_click(add5, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add6.Clicked += (s, e) => { animation_add(add6); btn_add_click(add6, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add7.Clicked += (s, e) => { animation_add(add7); btn_add_click(add7, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };
            add8.Clicked += (s, e) => { animation_add(add8); btn_add_click(add8, mas_btn_add, mas_frame, pos, user, ID, mas_bools); };

            button_game_1.Clicked += (sender, e) => { Navigation.PushAsync(new FirstGamePage(user)); };
            button_game_2.Clicked += (sender, e) => { Navigation.PushAsync(new SecondGamePage(user)); };
            button_game_3.Clicked += (sender, e) => { Navigation.PushAsync(new ThirdGamePage(user)); };
            button_game_4.Clicked += (sender, e) => { Navigation.PushAsync(new FourthGamePage()); };
            button_game_5.Clicked += (sender, e) => { Navigation.PushAsync(new FifthGamePage(user)); };

            outbtn.Clicked += (sender, e) => Navigation.PopAsync();
            refresh.Clicked += (sender, e) => Navigation.PushAsync(new AccountPage(user));
        }
        private async void animation_add(Button btn)
        {
            await btn.ScaleTo(1.2, 170, easing: Easing.Linear);
            await btn.ScaleTo(1, 170, easing: Easing.Linear);
        }
        private async void btn_add_click(Button add, Button[] mas_btn, Frame[] mas_frame, int pos, User user, string ID, bool[] stacpos)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!stacpos[i] && add == mas_btn[i])
                {
                    emptylabel.IsVisible = false;
                    mas_frame[i].IsVisible = true;
                    stacbtn.Children.Add(mas_frame[i], pos, 0);

                    char[] charStr = user.UserSelectedLessons.ToCharArray();
                    charStr[i] = '1';
                    string drb = new string(charStr);

                    user.UserSelectedLessons = drb;

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

                    char[] charStr = user.UserSelectedLessons.ToCharArray();
                    charStr[i] = '0';
                    string drb = new string(charStr);

                    user.UserSelectedLessons = drb;

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
                if (user.UserSelectedLessons[i] == '1')
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

            user.Id = ID;
            await repos.Update(user);
        }
    }
}
