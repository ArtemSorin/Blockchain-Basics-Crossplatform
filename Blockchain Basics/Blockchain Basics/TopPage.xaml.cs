using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Input;
using BlockchainBasics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace Blockchain_Basics
{
    public partial class TopPage : ContentPage
    {
        UserRepository repos = new UserRepository();
        public struct Data
        {
            public string ava;
            public string name;
            public int score;
            public string price;
        }
        public struct Container
        {
            public ImageButton ava;
            public Xamarin.Forms.Label name;
            public Xamarin.Forms.Label score;
            public ImageButton price;
        }
        public void initialize(ref Container[] container)
        {
            container[0].ava = btn1;
            container[1].ava = btn2;
            container[2].ava = btn3;
            container[3].ava = btn4;
            container[4].ava = btn5;

            container[0].name = label_name1;
            container[1].name = label_name2;
            container[2].name = label_name3;
            container[3].name = label_name4;
            container[4].name = label_name5;

            container[0].score = label_score1;
            container[1].score = label_score2;
            container[2].score = label_score3;
            container[3].score = label_score4;
            container[4].score = label_score5;

            container[0].price = price1;
            container[1].price = price2;
            container[2].price = price3;
            container[3].price = price4;
            container[4].price = price5;
        }
        public TopPage(User user)
        {
            InitializeComponent();

            Data[] data = new Data[1000];

            f(data);

            ICommand refreshCommand = new Command( () =>
            {
                f(data);
                refreshView.IsRefreshing = false;
            });

            refreshView.Command = refreshCommand;
        }
        public async void f(Data[] data)
        {
            var database = await repos.GetAllUsers();

            int size = 0;

            foreach (var item in database)
            {
                data[size].ava = item.UserProfile;
                data[size].name = item.UserName;
                data[size].score = item.UserPrimogames;

                size++;
            }

            QuickSort(data, 0, size);

            Container[] container = new Container[5];

            initialize(ref container);

            for(int i = 0; i < 5; i++)
            {
                container[i].ava.Source = data[i].ava;
                container[i].name.Text = data[i].name;
                container[i].score.Text = data[i].score.ToString();
                container[i].price.IsEnabled = false;
                container[i].price.BackgroundColor = Xamarin.Forms.Color.White;
            }

            container[0].price.Source = "gold_cup.png";
            container[1].price.Source = "silver_cup.png";
            container[2].price.Source = "bronze_cup.png";
        }
        private void QuickSort(Data[] data, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(data, start, end);

                QuickSort(data, start, i - 1);
                QuickSort(data, i + 1, end);
            }
        }

        private int Partition(Data[] data, int start, int end)
        {
            Data temp;
            Data p = data[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (data[j].score >= p.score)
                {
                    i++;
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }

            temp = data[i + 1];
            data[i + 1] = data[end];
            data[end] = temp;
            return i + 1;
        }
    }
}

