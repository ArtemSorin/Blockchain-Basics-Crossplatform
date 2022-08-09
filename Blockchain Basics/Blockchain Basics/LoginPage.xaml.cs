using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            button_sing.Clicked += CreateFriend;
            button_into.Clicked += SignIn;
        }
        private async void CreateFriend(object sender, EventArgs e)
        {
            User friend = new User();
            RegistrationPage friendPage = new RegistrationPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
        private async void SignIn(object sender, EventArgs e)
        {
            var data = App.Database.GetItems();

            bool flag = false;
            int ID = 0;

            foreach (var item in data)
            {
                if (item.UserName == UserLoginEmail.Text && item.UserPassword == UserLoginPassword.Text)
                {
                    flag = true;
                    ID = item.id;
                }
            }

            if(flag)
            {
                await Navigation.PushAsync(new MainPage(ID));
            }

            else
            {
                await DisplayAlert("Уведомление", "Неправильный логин или пароль", "Ок");
            }
        }
    }
}