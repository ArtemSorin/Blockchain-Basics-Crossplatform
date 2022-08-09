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
    public partial class ThirdGamePage : ContentPage
    {
        public SQLiteConnection conn;
        public User regmodel;

        public struct question
        {
            public string image;
            public string var1;
            public string var2;
            public string var3;
            public int answer;
        }
        public List<question> initialQuestLite()
        {
            List<question> questions = new List<question>();
            questions.Add(new question() { image = "bitcoin1.png", var1 = "bitcoin", var2 = "bytecoin", var3 = "litecoin", answer = 1 });
            questions.Add(new question() { image = "ethereum1.png", var1 = "prismo", var2 = "ripple", var3 = "ethereum", answer = 3 });
            questions.Add(new question() { image = "litecoin1.png", var1 = "solana", var2 = "litecoin", var3 = "litol-24", answer = 2 });
            questions.Add(new question() { image = "dogecoin1.png", var1 = "dogecoin", var2 = "muskcoin", var3 = "mooncoin", answer = 1 });
            questions.Add(new question() { image = "bytecoin1.png", var1 = "bitcoin", var2 = "bytecoin", var3 = "BitShares", answer = 2 });
            questions.Add(new question() { image = "solana1.png", var1 = "lines", var2 = "ripple", var3 = "solana", answer = 3 });
            questions.Add(new question() { image = "monero1.png", var1 = "monero", var2 = "moneycoin", var3 = "megahash", answer = 1 });
            questions.Add(new question() { image = "vertcoin1.png", var1 = "greencoin", var2 = "okcoin", var3 = "vertcoin", answer = 3 });

            return questions;
        }
        int answerUpdate(ref List<question> questionsList, int oldQuest, int oldAnswer, ref int countExcelentQuestionAnswers)
        {

            if (oldAnswer == questionsList[oldQuest].answer)
            {
                countExcelentQuestionAnswers++;
            }

            questionsList.RemoveAt(oldQuest);

            Random rnd = new Random();

            if (questionsList.Count != 0)
            {
                int randQuestIndex = rnd.Next(0, questionsList.Count);

                questImage.Source = questionsList[randQuestIndex].image;
                button1.Text = questionsList[randQuestIndex].var1;
                button2.Text = questionsList[randQuestIndex].var2;
                button3.Text = questionsList[randQuestIndex].var3;

                return randQuestIndex;
            }
            else
            {
                return -1;
            }
        }
        async void showRes(int countExcelentQuestionAnswers, int allCount, int buttonP, int ID)
        {
            questImage.Source = "answerCheck.png";
            button1.Text = $"верно {countExcelentQuestionAnswers} из {allCount}";
            button2.Text = "пройти заново";
            button3.Text = "выход";

            if (buttonP == 2)
            {
                //----------------------------------------------------------------------------------
                // здесь повторный запуск этого активити
                //----------------------------------------------------------------------------------
            }
            else if (buttonP == 3)
            {
                var data = App.Database.GetItem(ID);
                data.UserGamesProgress++;
                App.Database.SaveItem(data);
                await Navigation.PopAsync();
            }
        }
        public ThirdGamePage(int ID)
        {
            InitializeComponent();

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#2F9BDF"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#51F1F2"), Offset = 1 }
            };

            button1.Background = radialGradientBrush;
            button2.Background = radialGradientBrush;
            button3.Background = radialGradientBrush;

            int countExcelentQuestionAnswers = 0;

            List<question> questionsList = initialQuestLite();

            int countAllQuestions = questionsList.Count;


            Random rnd = new Random();

            int randQuestIndex = rnd.Next(0, questionsList.Count);

            questImage.Source = questionsList[randQuestIndex].image;
            button1.Text = questionsList[randQuestIndex].var1;
            button2.Text = questionsList[randQuestIndex].var2;
            button3.Text = questionsList[randQuestIndex].var3;

            int curQuestIndex = randQuestIndex;

            button1.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 1, ID);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 1, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, ID);
                    }
                }

            };

            button2.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 2, ID);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 2, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, ID);
                    }
                }

            };

            button3.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 3, ID);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 3, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, ID);
                    }
                }

            };
        }
    }
}