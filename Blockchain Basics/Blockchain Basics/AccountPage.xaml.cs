using System;
using System.Collections.Generic;
using BlockchainBasics;
using Xamarin.Forms;
using static Blockchain_Basics.ThirdGamePage;
using static Xamarin.Forms.Internals.Profile;

namespace Blockchain_Basics
{
    public partial class AccountPage : ContentPage
    {
        UserRepository repos = new UserRepository();

        public struct AButton
        {
            public bool open;
            public ImageButton button;
        }
        public struct Achivement
        {
            public string state;
            public Button button;
            public Label label;
        }
        public List<AButton> Init(User user)
        {
            List<AButton> aButtons = new List<AButton>();

            aButtons.Add(new AButton() { button = im1, open = true });
            aButtons.Add(new AButton() { button = im2, open = user.UserProgress > 0.2 ? true : false });
            aButtons.Add(new AButton() { button = im3, open = user.UserProgress > 0.3 ? true : false });
            aButtons.Add(new AButton() { button = im4, open = user.UserProgress > 0.4 ? true : false });
            aButtons.Add(new AButton() { button = im5, open = user.UserProgress > 0.5 ? true : false });
            aButtons.Add(new AButton() { button = im6, open = user.UserProgress > 0.6 ? true : false });
            aButtons.Add(new AButton() { button = im7, open = user.UserProgress > 0.7 ? true : false });
            aButtons.Add(new AButton() { button = im8, open = user.UserProgress > 0.8 ? true : false });

            return aButtons;
        }
        public List<Achivement> initach(User user)
        {
            List<Achivement> achivement = new List<Achivement>();

            achivement.Add(new Achivement() { state = user.UserAchievements[0] >= '1' ? "Получено" : lbl1.Text, button = unloc1, label = lbl1 });
            achivement.Add(new Achivement() { state = user.UserAchievements[1] >= '1' ? "Получено" : lbl2.Text, button = unloc2, label = lbl2 });

            return achivement;
        }
        public AccountPage(User user)
        {
            InitializeComponent();

            profile.Source = user.UserProfile;

            username.Text = user.UserName;

            List<AButton> aButtons = Init(user);
            List<Achivement> achivement = initach(user);

            for (int i = 0; i < 8; i++)
            {
                if (!aButtons[i].open)
                {
                    aButtons[i].button.Source = "lock.png";
                }
            }

            for(int i = 0; i < 2; i++)
            {
                if (achivement[i].state == "Получено")
                {
                    achivement[i].label.Text = "Получено";
                    achivement[i].button.BackgroundColor = Color.FromHex("#2F9BDF");
                    achivement[i].label.TextColor = Color.FromHex("#60af21");
                    achivement[i].button.IsEnabled = true;
                }
                else
                {
                    achivement[i].button.BackgroundColor = Color.LightGray;
                    achivement[i].button.IsEnabled = false;
                }

                if(user.UserAchievements[i] == '2')
                {
                    achivement[i].button.BackgroundColor = Color.FromHex("#60af21");
                    achivement[i].button.Text = "Награды собраны";
                    achivement[i].button.IsEnabled = false;
                }
            }

            gamelabel.Text = $"Мини-игр пройдено: {user.UserGamesProgress}/6";
            lessonlabel.Text = $"Уроков пройдено: {user.UserLessonsProgress}/6";
            recordlabel.Text = $"✦ {user.UserPrimogames}";

            achivement[0].button.Clicked += (sender, e) => Btn_clic(0, achivement, user);
            achivement[1].button.Clicked += (sender, e) => Btn_clic(1, achivement, user);

            aButtons[0].button.Clicked += (sender, e) => Ava_clic(aButtons[0], 0, user);
            aButtons[1].button.Clicked += (sender, e) => Ava_clic(aButtons[1], 1, user);
            aButtons[2].button.Clicked += (sender, e) => Ava_clic(aButtons[2], 2, user);
            aButtons[3].button.Clicked += (sender, e) => Ava_clic(aButtons[3], 3, user);
            aButtons[4].button.Clicked += (sender, e) => Ava_clic(aButtons[4], 4, user);
            aButtons[5].button.Clicked += (sender, e) => Ava_clic(aButtons[5], 5, user);
            aButtons[6].button.Clicked += (sender, e) => Ava_clic(aButtons[6], 6, user);
            aButtons[7].button.Clicked += (sender, e) => Ava_clic(aButtons[7], 7, user);

            btn_list.Clicked += (sender, e) => Navigation.PushAsync(new TopPage(user));
        }
        private async void Btn_clic(int index, List<Achivement> achivement, User user)
        {
            if (user.UserAchievements[0] == '1')
            {
                user.UserPrimogames += 20;
            }

            recordlabel.Text = $"✦ {user.UserPrimogames}";

            char[] charStr = user.UserAchievements.ToCharArray();
            charStr[0] = '2';
            string drb = new string(charStr);

            user.UserAchievements = drb;

            await repos.Update(user);

            achivement[0].button.BackgroundColor = Color.FromHex("#60af21");
            achivement[0].button.Text = "Награды собраны";
            achivement[0].button.IsEnabled = false;
        }
        private async void Ava_clic(AButton aButton, int index, User user)
        {
            if (!aButton.open)
            {
                await aButton.button.TranslateTo(-15, 0, 50);
                await aButton.button.TranslateTo(15, 0, 50);
                await aButton.button.TranslateTo(-10, 0, 50);
                await aButton.button.TranslateTo(10, 0, 50);
                await aButton.button.TranslateTo(-5, 0, 50);
                await aButton.button.TranslateTo(5, 0, 50);
                aButton.button.TranslationX = 0;
            }
            else
            {
                await aButton.button.ScaleTo(1.2, 170, easing: Easing.Linear);
                await aButton.button.ScaleTo(1, 170, easing: Easing.Linear);

                switch(index)
                {
                    case 0:
                        {
                            user.UserProfile = "ava1.png";
                            break;
                        }
                    case 1:
                        {
                            user.UserProfile = "ava2.png";
                            break;
                        }
                    case 2:
                        {
                            user.UserProfile = "ava3.png";
                            break;
                        }
                    case 3:
                        {
                            user.UserProfile = "ava4.png";
                            break;
                        }
                    case 4:
                        {
                            user.UserProfile = "ava5.png";
                            break;
                        }
                    case 5:
                        {
                            user.UserProfile = "ava6.png";
                            break;
                        }
                    case 6:
                        {
                            user.UserProfile = "ava7.png";
                            break;
                        }
                    case 7:
                        {
                            user.UserProfile = "ava8.png";
                            break;
                        }
                }

                profile.Source = user.UserProfile;

                await repos.Update(user);
            }
        }
    }
}

