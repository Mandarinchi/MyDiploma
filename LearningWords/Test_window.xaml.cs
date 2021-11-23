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
    /// Interaction logic for Test_window.xaml
    /// </summary>
    public partial class Test_window : Window
    {
        public Test_window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public string Right_words(string word)
        {
            //string zvezda = "*";
            string temp = "";
            //temp += zvezda;
            temp += word;
            temp += " True";
            return temp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = $"{Name_of_questions.Text}";
            string path1 = $"{Name_of_answer.Text}";

            if (path != "" || path1 != "")
            {
                if (Test_questions.Text != "" || A.Text != "" || B.Text != "" || C.Text != "")
                {
                    string text1 = "";

                    if (R_A.IsChecked == true)
                    {

                        text1 += Right_words(A.Text) + "*";
                        text1 += B.Text + "*";
                        text1 += C.Text;

                    }
                    if (R_B.IsChecked == true)
                    {
                        text1 += A.Text + "*";
                        text1 += Right_words(B.Text) + "*";
                        text1 += C.Text;
                    }
                    if (R_C.IsChecked == true)
                    {
                        text1 += A.Text + "*";
                        text1 += B.Text + "*";
                        text1 += Right_words(C.Text);

                    }



                    string text = Test_questions.Text;
                    List<string> g = new List<string>();
                    g.Add(text);

                    string ПУТЬ = $"D:\\Электронно-обучающая программа\\Электронно-обучающая программа\\bin\\Debug\\{Name_of_questions.Text}.txt";
                    string ПУТЬ1 = $"D:\\Электронно-обучающая программа\\Электронно-обучающая программа\\bin\\Debug\\{Name_of_answer.Text}.txt";
                    // запись в файл
                    if (File.Exists($"{ПУТЬ}"))
                    {
                        using (FileStream fstream = new FileStream($"{ПУТЬ}", FileMode.Append))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text + "\n");
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }

                    }
                    else
                    {
                        
                        using (FileStream fstream = new FileStream($"{ПУТЬ}", FileMode.OpenOrCreate))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text + "\n");
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }

                    }

                    if (File.Exists($"{ПУТЬ1}"))
                    {
                        using (FileStream fstream = new FileStream($"{ПУТЬ1}", FileMode.Append))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text1 + "\n");
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    else
                    {
                        using (FileStream fstream = new FileStream($"{ПУТЬ1}", FileMode.OpenOrCreate))
                        {
                            // преобразуем строку в байты
                            byte[] array = System.Text.Encoding.Default.GetBytes(text1 + "\n");
                            // запись массива байтов в файл
                            fstream.Write(array, 0, array.Length);

                        }
                    }
                    Test_questions.Clear();
                    A.Clear();
                    B.Clear();
                    C.Clear();
                }
                else
                {
                    MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Нет имени файла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void R_A_Checked(object sender, RoutedEventArgs e)
        {
            R_A.IsChecked = true;
            R_B.IsChecked = false;
            R_C.IsChecked = false;
            
           
        }

        private void R_B_Checked(object sender, RoutedEventArgs e)
        {
            R_A.IsChecked = false;
            R_B.IsChecked = true;
            R_C.IsChecked = false;
        }

        private void R_C_Checked(object sender, RoutedEventArgs e)
        {
            R_A.IsChecked = false;
            R_B.IsChecked = false;
            R_C.IsChecked = true;
        }
    }
}
