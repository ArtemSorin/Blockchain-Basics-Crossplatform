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
    public partial class GamesPage : ContentPage
    {
        public GamesPage()
        {
            InitializeComponent();


            button_game_1.Clicked += (sender, e) => Navigation.PushAsync(new FirstGamePage());
            button_game_2.Clicked += (sender, e) => Navigation.PushAsync(new SecondGamePage());
        }
    }
}