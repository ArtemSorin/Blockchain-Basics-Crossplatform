using SQLite;
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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Signed_Clicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            {
                user.UserProgress = 0.0f;
                user.UserLessonsProgress = 0;
                user.UserGamesProgress = 0;
                user.UserSelectedLessons = "00000000";
                user.UserProfile = "ava1.png";
                user.UserAchievements = "000000";
                App.Database.SaveItem(user);
            }
            DisplayAlert("Уведомление", "Регистрация прошла успешно", "Ок");
        }
    }
}