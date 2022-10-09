using BlockchainBasics;
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
        UserRepository repos = new UserRepository();

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
            questions.Add(new question() { image = "third_game_avalanche.png", var1 = "Avalanche", var2 = "Bytecoin", var3 = "Litecoin", answer = 1 });
            questions.Add(new question() { image = "third_game_binance.png", var1 = "Bitcoin", var2 = "Ripple", var3 = "Binance", answer = 3 });
            questions.Add(new question() { image = "third_game_bitcoin.png", var1 = "Bytecoin", var2 = "Bitcoin", var3 = "Binance", answer = 2 });
            questions.Add(new question() { image = "third_game_dai.png", var1 = "Dai", var2 = "Muskcoin", var3 = "Dogecoin", answer = 1 });
            questions.Add(new question() { image = "third_game_dogecoin.png", var1 = "Bitcoin", var2 = "Dogecoin", var3 = "Dai", answer = 2 });
            questions.Add(new question() { image = "third_game_ethereum.png", var1 = "Lines", var2 = "Ripple", var3 = "Ethereum", answer = 3 });
            questions.Add(new question() { image = "third_game_litecoin.png", var1 = "Litecoin", var2 = "Moneycoin", var3 = "Lines", answer = 1 });
            questions.Add(new question() { image = "third_game_solana.png", var1 = "Greencoin", var2 = "Okcoin", var3 = "Solana", answer = 3 });
            questions.Add(new question() { image = "third_game_stellar.png", var1 = "Solana", var2 = "Stellar", var3 = "Okcoin", answer = 2 });
            questions.Add(new question() { image = "third_game_tether.png", var1 = "Tether", var2 = "Lines", var3 = "Tron", answer = 1 });
            questions.Add(new question() { image = "third_game_tron.png", var1 = "Tron", var2 = "Tether", var3 = "Stellar", answer = 1 });
            questions.Add(new question() { image = "third_game_wrapped.png", var1 = "Bitcoin", var2 = "Bytecoin", var3 = "Wrapped", answer = 3 });

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
        async void showRes(int countExcelentQuestionAnswers, int allCount, int buttonP, User user)
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
                if (!user.Games_completed[2])
                {
                    user.Games_completed[2] = true;

                    user.UserProgress += 0.55;
                    user.UserGamesProgress++;
                    user.UserPrimogames += 100;

                    await repos.Update(user);
                }

                if (!user.Games_achivement[0])
                {
                    user.Games_achivement[0] = true;

                    if (countExcelentQuestionAnswers == 12)
                    {
                        user.UserAchievements[0] = 1;

                        await repos.Update(user);
                    }
                }

                await Navigation.PopAsync();
            }
        }
        public ThirdGamePage(User user)
        {
            InitializeComponent();

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
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 1, user);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 1, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, user);
                    }
                }

            };

            button2.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 2, user);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 2, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, user);
                    }
                }

            };

            button3.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 3, user);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 3, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1, user);
                    }
                }

            };
        }
    }
}