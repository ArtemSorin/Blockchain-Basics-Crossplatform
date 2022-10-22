using System;
using System.Collections.Generic;
using Blockchain_Basics;
using Xamarin.Forms;

namespace BlockchainBasics
{
    public partial class ThirdLessonPage : ContentPage
    {
        public ThirdLessonPage(User user)
        {
            InitializeComponent();

            quiz1.Clicked += (sender, e) => Navigation.PushAsync(new ThirdQuizPage(user));
        }
    }
}

