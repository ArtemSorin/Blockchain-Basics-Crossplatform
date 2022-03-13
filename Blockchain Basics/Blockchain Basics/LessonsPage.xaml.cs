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
    public partial class LessonsPage : ContentPage
    {
        public LessonsPage()
        {
            InitializeComponent();

            button1.Clicked += (s, e) => Navigation.PushAsync(new FirstLessonPage());
            button2.Clicked += (s, e) => Navigation.PushAsync(new SecondLessonPage());
        }
    }
}