using BlockchainBasics;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blockchain_Basics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondGamePage : ContentPage
    {
        UserRepository repos = new UserRepository();
        public static string block_chain;
        public static int stack_counter;
        public const int nums_blocks = 3;
        public static int[] stack_of_blocks = new int[nums_blocks];
        public static int[] correct_stack = new int[nums_blocks];
        public static int current_lvl = 0;
        public static int[,] mas_correct = new int[6, nums_blocks];
        public static string[,] lines = new string[6, nums_blocks];
        public static string[,] lines_button = new string[6, nums_blocks];
        public List<Frame> frame = new List<Frame>();
        public List<Label> label = new List<Label>();

        public SQLiteConnection conn;
        public User regmodel;
        int IDone;

        public SecondGamePage(User user)
        {
            InitializeComponent();

            block_chain = "<здесь будет ваша последовательность>";

            stack_counter = 0;
            correct_stack[0] = 1; correct_stack[1] = 2; correct_stack[2] = 3;

            mas_correct[0, 0] = 1; mas_correct[0, 1] = 2; mas_correct[0, 2] = 3;
            mas_correct[1, 0] = 2; mas_correct[1, 1] = 1; mas_correct[1, 2] = 3;
            mas_correct[2, 0] = 1; mas_correct[2, 1] = 2; mas_correct[2, 2] = 3;
            mas_correct[3, 0] = 3; mas_correct[3, 1] = 1; mas_correct[3, 2] = 2;
            mas_correct[4, 0] = 3; mas_correct[4, 1] = 2; mas_correct[4, 2] = 1;
            mas_correct[5, 0] = 1; mas_correct[5, 1] = 3; mas_correct[5, 2] = 2;

            lines[0, 0] = "a=10 eth; b=10 eth; c=10 eth. a➔b (10eth)\n"; lines[0, 1] = "a=0 eth; b=20 eth; c=10 eth. b➔c (5eth)\n"; lines[0, 2] = "a=0 eth; b=15 eth; c=15 eth. b➔c (5 eth)\n";
            lines[1, 0] = "a=5 eth; b=10 eth; c=15 eth. a➔b (5eth)\n"; lines[1, 1] = "a=0 eth; b=10 eth; c=20 eth. c➔a (5eth)\n"; lines[1, 2] = "a=0 eth; b=15 eth; c=15 eth. c➔b (5eth)\n";
            lines[2, 0] = "a=1 eth; b=2 eth; c=3 eth. c➔a (3eth)\n"; lines[2, 1] = "a=4 eth; b=2 eth; c=0 eth. a➔b  (3eth)\n"; lines[2, 2] = "a=1; b=5 eth; c=0 eth. b➔a (5eth)\n";
            lines[3, 0] = "add=6 eth; bad=6 eth; car=0 eth. add➔car(6eth)\n"; lines[3, 1] = "add=0 eth; bad=6 eth; car=6 eth. bad➔add (3eth)\n"; lines[3, 2] = "add=12 etc; bad=0 eth; car=0 eth. add➔bad (6etc)\n";
            lines[4, 0] = "a=0 eth; b=3 eth; c=0 eth. b➔a (3eth)\n"; lines[4, 1] = "a=0 eth; b=2 eth; c=1 eth. c➔b (1eth)\n"; lines[4, 2] = "a=1 eth; b=1 eth; c=1 eth. a➔b (1eth)\n";
            lines[5, 0] = "a=10 eth; b=10 eth; c=10 eth; d=10. a➔d (10eth)\n"; lines[5, 1] = "a=0 eth; b=15 eth; c=10 eth; d=15 eth. c➔a (5eth)\n"; lines[5, 2] = "a=0; b=10 eth; c=10 eth; d=20 eth. d➔b (5eth)\n";

            lines_button[0, 0] = "Блок 1:\na=10 eth\n b=10 eth\n c=10 eth\n a➔b (10eth)\n"; lines_button[0, 1] = "Блок 2:\na=0 eth\n b=20 eth\n c=10 eth\n b➔c (5eth)\n"; lines_button[0, 2] = "Блок 3:\na=0 eth\n b=15 eth\n c=15 eth\n b➔c (5 eth)\n";
            lines_button[1, 0] = "Блок 1:\na=5 eth\n b=10 eth\n c=15 eth\n a➔b (5eth)\n"; lines_button[1, 1] = "Блок 2:\na=0 eth\n b=10 eth\n c=20 eth\n c➔a (5eth)\n"; lines_button[1, 2] = "Блок 3:\na=0\n b=15 eth\n c=15 eth\n c➔b (5eth)\n";
            lines_button[2, 0] = "Блок 1:\na=1 eth\n b=2 eth\n c=3 eth\n c➔a (3eth)\n"; lines_button[2, 1] = "Блок 2:\na=4 eth\n b=2 eth\n c=0 eth\n a➔b  (3eth)\n"; lines_button[2, 2] = "Блок 3:\na=1\n b=5 eth\n c=0 eth\n b➔a (5eth)\n";
            lines_button[3, 0] = "Блок 1:\nadd=6 eth\n bad=6 eth\n car=0 eth\n add➔car(6eth)\n"; lines_button[3, 1] = "Блок 2:\nadd=0 eth\n bad=6 eth\n car=6 eth\n bad➔add (3eth)\n"; lines_button[3, 2] = "Блок 3:\nadd=12 etc\n bad=0 eth\n car=0 eth\n add➔bad (6etc)\n";
            lines_button[4, 0] = "Блок 1:\na=0 eth\n b=3 eth\n c=0 eth\n b➔a (3eth)\n"; lines_button[4, 1] = "Блок 2:\na=0 eth\n b=2 eth\n c=1 eth\n c➔b (1eth)\n"; lines_button[4, 2] = "Блок 3:\na=1 eth\n b=1 eth\n c=1 eth\n a➔b (1eth)\n";
            lines_button[5, 0] = "Блок 1:\na=10 eth\n b=10 eth\n c=10 eth\n d=10\n a➔d (10eth)\n"; lines_button[5, 1] = "Блок 2:\na=0 eth\n b=15 eth\n c=10 eth\n d=15 eth\n c➔a (5eth)\n"; lines_button[5, 2] = "Блок 3:\na=0\n b=10 eth\n c=10 eth\n d=20 eth\n d➔b (5eth)\n";


            block1.Text = lines_button[current_lvl, 0];
            block2.Text = lines_button[current_lvl, 1];
            block3.Text = lines_button[current_lvl, 2];

            block1.TextColor = Color.Black;
            block2.TextColor = Color.Black;
            block3.TextColor = Color.Black;

            block1.FontAttributes = FontAttributes.Bold;
            block2.FontAttributes = FontAttributes.Bold;
            block3.FontAttributes = FontAttributes.Bold;

            frame.Add(lbl1);
            frame.Add(lbl2);
            frame.Add(lbl3);

            label.Add(block1_current);
            label.Add(block2_current);
            label.Add(block3_current);

            resetbutton.Clicked += variable_declaration;
            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button2_Clicked;
            button3.Clicked += Button3_Clicked;
            nextlvl_button.Clicked += (sender, e) => next_lvl(user);
        }
        protected override void OnAppearing()
        {

        }
        private void stackcheck()
        {
            bool res = true;
            for (int i = 0; i < nums_blocks; i++)
            {
                if (stack_of_blocks[i] != correct_stack[i])
                    res = false;
            }
            if (res)
            {
                block_chain = block_chain.Remove(0, 1);
                block_chain += "\nПоследовательность корректна!";
                //current_chain.Text = block_chain;
                //current_chain.BackgroundColor = Color.Green;
                nextlvl_button.IsVisible = !nextlvl_button.IsVisible;
                resetbutton.IsVisible = !nextlvl_button.IsVisible;
            }
            else
            {
                block_chain = block_chain.Remove(0, 1);
                block_chain += "\nПоследовательность некорректна!";
                //current_chain.Text = block_chain;
                //current_chain.BackgroundColor = Color.Red;
            }
            stack_counter++;
        }

        private void variable_declaration(object sender, EventArgs e)
        {
            block_chain = "здесь будет ваша последовательность";
            stack_counter = 0;
            button1.BackgroundColor = Color.FromHex("#2F9BDF");
            button2.BackgroundColor = Color.FromHex("#2F9BDF");
            button3.BackgroundColor = Color.FromHex("#2F9BDF");

            for (int i = 0; i < 3; i++)
            {
                frame[i].IsVisible = false;
                label[i].Text = "";
            }
        }
        private int set_up_state(List<Frame> frame)
        {
            int k = 0;
            for(int i = 0; i < 3; i++)
            {
                if(frame[i].IsVisible == false)
                {
                    k = i;
                    break;
                }
            }

            frame[k].IsVisible = true;
            return k;
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (stack_counter == 0)
                block_chain = "\n";
            if (button1.BackgroundColor != Color.Red)
            {
                button1.BackgroundColor = Color.Red;
                block_chain = lines_button[current_lvl, 0];
                label[set_up_state(frame)].Text = block_chain;
                stack_of_blocks[stack_counter] = 1;
                stack_counter++;
            }
            if (stack_counter == nums_blocks)
            {
                stackcheck();
            }
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            if (stack_counter == 0)
                block_chain = "\n";
            if (button2.BackgroundColor != Color.Red)
            {
                button2.BackgroundColor = Color.Red;
                block_chain = lines_button[current_lvl, 1];
                label[set_up_state(frame)].Text = block_chain;
                stack_of_blocks[stack_counter] = 2;
                stack_counter++;
            }
            if (stack_counter == nums_blocks)
            {
                stackcheck();
            }
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            if (stack_counter == 0)
                block_chain = "\n";
            if (button3.BackgroundColor != Color.Red)
            {
                button3.BackgroundColor = Color.Red;
                block_chain = lines_button[current_lvl, 2];
                label[set_up_state(frame)].Text = block_chain;
                stack_of_blocks[stack_counter] = 3;
                stack_counter++;
            }
            if (stack_counter == nums_blocks)
            {
                stackcheck();
            }
        }
        private async void next_lvl(User user)
        {
            current_lvl++;
            if (current_lvl <= 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    frame[i].IsVisible = false;
                }

                //block_chain = "<здесь будет ваша последовательность>";
                //current_chain.Text = block_chain;

                block1.Text = lines_button[current_lvl, 0];
                block2.Text = lines_button[current_lvl, 1];
                block3.Text = lines_button[current_lvl, 2];
                block1.TextColor = Color.Black;
                block2.TextColor = Color.Black;
                block3.TextColor = Color.Black;

                block1.FontAttributes = FontAttributes.Bold;
                block2.FontAttributes = FontAttributes.Bold;
                block3.FontAttributes = FontAttributes.Bold;
            

            stack_counter = 0;
                //current_chain.BackgroundColor = Color.Default;
                button1.BackgroundColor = Color.FromHex("#2F9BDF");
                button2.BackgroundColor = Color.FromHex("#2F9BDF");
                button3.BackgroundColor = Color.FromHex("#2F9BDF");
                nextlvl_button.IsVisible = !nextlvl_button.IsVisible;
                resetbutton.IsVisible = !nextlvl_button.IsVisible;
                for (int i = 0; i < nums_blocks; i++)
                {
                    correct_stack[i] = mas_correct[current_lvl, i];
                }
            }
            else
            {
                block_chain = "Вы справились со всеми уровнями!\nМолодцы!";
                //current_chain.Text = block_chain;
                //current_chain.BackgroundColor = Color.Default;
                nextlvl_button.IsVisible = !nextlvl_button.IsVisible;
                blocks.IsVisible = false;

                block1.IsVisible = false;
                block2.IsVisible = false;
                block3.IsVisible = false;

                button1.IsVisible = false;
                button2.IsVisible = false;
                button3.IsVisible = false;
                current_lvl = 0;

                if (!user.Games_completed[1])
                {
                    user.Games_completed[1] = true;

                    user.UserProgress += 0.55;
                    user.UserGamesProgress++;
                    user.UserPrimogames += 100;

                    await repos.Update(user);
                }

                if (!user.Games_achivement[3])
                {
                    user.Games_achivement[3] = true;
                    
                    {
                        user.UserAchievements[3] = 1;

                        await repos.Update(user);
                    }
                }
            }
        }
    }
}