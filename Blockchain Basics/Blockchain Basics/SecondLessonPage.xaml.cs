﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondLessonPage : ContentPage
    {
        public SecondLessonPage(User user)
        {
            InitializeComponent();
            quiz1.Clicked += (sender, e) => Navigation.PushAsync(new SecondQuizPage(user));
        }
    }
}