using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LearningWords
{
    /// <summary>
    /// Interaction logic for Create_words_window.xaml
    /// </summary>
    public partial class Create_words_window : Window
    {
        public Create_words_window()
        {
            InitializeComponent();
        }

        private void TextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = $"{English_Words_Name.Text}";
            string path1 = $"{Russian_Words_Name.Text}";


            string text = English_words.Text;
            string text1 = Russian_words.Text;


            // запись в файл
            if (path != "" || path1 != "")
            {
                if (text != "" && text1 != "")
                {

                    if (File.Exists($"{path}"))
                    {
                        using (FileStream fstream = new FileStream($"{path}.txt", FileMode.Append))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text);
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    else
                    {
                        using (FileStream fstream = new FileStream($"{path}.txt", FileMode.OpenOrCreate))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text);
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    if (File.Exists($"{path1}"))
                    {
                        using (FileStream fstream = new FileStream($"{path1}.txt", FileMode.Append))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text1);
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    else
                    {
                        using (FileStream fstream = new FileStream($"{path1}.txt", FileMode.OpenOrCreate))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text1);
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Заполните словами", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }

               



                
            }
            else
            {
                MessageBox.Show("Нет имени файла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void English_words_MouseEnter(object sender, MouseEventArgs e)
        {
            //English_words.Text = English_words.Text.Replace(Environment.NewLine, "");
        }

        
    }
}
