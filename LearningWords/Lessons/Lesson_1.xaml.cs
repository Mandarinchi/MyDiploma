using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace LearningWords.Lessons
{
    /// <summary>
    /// Interaction logic for Lesson_1.xaml
    /// </summary>
    public partial class Lesson_1 : Window
    {
        //public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
       // public  string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<string> list = new List<string>();
        public List<string> list1 = new List<string>();
        public List<string> list_Questions = new List<string>();
        public List<string> list_Answers = new List<string>();
        public Random ra = new Random();
        public string Firsts;
        public string Second;
        public string Third;
        public bool Odnorazovaya_peremennay = false;
        public class Com_points
        {
             double point;
            int  CCont = 0;
            public  double Points
            {
                get { return point; }
                set { point = value; }
            } 
            public  int CConts
            {
                get { return CCont; }
                set { CCont = value; }
            }
        }
        Com_points Poi = new Com_points();
        
        public Lesson_1()
        {
            
            InitializeComponent();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Rules]");
            int sdd = MainWindow.sas;
            sdd--;
            int decrement = sdd;
            int Increment = sdd;
            Increment++;
            Lesson.Title = "Тема " + Increment;
            Ruless.Text =  dtbase.Rows[decrement][1].ToString();
            Ruless.IsReadOnly = true;
            int sd = TabControler.SelectedIndex;
            DataTable dtbases = Select("SELECT * FROM [dbo].[Table]");
            DataTable dtbase_Questions = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
            DataTable dtbase_Wrong_words = Select("SELECT * FROM [dbo].[Student_profile]");
            Trans.Visibility = Visibility.Hidden;
            sdd++;
            Exit.Visibility = Visibility.Visible;
            Label_word_english.Visibility = Visibility.Visible;
            Label_word_russian.Visibility = Visibility.Hidden;

            Label_russian_sentences.Visibility = Visibility.Hidden;
            Label_english_sentences.Visibility = Visibility.Visible;


            try
            {

                for (int i = 0; i < dtbases.Rows.Count; i++)
                {
                    if (sdd == Convert.ToInt32(dtbases.Rows[i][3]))
                    {
                        list.Add(dtbases.Rows[i][1].ToString());
                    }

                }
                DateTime ss = new DateTime();
                ss = DateTime.Now;

                string now = ss.ToShortDateString();
                if (now == Convert.ToString(Convert.ToDateTime(dtbase_Wrong_words.Rows[(Studentt.ID - 1)][7]).ToShortDateString()))
                {
                    string text = Convert.ToString(dtbase_Wrong_words.Rows[(Studentt.ID - 1)][6]);

                    string[] words = text.Split(new char[] { ',' });

                    foreach (string s in words)
                    {
                        list.Add(s);
                    }
                }
                if (now == Convert.ToString(Convert.ToDateTime(dtbase_Wrong_words.Rows[(Studentt.ID - 1)][8]).ToShortDateString()))
                {
                    string text = Convert.ToString(dtbase_Wrong_words.Rows[(Studentt.ID - 1)][5]);

                    string[] words = text.Split(new char[] { ',' });

                    foreach (string s in words)
                    {
                        list.Add(s);
                    }

                }

                j = method_return_random(j, list);
                Rules.Text = list[j];

                for (int i = 0; i < dtbase_Questions.Rows.Count; i++)
                {
                    try
                    {
                        if (sdd == Convert.ToInt32(dtbase_Questions.Rows[i][3]))
                        {
                            list_Questions.Add(dtbase_Questions.Rows[i][1].ToString());
                            list_Answers.Add(dtbase_Questions.Rows[i][2].ToString());
                        }
                    }
                    catch (Exception)
                    {

                       // continue;
                    }
                    
                    

                }
                Poi.CConts = list_Questions.Count;

                i = method_return_random(i, list_Questions);
                Questions.Text = list_Questions[i];
                InitiallizeButtons(out Firsts, out Second, out Third);
                First_word.Content = Firsts;
                Second_word.Content = Second;
                Third_word.Content = Third;
                Odnorazovaya_peremennay = true;
                Proverka_int = i;
            }
            catch (Exception)
            {
                MessageBox.Show("Не все задания загружены, обратитесь к преподавателю", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            


        }
       // static int COUUNT;
        static bool Proverka_bool = false ;
        static int Proverka_int ;
        public DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
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
        public int j = 0;
        public int i = 0;
        public int index_of_true = 0;
        public int method_return_random(int result, List<string> count)
        {
            result = ra.Next(0, count.Count - 1);
            return result;
        }
        public void InitiallizeButtons(out string First, out string Second, out string Third)
        {
            string answer = "";
            answer = list_Answers[i]; 
            string[] words = answer.Split('*');
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i].Contains("True"))
                {
                    index_of_true = i;
                    words[i] = words[i].Replace("True", "");
                }
            }
            First = words[0];
            Second = words[1];
            Third = words[2];
            
        }
        public string string_plus = "";
        public string string_minus = "";
        public int count_right = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Trans.Visibility = Visibility.Hidden;
            DataTable dtbases = Select("SELECT * FROM [dbo].[Table]");
            DataTable dtbases1 = Select("SELECT * FROM [dbo].[Student_profile]");
            SqlConnection con = new SqlConnection(g);
            //con.Open();
            if (list.Count == 0)
            {
                MessageBox.Show("Все слова выучены","Сообщение",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {

                if (list.Count != 0)
                {
                    j = method_return_random(j, list);
                    Rules.Text = list[j];
                    string_plus += list[j] + ",";

                   
                    con.Open();

                    
                    count_right++;
                    string das = "update Student_profile set spisok_words_which_right='" + string_plus + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cmd = new SqlCommand(das, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    list.RemoveAt(j);
                }

            }
            if (list1.Count != 0 && list.Count == 0)
            {
               
                MessageBox.Show("Добавлен в Лист 1 для повтора");
                foreach (var item in list1)
                {
                    string_minus += item + ",";
                    list.Add(item);
                }
                int count_wrong = list1.Count;
                con.Open();
                if (count_right == 0)
                {
                    string da = "update Student_profile set setter='" + 0 + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cm = new SqlCommand(da, con);
                    cm.ExecuteNonQuery();
                }
                else
                {
                    int count_of_set = 0;
                    count_of_set = Convert.ToInt32(dtbases1.Rows[(Studentt.ID - 1)][12]);
                    count_of_set++;

                    DateTime s = new DateTime();
                    s = DateTime.Now;
                    s = s.AddDays(count_of_set);
                    string setter = s.ToShortDateString();
                    string da = "update Student_profile set setter='" + count_of_set + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cm = new SqlCommand(da, con);
                    string dad = "update Student_profile set time_of_restart_Right_words ='" + setter + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cmc = new SqlCommand(dad, con);
                    cm.ExecuteNonQuery();
                    cmc.ExecuteNonQuery();
                }
                if (count_wrong != 0)
                {
                    DateTime s = new DateTime();
                    s = DateTime.Now;
                    s = s.AddDays(1);
                    string setter = s.ToShortDateString();
                    string da = "update Student_profile set time_of_restart_Wrong_words='" + setter + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cm = new SqlCommand(da, con);
                    cm.ExecuteNonQuery();
                }
                list1.Clear();
                
                string das = "update Student_profile set spisok_words_which_wrong='" + string_minus + "'where Id= '" + Studentt.ID + "'";
                SqlCommand cmd = new SqlCommand(das, con);
                string dass = "update Student_profile set count_wrong_words='" + count_wrong + "'where Id= '" + Studentt.ID + "'";
                SqlCommand cmdd = new SqlCommand(dass, con);
                string dasss = "update Student_profile set count_right_words='" + count_right + "'where Id= '" + Studentt.ID + "'";
                SqlCommand cmddd = new SqlCommand(dasss, con);
                cmd.ExecuteNonQuery();
                cmdd.ExecuteNonQuery();
                cmddd.ExecuteNonQuery();
                con.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Trans.Visibility = Visibility.Visible;
            DataTable dtbases = Select("SELECT * FROM [dbo].[Table]");
            DataTable dtbases1 = Select("SELECT * FROM [dbo].[Student_profile]");
            for (int i = 0; i < dtbases.Rows.Count; i++)
            {
                if (dtbases.Rows[i][1].ToString() == Rules.Text)
                {
                    Trans.Text = dtbases.Rows[i][2].ToString();
                }
            }
            MessageBox.Show("Добавлен в Лист 2 для повтора");
           

            list1.Add(Rules.Text);
            if (list.Contains(Rules.Text))
            {
                list.Remove(Rules.Text);
            }

        }
        public string Insert_into_backspaces(string a)
        {
            string peremennaya_for_take_symbol="";
            switch (index_of_true)
            {
                case 0:
                    {
                        peremennaya_for_take_symbol = Firsts;
                        break;
                    }
                case 1:
                    {
                        peremennaya_for_take_symbol = Second;
                        break;
                    }
                case 2:
                    {
                        peremennaya_for_take_symbol = Third;
                        break;
                    }
            }
            if(peremennaya_for_take_symbol.Contains(","))
            {
                string[] sympols = peremennaya_for_take_symbol.Split(',');
                char[] massiv = a.ToCharArray();
                int count = 0;
                for (int i = 0; i < massiv.Length; i++)
                {
                    if(massiv[i] == '_')
                    {
                        
                        count++;
                        switch (count)
                        {
                            case 1:
                                {
                                    a = a.Remove(i, 1);                                    
                                    a = a.Insert(i, sympols[0]);                             
                                    massiv = a.ToCharArray(); 
                                    break;
                                }
                            case 2:
                                {
                                    a = a.Remove(i, 1);
                                    a = a.Insert(i, sympols[1]);
                                    massiv = a.ToCharArray();
                                    break;
                                }
                        }
                    }
                }
              
            }
            else
            {
                a = a.Replace("_", peremennaya_for_take_symbol);
            }
            return a;
        }
        //static double Points = 0;
        private void First_word_Click(object sender, RoutedEventArgs e)
        {
            if(Odnorazovaya_peremennay == true)
            {
                
            }
           
            Odnorazovaya_peremennay = false;
            if (index_of_true == 0 && Poi.CConts != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                Poi.Points++;
                Complete_points.Points++;
            }
            else if(index_of_true != 0)
            {
                MessageBox.Show("Неправильный ответ","Сообщение",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                if (Complete_points.Points != 0)
                {
                    double points = 0;
                    points = Poi.Points;
                    points -= 0.2;
                    Poi.Points = points;
                   
                }
            }
            else if (Poi.CConts == 0)
            {
                MessageBox.Show("Конечная");
            }
        }

        private void Second_word_Click(object sender, RoutedEventArgs e)
        {
            if (Odnorazovaya_peremennay == true)
            {
                
            }
            
            Odnorazovaya_peremennay = false;
            if (index_of_true == 1 && Poi.CConts != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                Complete_points.Points++;
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                Poi.Points++;
            }
            else if (index_of_true != 1)
            {
                MessageBox.Show("Неправильный ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (Complete_points.Points != 0)
                {
                    double points = 0;
                    points = Poi.Points;
                    points -= 0.2;
                    Poi.Points = points;
                    
                }
            }
            else if (Poi.CConts == 0)
            {
                MessageBox.Show("Конечная");
            }
        }

        private void Third_word_Click(object sender, RoutedEventArgs e)
        {
            if (Odnorazovaya_peremennay == true)
            {
               
            }
            
            Odnorazovaya_peremennay = false;
            if (index_of_true == 2 && Poi.CConts != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                Complete_points.Points++;
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                Poi.Points++;
            }
            else if (index_of_true != 2)
            {
                MessageBox.Show("Неправильный ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (Complete_points.Points != 0)
                {
                    double points = 0;
                    points = Poi.Points;
                    points -= 0.2;
                    Poi.Points = points;
                   
                }
            }
            else if (Poi.CConts == 0)
            {
                MessageBox.Show("Конечная");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Poi.CConts != 0)
            {
                while (Proverka_bool != true)
                {
                    
                    i = method_return_random(i, list_Questions);
                    if (Proverka_int != i)
                    {
                        Proverka_bool = true;
                    }
                    else
                    {
                        Proverka_bool = false;
                    }
                }
                Questions.Text = list_Questions[i];
                InitiallizeButtons(out Firsts, out Second, out Third);
                First_word.Content = Firsts;
                Second_word.Content = Second;
                Third_word.Content = Third;
                Proverka_bool = false;
                Proverka_int = i;
                
            }
            else
            {
                int sdd = MainWindow.sas;
                DataTable dtbase_Questions = Select("SELECT * FROM [dbo].[Student_profile]");
                Exit.Visibility = Visibility.Visible;
                SqlConnection con = new SqlConnection(g);
                if (Convert.ToInt32(dtbase_Questions.Rows[(Studentt.ID - 1)][3]) != sdd)
                {
                    double po = Poi.Points;
                    po += Convert.ToDouble(dtbase_Questions.Rows[(Studentt.ID - 1)][4]);
                    con.Open();
                    string das = "update Student_profile set id_of_theme='" + sdd + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cmd = new SqlCommand(das, con);
                    string dass = "update Student_profile set points='" + po + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cmdd = new SqlCommand(dass, con);
                    string dasss = "update Student_profile set count_id_of_theme='" + $"{sdd}," + "'where Id= '" + Studentt.ID + "'";
                    SqlCommand cmddd = new SqlCommand(dasss, con);
                    cmd.ExecuteNonQuery();
                    cmdd.ExecuteNonQuery();
                    cmddd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = new MessageBoxResult();
            if (Poi.CConts != 0)
            {
                result =  MessageBox.Show("Вы уверены закончить тест, если вы закончите тест результаты не засчитаются и тема не будет сдана.", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information);
            }
            if(result == MessageBoxResult.Yes)
            {
                MainWindow s = new MainWindow();
                this.Hide();
                s.ShowDialog();
            }
            if(result == MessageBoxResult.No)
            {
              

            }
            if (Poi.CConts == 0)
            {
                MainWindow s = new MainWindow();
                this.Hide();
                s.ShowDialog();
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(Label_word_russian.Visibility == Visibility.Visible)
            {
                Label_word_english.Visibility = Visibility.Visible;
                Label_word_russian.Visibility = Visibility.Hidden;
            }
            if (Label_word_english.Visibility == Visibility.Visible)
            {
                Label_word_russian.Visibility = Visibility.Visible;
                Label_word_english.Visibility = Visibility.Hidden;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {


            Label_word_russian.Visibility = Visibility.Visible;
            Label_word_english.Visibility = Visibility.Hidden;

        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_word_english.Visibility = Visibility.Visible;
            Label_word_russian.Visibility = Visibility.Hidden;
        }

        private void Sentences_Checked(object sender, RoutedEventArgs e)
        {
            Label_russian_sentences.Visibility = Visibility.Visible;
            Label_english_sentences.Visibility = Visibility.Hidden;
        }
        private void Sentences_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_russian_sentences.Visibility = Visibility.Hidden;
            Label_english_sentences.Visibility = Visibility.Visible;
        }
    }
}
