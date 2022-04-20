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

        public SecondGamePage()
        {
            InitializeComponent();
            block_chain = "<здесь будет ваша последовательность>";
            current_chain.Text = block_chain;
            stack_counter = 0;
            //стыдно!
            correct_stack[0] = 1; correct_stack[1] = 2; correct_stack[2] = 3;
            //стыдно!
        }
        protected override void OnAppearing()
        {
            resetbutton.Clicked += variable_declaration;
            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button2_Clicked;
            button3.Clicked += Button3_Clicked;
            nextlvl_button.Clicked += next_lvl;
        }
        //-----------------------
        //проверка стака на корректность
        //меняет переменные
        //на вход ничего не получает
        //-----------------------
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

        //-----------------------
        //обнуление переменных (aka restart)
        //меняет переменные
        //на вход ничего не получает
        //-----------------------
        private async void variable_declaration(object sender, EventArgs e)
        {
            block_chain = "<здесь будет ваша последовательность>";
            current_chain.Text = block_chain;
            stack_counter = 0;
            current_chain.BackgroundColor = Color.Default;
            button1.BackgroundColor = Color.Blue;
            button2.BackgroundColor = Color.Blue;
            button3.BackgroundColor = Color.Blue;
        }
        //-----------------------
        //нажатие ПЕРВОЙ кнопки
        //наверное не меняет переменные
        //на вход получает неведомую фигню
        //-----------------------
        private async void Button1_Clicked(object sender, EventArgs e)
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
        //-----------------------
        //нажатие ВТОРОЙ кнопки
        //наверное не меняет переменные
        //на вход получает неведомую фигню
        //-----------------------
        private async void Button2_Clicked(object sender, EventArgs e)
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
        //-----------------------
        //нажатие ТРЕТЬЕЙ кнопки
        //наверное не меняет переменные
        //на вход получает неведомую фигню
        //-----------------------
        private async void Button3_Clicked(object sender, EventArgs e)
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
        //-----------------------
        //фейковый переход на "следующий" уровень
        //наверное не меняет переменные
        //на вход получает неведомую фигню
        //-----------------------
        private async void next_lvl(object sender, EventArgs e)
        {
            //обнуляем всё
            block_chain = "<здесь будет ваша последовательность>";
            current_chain.Text = block_chain;
            stack_counter = 0;
            current_chain.BackgroundColor = Color.Default;
            button1.BackgroundColor = Color.Blue;
            button2.BackgroundColor = Color.Blue;
            button3.BackgroundColor = Color.Blue;
            nextlvl_button.IsVisible = !nextlvl_button.IsVisible;
            resetbutton.IsVisible = !nextlvl_button.IsVisible;


            //------

            //меняем стек
            for (int i = 0; i < nums_blocks; i++)
            {
                if (correct_stack[i] < nums_blocks)
                    correct_stack[i]++;
                else
                    correct_stack[i] = 1;
            }

        }

    }
}