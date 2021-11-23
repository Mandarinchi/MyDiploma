using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LearningWords.Lessons;
using static LearningWords.Password_for_OKR;

namespace LearningWords
{
    /// <summary>
    ///  <ScrollViewer //VerticalScrollBarVisibility ="Visible" Height="410" Width="104" Name="scroll">
    //   
    // <Button Content = "Тема 1" HorizontalAlignment="Left" VerticalAlignment="Top" Width="82" Click="Button_Click_2"/>
    //  </ScrollViewer>
    /// </summary>
    public partial class MainWindow : Window
    {
        // public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public static string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
        public static DataTable dtbase = Select("SELECT * FROM [dbo].[Rules]");
        public static DataTable dtbase1 = Select("SELECT * FROM [dbo].[User]");
        //public static DataTable dtbase2 = Select("SELECT * FROM [dbo].[Student_profile]");
        public Button[] btns = new Button[dtbase.Rows.Count];
        public  MainWindow()
        {
          //  string text = "Rules.txt";
            InitializeComponent();
            Sername.Visibility = Visibility.Hidden;
            Point.Visibility = Visibility.Hidden;
            amount_wrong_words.Visibility = Visibility.Hidden;
            amount_theme.Visibility = Visibility.Hidden;
            arrow_Right.Visibility = Visibility.Visible;
            Scroll_Bar.Width = 32;
            arrow_left.Visibility = Visibility.Hidden;
            arrow_Right.Visibility = Visibility.Visible;
            amount_right_words.Visibility = Visibility.Hidden;
            Last_complete_theme.Visibility = Visibility.Hidden;
             DataTable dtbase2 = Select("SELECT * FROM [dbo].[Student_profile]");
            
            // int VREMENAYA_PEREMENAY = Studentt.ID;
            for (int i = 0; i < dtbase1.Rows.Count; i++)
            {
                if(i == (Studentt.ID - 1))
                {
                    Sername.Content = Studentt.FIO;//dtbase1.Rows[i][1].ToString();
                }
            }
            for (int i = 0; i < dtbase2.Rows.Count; i++)
            {
                if(i == (Studentt.ID - 1))
                {
                    Point.Content += dtbase2.Rows[i][4].ToString();
                    amount_wrong_words.Content += dtbase2.Rows[i][10].ToString();
                    string a = "";
                    a+= dtbase2.Rows[i][11].ToString();
                    string NewString = a.TrimEnd(',');
                    amount_theme.Content += NewString;
                    amount_right_words.Content += dtbase2.Rows[i][9].ToString();
                    Last_complete_theme.Content += dtbase2.Rows[i][3].ToString();
                }
            }
            
            
            for (int i = 0; i < btns.Length; i++)
            {
                var btn = new Button
                {
                    Content = "Тема " + (i+1).ToString(),
                };
                btns[i] = btn;
                btn.Width = 82;
                List.Items.Add(btn);
                btn.Click += ClickHandler1;
            }
            var btn_OKR = new Button
            {
                Content = "ОКР".ToString(),
            };
            List.Items.Add(btn_OKR);
            btn_OKR.Width = 82;
            btn_OKR.Click += ClickHandler1_OKR;


        }
       
       public static int sas = 0;
        private void ClickHandler1(object sender, RoutedEventArgs e)
        {
             DataTable dtbase1 = Select("SELECT * FROM [dbo].[Rules]");
            
            for (int i = 0; i < btns.Length; i++)
            {
                if(btns[i].Content == ((Button)sender).Content)
                {

                    MessageBox.Show($"Это Глава{btns[i++].Content}");
                    sas = i++;
                }

            }
            Lesson_1 theme_1 = new Lesson_1();
            this.Close();
            theme_1.ShowDialog();
        }
        
        private void ClickHandler1_OKR(object sender, RoutedEventArgs e)
        {
            
            Password_for_OKR s = new Password_for_OKR();
           
            s.ShowDialog();
            bool a = Pass.Passw;
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Prepod]");
            if(a == true)
            {
                Variant q = new Variant();
                q.ShowDialog();
                Control_Work finish = new Control_Work();
                this.Close();
                finish.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public static DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("");// создаём таблицу в приложении                                                                  // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(g);
            sqlConnection.Open();// открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();// создаём команду
            sqlCommand.CommandText = selectSQL;// присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);// создаём обработчик
            sqlDataAdapter.Fill(dataTable);// возращаем таблицу с результатом
            return dataTable;
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
     
            
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Lesson_1 theme_1 = new Lesson_1();
            this.Hide();
            theme_1.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Sername.Visibility = Visibility.Hidden;
            Point.Visibility = Visibility.Hidden;
            amount_wrong_words.Visibility = Visibility.Hidden;
            amount_theme.Visibility = Visibility.Hidden;
            arrow_Right.Visibility = Visibility.Visible;
            Scroll_Bar.Width = 32;
            arrow_left.Visibility = Visibility.Hidden;
            arrow_Right.Visibility = Visibility.Visible;
            amount_right_words.Visibility = Visibility.Hidden;
            Last_complete_theme.Visibility = Visibility.Hidden;

        }

        private void Button_Click_right(object sender, RoutedEventArgs e)
        {
            Sername.Visibility = Visibility.Visible;
            Point.Visibility = Visibility.Visible;
            amount_wrong_words.Visibility = Visibility.Visible;
            amount_theme.Visibility = Visibility.Visible;
            arrow_Right.Visibility = Visibility.Hidden;
            Scroll_Bar.Width = 287;
            arrow_left.Visibility = Visibility.Visible;
            arrow_Right.Visibility = Visibility.Hidden;
            amount_right_words.Visibility = Visibility.Visible;
            Last_complete_theme.Visibility = Visibility.Visible;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Registration s = new Registration();
            this.Close();
            s.ShowDialog();
        }
    }
}
