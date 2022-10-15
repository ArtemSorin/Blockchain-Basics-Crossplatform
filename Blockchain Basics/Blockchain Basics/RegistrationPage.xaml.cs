using BlockchainBasics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        UserRepository repos = new UserRepository();

        public RegistrationPage()
        {
            InitializeComponent();
        }
        private async void Signed_Clicked(object sender, EventArgs e)
        {
            var data = await repos.GetAllUsers();
            bool flag = true;

            foreach (var item in data)
            {
                if(item.UserName == UserNewEmail.Text)
                {
                    flag = false;
                    await DisplayAlert("Уведомление", "Это имя уже используется", "Ок");
                    break;
                }
            }



            if(flag)
            {
                User user = new User();

                List<bool> bools_achivement = new List<bool>() { false, false, false, false, false };
                List<bool> bools_completed = new List<bool>() { false, false, false, false, false };
                List<bool> bools_SelectedLessons = new List<bool>() { false, false, false, false, false, false, false, false };
                List<int> bools_Achievements = new List<int>() { 0, 0, 0, 0, 0, 0 };
                List<bool> bools_quizes = new List<bool>() { false, false, false, false, false, false, false, false };

                user.UserName = UserNewEmail.Text;
                user.UserPassword = HashPassword(UserNewPassword.Text);
                user.UserProgress = 0.0f;
                user.UserLessonsProgress = 0;
                user.UserGamesProgress = 0;
                user.UserSelectedLessons = bools_SelectedLessons;
                user.UserProfile = "ava1.png";
                user.UserAchievements = bools_Achievements;
                user.UserPrimogames = 0;
                user.Games_achivement = bools_achivement;
                user.Games_completed = bools_completed;
                user.Qiizes_completed = bools_quizes;

                var isSaved = await repos.SaveUser(user);

                if(isSaved)
                {
                    await DisplayAlert("Уведомление", "Регистрация прошла успешно", "Ок");
                }

                /*
                var user = (User)BindingContext;
                {
                    user.UserProgress = 0.0f;
                    user.UserLessonsProgress = 0;
                    user.UserGamesProgress = 0;
                    user.UserSelectedLessons = "00000000";
                    user.UserProfile = "ava1.png";
                    user.UserAchievements = "000000";
                    user.UserPrimogames = 0;
                    App.Database.SaveItem(user);
                }
                DisplayAlert("Уведомление", "Регистрация прошла успешно", "Ок");
                */
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                byte[] hash = sHA256.ComputeHash(bytes);

                string hash_password = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return hash_password;
            }
        }
    }
}