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
    public partial class SecondGamePage : ContentPage
    {
        public static string block_chain;
        public static int stack_counter;
        public const int nums_blocks = 3;
        public static int[] stack_of_blocks = new int[nums_blocks];
        public static int[] correct_stack = new int[nums_blocks];
        public static int current_lvl = 0;
        public static int[,] mas_correct = new int[6, nums_blocks];

        public SecondGamePage()
        {
            InitializeComponent();
            block_chain = "<здесь будет ваша последовательность>";
            current_chain.Text = block_chain;
            stack_counter = 0;

            correct_stack[0] = 1; correct_stack[1] = 2; correct_stack[2] = 3;

            mas_correct[0, 0] = 1; mas_correct[0, 1] = 2; mas_correct[0, 2] = 3;
            mas_correct[1, 0] = 2; mas_correct[1, 1] = 1; mas_correct[1, 2] = 3;
            mas_correct[2, 0] = 1; mas_correct[2, 1] = 2; mas_correct[2, 2] = 3;
            mas_correct[3, 0] = 3; mas_correct[3, 1] = 1; mas_correct[3, 2] = 2;
            mas_correct[4, 0] = 3; mas_correct[4, 1] = 2; mas_correct[4, 2] = 1;
            mas_correct[5, 0] = 1; mas_correct[5, 1] = 3; mas_correct[5, 2] = 2;
        }
        protected override void OnAppearing()
        {
            resetbutton.Clicked += variable_declaration;
            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button2_Clicked;
            button3.Clicked += Button3_Clicked;
            nextlvl_button.Clicked += next_lvl;
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
                current_chain.Text = block_chain;
                current_chain.BackgroundColor = Color.Green;
                nextlvl_button.IsVisible = !nextlvl_button.IsVisible;
                resetbutton.IsVisible = !nextlvl_button.IsVisible;
            }
            else
            {
                block_chain = block_chain.Remove(0, 1);
                block_chain += "\nПоследовательность некорректна!";
                current_chain.Text = block_chain;
                current_chain.BackgroundColor = Color.Red;
            }
            stack_counter++;
        }

        private void variable_declaration(object sender, EventArgs e)
        {
            block_chain = "<здесь будет ваша последовательность>";
            current_chain.Text = block_chain;
            stack_counter = 0;
            current_chain.BackgroundColor = Color.Default;
            button1.BackgroundColor = Color.Blue;
            button2.BackgroundColor = Color.Blue;
            button3.BackgroundColor = Color.Blue;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (stack_counter == 0)
                block_chain = "\n";
            if (button1.BackgroundColor != Color.Red)
            {
                button1.BackgroundColor = Color.Red;
                block_chain = block_chain + "Блок 1 ➔ ";
                current_chain.Text = block_chain;
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
                block_chain = block_chain + "Блок 2 ➔ ";
                current_chain.Text = block_chain;
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
                block_chain = block_chain + "Блок 3 ➔ ";
                current_chain.Text = block_chain;
                stack_of_blocks[stack_counter] = 3;
                stack_counter++;
            }
            if (stack_counter == nums_blocks)
            {
                stackcheck();
            }
        }
        private void next_lvl(object sender, EventArgs e)
        {
            current_lvl++;
            if (current_lvl <= 5)
            {
                block_chain = "<здесь будет ваша последовательность>";
                current_chain.Text = block_chain;
                stack_counter = 0;
                current_chain.BackgroundColor = Color.Default;
                button1.BackgroundColor = Color.Blue;
                button2.BackgroundColor = Color.Blue;
                button3.BackgroundColor = Color.Blue;
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
                current_chain.Text = block_chain;
                current_chain.BackgroundColor = Color.Default;
                nextlvl_button.IsVisible = !nextlvl_button.IsVisible;

            }

        }

    }
}