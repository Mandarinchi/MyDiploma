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
    /// Interaction logic for OKR_Creater.xaml
    /// </summary>
    public partial class OKR_Creater : Window
    {
        public OKR_Creater()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Prepod_Profile s = new Prepod_Profile();
            this.Close();
            s.ShowDialog();
        }
        static int count = 5;
        static int count_1 = 0;
        static string Name__of_text = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool dalee = false;
            if(_true.IsChecked == false && _false.IsChecked == false)
            {
                MessageBox.Show("Укажите ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            int _count = count;
            if (Name__of_text != Name_of_text.Text)
            {
                _count = 5;
                count = _count;
            }
            if (count > 0) {
                if (_true.IsChecked == true || _false.IsChecked == true )
                {
                    if (Questions_for_OKR.Text != "" && Task_2.Text != "") {

                        Name__of_text = Name_of_text.Text;
                        if (Name__of_text == Name_of_text.Text)
                        {
                            _count--;
                        }
                        dalee = true;


                        string path = $"{Name_of_text.Text/* + "_Text_for_OKR_task_2"*/}";
                        string path1 = $"{Name_of_text.Text + "_Questions_for_OKR_task_2"}";



                        string text1 = "";

                        if (_true.IsChecked == true)
                        {

                            text1 += $"*{_true.IsChecked}";


                        }
                        else
                        {
                            text1 += $"*{_true.IsChecked}";
                        }


                        string name_of_text = "";
                        name_of_text = Task_2.Text;
                        string text = Questions_for_OKR.Text + text1;

                        string ПУТЬ = $"D:\\Электронно-обучающая программа\\Электронно-обучающая программа\\bin\\Debug\\{path}.txt";
                        string ПУТЬ1 = $"D:\\Электронно-обучающая программа\\Электронно-обучающая программа\\bin\\Debug\\{path1}.txt";
                       
                        if (File.Exists($"{ПУТЬ}"))
                        {
                            
                        }
                        else
                        {
                            using (FileStream fstream = new FileStream($"{ПУТЬ}", FileMode.OpenOrCreate))
                            {
                                // преобразуем строку в байты
                                byte[] array = System.Text.Encoding.Default.GetBytes(name_of_text + "\n");
                                // запись массива байтов в файл
                                fstream.Write(array, 0, array.Length);

                            }
                        }
                        if (File.Exists($"{ПУТЬ1}"))
                        {
                            using (FileStream fstream = new FileStream($"{ПУТЬ1}", FileMode.Append))
                            {
                                // преобразуем строку в байты
                                byte[] array = System.Text.Encoding.Default.GetBytes(text + "\n");
                                // запись массива байтов в файл
                                fstream.Write(array, 0, array.Length);

                            }
                        }
                        else
                        {
                            using (FileStream fstream = new FileStream($"{ПУТЬ1}", FileMode.OpenOrCreate))
                            {
                                // преобразуем строку в байты
                                byte[] array = System.Text.Encoding.Default.GetBytes(text + "\n");
                                // запись массива байтов в файл
                                fstream.Write(array, 0, array.Length);

                            }
                        }

                        Questions_for_OKR.Clear();
                        _true.IsChecked = false;
                        _false.IsChecked = false;
                        counter.Content = _count;
                        count = _count;
                    }
                }
            }
            if (Questions_for_OKR.Text == "" | Task_2.Text == "" && dalee == false)
            {
                MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (count <=0)
            {
                MessageBox.Show("Больше 5 вопросов для этой темы нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        static string Name__of_text_ = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool dalee = false;
            string Str = amount_of_questions.Text.Trim();
            int Num;
            bool isNum = int.TryParse(Str, out Num);
            int _count = 0;
            
            if (isNum)
            {
                if (Name__of_text_ != Name_of_Document.Text)
                {
                    _count = Convert.ToInt32(Str);
                    count_1 = _count;
                }
                else
                {
                    _count = count_1;
                }
                if (count_1 > 0)
                {
                    if (Name_of_Document.Text != "")
                    {
                        if (Left_part.Text != "" && Right_part.Text != "")
                        {
                            Name__of_text_ = Name_of_Document.Text;
                            string path = $"{Name_of_Document.Text + "_Text_for_OKR_task_3"}";
                            string text1 = $"{Left_part.Text} | {Right_part.Text}";
                            _count--;
                            dalee = true;
                            string ПУТЬ = $"D:\\Электронно-обучающая программа\\Электронно-обучающая программа\\bin\\Debug\\{path}.txt";
                            if (File.Exists($"{ПУТЬ}"))
                            {
                                using (FileStream fstream = new FileStream($"{ПУТЬ}", FileMode.Append))
                                {
                                    // преобразуем строку в байты
                                    byte[] array = System.Text.Encoding.Default.GetBytes(text1 + "\n");
                                    // запись массива байтов в файл
                                    fstream.Write(array, 0, array.Length);

                                }
                            }
                            else
                            {
                                using (FileStream fstream = new FileStream($"{ПУТЬ}", FileMode.OpenOrCreate))
                                {
                                    // преобразуем строку в байты
                                    byte[] array = System.Text.Encoding.Default.GetBytes(text1 + "\n");
                                    // запись массива байтов в файл
                                    fstream.Write(array, 0, array.Length);

                                }
                            }
                            Left_part.Clear();
                            Right_part.Clear();
                            counter_Copy.Content = _count;
                            count_1 = _count;

                        }
                    }


                }
                if (count_1 <= 0)
                {
                    MessageBox.Show($"Больше предложений нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (Left_part.Text == "" | Right_part.Text == "" | amount_of_questions.Text == ""| Name_of_Document.Text == "" && dalee == false)
                {
                    MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {

                MessageBox.Show("В поле не цифры", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

            }


            
            
        }
    }
}
