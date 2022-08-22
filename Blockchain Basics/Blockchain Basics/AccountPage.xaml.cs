using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static Blockchain_Basics.ThirdGamePage;
using static Xamarin.Forms.Internals.Profile;

namespace Blockchain_Basics
{
    public partial class AccountPage : ContentPage
    {
        public struct AButton
        {
            public bool open;
            public ImageButton button;
        }
        public List<AButton> init(int ID)
        {
            List<AButton> aButtons = new List<AButton>();

            var data = App.Database.GetItem(ID);

            aButtons.Add(new AButton() { button = im1, open = true });
            aButtons.Add(new AButton() { button = im2, open = data.UserProgress > 0.2 ? true : false });
            aButtons.Add(new AButton() { button = im3, open = data.UserProgress > 0.3 ? true : false });
            aButtons.Add(new AButton() { button = im4, open = data.UserProgress > 0.4 ? true : false });
            aButtons.Add(new AButton() { button = im5, open = data.UserProgress > 0.5 ? true : false });
            aButtons.Add(new AButton() { button = im6, open = data.UserProgress > 0.6 ? true : false });
            aButtons.Add(new AButton() { button = im7, open = data.UserProgress > 0.7 ? true : false });
            aButtons.Add(new AButton() { button = im8, open = data.UserProgress > 0.8 ? true : false });

            return aButtons;
        }
        public AccountPage(int ID)
        {
            InitializeComponent();
            var data = App.Database.GetItem(ID);

            profile.Source = data.UserProfile;

            username.Text = data.UserName;

            List<AButton> aButtons = init(ID);

            for(int i = 0; i < 8; i++)
            {
                if (!aButtons[i].open)
                {
                    aButtons[i].button.Source = "lock.png";
                }
            }

            for(int i = 0; i < data.UserAchievements.Length; i++)
            {
                if (data.UserAchievements[i] == '1')
                {
                    
                }
            }

            gamelabel.Text = $"Мини-игр пройдено: {data.UserGamesProgress}/6";
            lessonlabel.Text = $"Уроков пройдено: {data.UserLessonsProgress}/6";
            recordlabel.Text = $"✦ {data.UserPrimogames}";

            aButtons[0].button.Clicked += (sender, e) => ava_clic(aButtons[0], ID, 0);
            aButtons[1].button.Clicked += (sender, e) => ava_clic(aButtons[1], ID, 1);
            aButtons[2].button.Clicked += (sender, e) => ava_clic(aButtons[2], ID, 2);
            aButtons[3].button.Clicked += (sender, e) => ava_clic(aButtons[3], ID, 3);
            aButtons[4].button.Clicked += (sender, e) => ava_clic(aButtons[4], ID, 4);
            aButtons[5].button.Clicked += (sender, e) => ava_clic(aButtons[5], ID, 5);
            aButtons[6].button.Clicked += (sender, e) => ava_clic(aButtons[6], ID, 6);
            aButtons[7].button.Clicked += (sender, e) => ava_clic(aButtons[7], ID, 7);
        }
        private async void ava_clic(AButton aButton, int ID, int index)
        {
            var data = App.Database.GetItem(ID);

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
                            data.UserProfile = "ava1.png";
                            break;
                        }
                    case 1:
                        {
                            data.UserProfile = "ava2.png";
                            break;
                        }
                    case 2:
                        {
                            data.UserProfile = "ava3.png";
                            break;
                        }
                    case 3:
                        {
                            data.UserProfile = "ava4.png";
                            break;
                        }
                    case 4:
                        {
                            data.UserProfile = "ava5.png";
                            break;
                        }
                    case 5:
                        {
                            data.UserProfile = "ava6.png";
                            break;
                        }
                    case 6:
                        {
                            data.UserProfile = "ava7.png";
                            break;
                        }
                    case 7:
                        {
                            data.UserProfile = "ava8.png";
                            break;
                        }
                }

                App.Database.SaveItem(data);

                var data1 = App.Database.GetItem(ID);

                profile.Source = data1.UserProfile;
            }
        }
    }
}

