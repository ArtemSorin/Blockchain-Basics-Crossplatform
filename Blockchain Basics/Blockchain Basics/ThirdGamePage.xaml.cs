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
        public struct question
        {
            public string image;
            public string var1;
            public string var2;
            public string var3;
            public int answer;
        }
        public List<question> initialQuestLite() // инициализация списка легких вопросов
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
        int answerUpdate(
            ref List<question> questionsList, // ссылка на список с вопросами
            int oldQuest, // индекс старого вопроса
            int oldAnswer, // ответ на старый вопрос
            ref int countExcelentQuestionAnswers // ссылка на счетчик правильных ответов
            ) // возвращает индекс нового вопроса или -1, если вопросы закончились. Удаляет старый вопрос. Проверяет старый вопрос на правильность ответа.
        {
            // проверка ответа на вопрос
            if (oldAnswer == questionsList[oldQuest].answer)
            {
                countExcelentQuestionAnswers++;
            }
            // удаление старого вопроса
            questionsList.RemoveAt(oldQuest);

            Random rnd = new Random();

            if (questionsList.Count != 0)
            {
                // рандомный выбор индекса нового вопроса
                int randQuestIndex = rnd.Next(0, questionsList.Count);

                // установка view вопроса
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

        void showRes( // показ результата и последующие действия
            int countExcelentQuestionAnswers, // счетчик правильных ответов
            int allCount, // сколько всего есть вопросов
            int buttonP // что сейчас делать? 1 - ничего 2 - рестарт 3 - выход
            )
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
                //----------------------------------------------------------------------------------
                // здесь выход с этого активити
                //----------------------------------------------------------------------------------
            }
        }
        public ThirdGamePage()
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

            // счетчик правильных ответов
            int countExcelentQuestionAnswers = 0;

            // инициализация легких вопросов и помещение в множество
            List<question> questionsList = initialQuestLite();

            //общее число вопросов
            int countAllQuestions = questionsList.Count;


            Random rnd = new Random();


            // рандомный выбор первого вопроса
            int randQuestIndex = rnd.Next(0, questionsList.Count);

            // установка view первого вопроса
            questImage.Source = questionsList[randQuestIndex].image;
            button1.Text = questionsList[randQuestIndex].var1;
            button2.Text = questionsList[randQuestIndex].var2;
            button3.Text = questionsList[randQuestIndex].var3;

            int curQuestIndex = randQuestIndex;

            // обработка кликов 
            button1.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 1, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }

            };

            button2.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 2);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 2, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }

            };

            button3.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 3);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 3, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }

            };
        }
    }
}