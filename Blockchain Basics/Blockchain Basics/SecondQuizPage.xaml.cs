using BlockchainBasics;
using Syncfusion.XForms.Buttons;
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
    public partial class SecondQuizPage : ContentPage
    {
        UserRepository repos = new UserRepository();

        public bool local_state = false;
        public short qestions_update = 0;
        public short correct_answers = 0;
        public struct Question
        {
            public string question;
            public string answer1;
            public string answer2;
            public string answer3;
            public int correct_answer;
        }
        public SecondQuizPage(User user)
        {
            InitializeComponent();

            List<Question> list = new List<Question>();

            list.Add(new Question() { answer1 = "можно менять по своему желанию", answer2 = "невозможно изменить или удалить", answer3 = "нельзя изменить, а удалить возможно", question = "Однажды записанную в blockchain информацию", correct_answer = 1 });
            list.Add(new Question() { answer1 = "first block", answer2 = "main block", answer3 = "genesis block", question = "Как называется первый уникальный блок цепочки (блок зарождения)?", correct_answer = 2 });
            list.Add(new Question() { answer1 = "Сатоши Накамото", answer2 = "Билл Гейтс", answer3 = "Павел Дуров", question = "Кто изобрёл blockchain?", correct_answer = 0 });

            label.Text = list[0].question;

            check1.Text = list[0].answer1;
            check2.Text = list[0].answer2;
            check3.Text = list[0].answer3;

            check1.StateChanged += RadioButton_StateChanged_First;
            check2.StateChanged += RadioButton_StateChanged_Second;
            check3.StateChanged += RadioButton_StateChanged_Third;

            btn_answer.Clicked += (sender, e) => updateQuestion(list, user);
        }
        private void RadioButton_StateChanged_First(object sender, StateChangedEventArgs e)
        {
            if (e.IsChecked.HasValue && e.IsChecked.Value && label.Text == "Кто изобрёл blockchain?")
            {
                local_state = true;
            }
            else
            {
                local_state = false;
            }
        }
        private void RadioButton_StateChanged_Second(object sender, StateChangedEventArgs e)
        {
            if (e.IsChecked.HasValue && e.IsChecked.Value && label.Text == "Однажды записанную в blockchain информацию")
            {
                local_state = true;
            }
            else
            {
                local_state = false;
            }
        }
        private void RadioButton_StateChanged_Third(object sender, StateChangedEventArgs e)
        {
            if (e.IsChecked.HasValue && e.IsChecked.Value && label.Text == "Как называется первый уникальный блок цепочки (блок зарождения)?")
            {
                local_state = true;
            }
            else
            {
                local_state = false;
            }
        }
        private async void updateQuestion(List<Question> list, User user)
        {
            if (qestions_update != 2)
            {
                qestions_update += 1;

                label.Text = list[qestions_update].question;

                check1.Text = list[qestions_update].answer1;
                check2.Text = list[qestions_update].answer2;
                check3.Text = list[qestions_update].answer3;

                if (local_state)
                {
                    correct_answers++;
                }
            }
            else
            {
                label.Text = $"Правильно {correct_answers} из 3";
                check1.IsVisible = false;
                check2.IsVisible = false;
                check3.IsVisible = false;

                //if (correct_answers == 3)
                {
                    if (!user.Qiizes_completed[1])
                    {
                        user.Qiizes_completed[1] = true;

                        user.UserProgress += 0.07;
                        user.UserPrimogames += 20;

                        await repos.Update(user);
                    }
                }
            }
        }
    }
}