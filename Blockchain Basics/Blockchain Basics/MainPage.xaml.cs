using Android.Content.Res;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Blockchain_Basics
{
    public partial class MainPage : TabbedPage
    {
        public string WebAPIkey = "AIzaSyB9drN6gEKCY-7buO02rAVH0ZSbACT-hsw";
        public double value = 0.0f;
        public void Calculate_lvl() { value += 0.2f; }
        public MainPage()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            button_game_1.Clicked += (sender, e) => Navigation.PushAsync(new FirstGamePage());
            button_game_2.Clicked += (sender, e) => Navigation.PushAsync(new SecondGamePage());
            button_game_3.Clicked += (sender, e) => Navigation.PushAsync(new ThirdGamePage());
            button_game_4.Clicked += (sender, e) => Navigation.PushAsync(new FourthGamePage());

            button_lesson_1.Clicked += (s, e) => Navigation.PushAsync(new FirstLessonPage());
            button_lesson_2.Clicked += (s, e) => Navigation.PushAsync(new SecondLessonPage());
        }
        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                MyUserName.Text = savedfirebaseauth.User.Email;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }

        }
        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
        protected override void OnAppearing()
        {
            object name = "";
            if (App.Current.Properties.TryGetValue("named", out name))
            {
                progressbar.Progress = (double)name;
            }
            base.OnAppearing();
        }
        private void OnClick(object sender, EventArgs e)
        {
            progressbar.Progress = value;
            value = progressbar.Progress;

            App.Current.Properties["named"] = value;
        }
    }
}
