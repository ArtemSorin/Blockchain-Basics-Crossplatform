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
    public partial class FirstLessonPage : ContentPage
    {
        public FirstLessonPage(User user)
        {
            InitializeComponent();
            quiz1.Clicked += (s, e) => Navigation.PushAsync(new FirstQuizPage(user));
        }
    }
}