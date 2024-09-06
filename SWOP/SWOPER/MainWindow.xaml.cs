using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SWOPER
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool check_eng_to_rus = true;
        //true - en/ru
        //false - ru/en

        Dictionary<char, char> keyboard_eng_to_rus = new Dictionary<char, char>
        {
            {'q', 'й'},
            {'w', 'ц'},
            {'e', 'у'},
            {'r', 'к'},
            {'t', 'е'},
            {'y', 'н'},
            {'u', 'г'},
            {'i', 'ш'},
            {'o', 'щ'},
            {'p', 'з'},
            {'[', 'х'},
            {']', 'ъ'},
            {'a', 'ф'},
            {'s', 'ы'},
            {'d', 'в'},
            {'f', 'а'},
            {'g', 'п'},
            {'h', 'р'},
            {'j', 'о'},
            {'k', 'л'},
            {'l', 'д'},
            {';', 'ж'},
            {'\'','э'},
            {'z', 'я'},
            {'x', 'ч'},
            {'c', 'с'},
            {'v', 'м'},
            {'b', 'и'},
            {'n', 'т'},
            {'m', 'ь'},
            {',', 'б'},
            {'.', 'ю'},
            {'/','.' },
        };

        Dictionary<char, char> keyboard_rus_to_eng = new Dictionary<char, char>
        {
            {'й', 'q'},
            {'ц', 'w'},
            {'у', 'e'},
            {'к', 'r'},
            {'е', 't'},
            {'н', 'y'},
            {'г', 'u'},
            {'ш', 'i'},
            {'щ', 'o'},
            {'з', 'p'},
            {'х', '['},
            {'ъ', ']'},
            {'ф', 'a'},
            {'ы', 's'},
            {'в', 'd'},
            {'а', 'f'},
            {'п', 'g'},
            {'р', 'h'},
            {'о', 'j'},
            {'л', 'k'},
            {'д', 'l'},
            {'ж', ';'},
            {'э','\''},
            {'я', 'z'},
            {'ч', 'x'},
            {'с', 'c'},
            {'м', 'v'},
            {'и', 'b'},
            {'т', 'n'},
            {'ь', 'm'},
            {'б', ','},
            {'ю', '.'},
            {'.', '/'}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            input_textbox.Text = "";
            change_button.IsEnabled = true;
            input_textbox.Foreground = Brushes.Black;
        }

        private void input_textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (input_textbox.Text == "")
            {
                change_button.IsEnabled = false;
                input_textbox.Text = "Введите текст";
            }
        }

        private void change_button_Click(object sender, RoutedEventArgs e)
        {

            List<char> array_convert = new List<char>(input_textbox.Text.Length);

            for (int i = 0; i < input_textbox.Text.Length; i++)
            {
                try
                {
                    if (check_eng_to_rus)
                    {
                        array_convert.Add(keyboard_eng_to_rus[input_textbox.Text[i]]);
                    }
                    else
                    {
                        array_convert.Add(keyboard_rus_to_eng[input_textbox.Text[i]]);
                    }
                }
                catch
                {
                    array_convert.Add(input_textbox.Text[i]);
                }
            }
            output_textbox.Text = string.Join("", array_convert);
        }

        private void lang_button_Click(object sender, RoutedEventArgs e)
        {
            if (check_eng_to_rus)
            {
                lang_button.Content = "Ru→En";             
                input_textbox.ToolTip = "Введите Ru текст с раскладкой En";

                check_eng_to_rus = false;
            }
            else
            {            
                lang_button.Content = "En→Ru";             
                input_textbox.ToolTip = "Введите En текст с раскладкой Ru";

                check_eng_to_rus = true;
            }
        }

        private void copy_button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(output_textbox.Text);
        }

    }
}
