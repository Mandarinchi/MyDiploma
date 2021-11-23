using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using System.Configuration;
using System.Diagnostics;

namespace LearningWords
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public static class Prepodavatel
    {
       static string _fio;
       static int _id;

        
        public static void Inputer(string fio)
        {
            
            _fio = fio;
            
        }
        public static string FIO
        {
            get { return _fio; }
            set { }
        }
        public static int Id
        {
            get { return _id; }
            set { }
        }
    }
    public static class Complete_points
    {
        static double point;
        public static double Points
        {
            get { return point; }
            set { }
        }
    }
    public static class Themes
    {
        static int Number_of_theme;


       
        
        public static int Theme
        {
            get { return Number_of_theme; }
            set { }
        }
    }
    public static class Studentt
    {
         static int _id;
         static string _fio;
         static string _group;
         static string _points;
       
        public static void Inputer(int id, string fio, string group)
        {
            _id = id;
            _fio = fio;
            _group = group;
        }
        public static void Inputer(int id, string fio, string group,string point)
        {
            _id = id;
            _fio = fio;
            _group = group;
            _points = point;
        }
        public static int ID
        {
            get { return _id; }
            set { }
        }
        public static string FIO
        {
            get { return _fio; }
            set { }
        }
        public static string GROUP
        {
            get { return _group; }
            set { }
        }
        public static string POINTS
        {
            get { return _points; }
            set { }
        }

    }
    public partial class Registration : Window
    {
        string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
        //public string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
        public static string FIO_of_prepod = "";
        public bool propusk_do_prepod = false;
        public bool propusk_do_student = false;
        
        public Registration()
        {
            InitializeComponent();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Groups]");
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Prepod]");
            if (dtbase.Rows.Count != 0)
            {
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                    Group.Items.Add(dtbase.Rows[i][1].ToString());
                }
            }
            else
            {
                propusk_do_student = true;
            }
            if (dtbase1.Rows.Count != 0)
            {
                for (int i = 0; i < dtbase1.Rows.Count; i++)
                {
                    FIO_Prepod.Items.Add(dtbase1.Rows[i][1].ToString());
                }
            }
            else
            {
                propusk_do_prepod = true;

            }
            if (propusk_do_prepod == false && propusk_do_student == false)
            {
                Age.Visibility = Visibility.Visible;
                Sername.Visibility = Visibility.Visible;
                AGE_label.Visibility = Visibility.Visible;
                FIO_label.Visibility = Visibility.Hidden;
                FIO_Prepod.Visibility = Visibility.Hidden;
                Fam_and_Name_label.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Hidden;
                Password_label.Visibility = Visibility.Hidden;
                Student.IsChecked = true;
            }
            else
            {
                Prepod.IsChecked = false;
                Student.IsChecked = false;
                Age.Visibility = Visibility.Hidden;
                Sername.Visibility = Visibility.Hidden;
                AGE_label.Visibility = Visibility.Hidden;
                FIO_label.Visibility = Visibility.Hidden;
                FIO_Prepod.Visibility = Visibility.Hidden;
                Fam_and_Name_label.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Hidden;
                Password_label.Visibility = Visibility.Hidden;
                Group.Visibility = Visibility.Hidden;
                Name_of_group.Visibility = Visibility.Hidden;
                login.Visibility = Visibility.Hidden;
                First_start_admin.Visibility = Visibility.Hidden;

                DataTable dtbases = Select("SELECT * FROM [dbo].[Admin]");

                if (dtbases.Rows.Count == 0)
                {
                    First_start_admin.Visibility = Visibility.Visible;
                }
                else
                {
                    Admin_label.Visibility = Visibility.Visible;
                    Password.Visibility = Visibility.Visible;
                    Password.Margin = new Thickness(357, 168, 0, 0);
                   
                }
            }
            

        }
        
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
       public static int potom_delete;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool Propusk = false;
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[User]");
           // DataTable dtbase = Select("SELECT * FROM [dbo].[Groups]");
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Prepod]");
            DataTable dtbase2 = Select("SELECT * FROM [dbo].[Student_profile]");
            bool Tru = false;
            if (Admin.IsChecked == true)
            {
                DataTable dtbases = Select("SELECT * FROM [dbo].[Admin]");

                if (dtbases.Rows.Count == 0)
                {                   
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        string w1 = "insert into [dbo].[Admin](Id,Login_admin)values('" + 1 + "','" + "Admin" + "')";
                        SqlCommand cmd1 = new SqlCommand(w1, con);
                        cmd1.ExecuteNonQuery();
                    }
                    Admin s = new Admin();
                    this.Close();
                    s.ShowDialog();
                }
                else
                {
                    for (int i = 0; i < dtbases.Rows.Count; i++)
                    {

                        if (Password.Password == dtbases.Rows[i][2].ToString())
                        {
                            MessageBox.Show("Добро пожаловать", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            Admin s = new Admin();
                            this.Close();
                            s.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }
            if (Student.IsChecked  == true && login.IsChecked == true)
            {
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                   
                    if (Age.Text == Convert.ToDateTime(dtbase.Rows[i][2].ToString()).ToShortDateString() && Sername.Text == dtbase.Rows[i][1].ToString())
                    {
                                
                        Studentt.Inputer(Convert.ToInt32(dtbase.Rows[i][0]), dtbase.Rows[i][1].ToString(), Group.SelectedItem.ToString());
                        potom_delete = Convert.ToInt32(dtbase.Rows[i][0]);
                        MessageBox.Show("Добро пожаловать", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        MainWindow a1 = new MainWindow();
                        this.Close();
                        a1.ShowDialog();
                        Tru = true;
                    }
                    
                }
                if(Tru == false)
                {
                    MessageBox.Show("Неправильный ввод", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            if (Student.IsChecked == true && login.IsChecked == false)
            if (Age.Text != "" & Sername.Text != "" & Group.Text != "")
            {
                    int id = 0;
                    Random r = new Random();
                    int rand = r.Next(10, 10000);
                    for (int i = 0; i < dtbase1.Rows.Count; i++)
                    {
                        if(dtbase1.Rows[i][3].ToString().Contains(Group.SelectedItem.ToString()))
                        {
                            id = Convert.ToInt32(dtbase1.Rows[i][0]);
                        }
                    }
                    for (int i = 0; i < dtbase.Rows.Count; i++)
                    {
                        if(Age.Text == Convert.ToDateTime(dtbase.Rows[i][2].ToString()).ToShortDateString() && Sername.Text == dtbase.Rows[i][1].ToString())
                        {
                            Propusk = true;
                            MessageBox.Show("Такое Имя есть в базе", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    if (con.State == System.Data.ConnectionState.Open && Propusk == false)
                    {
                        int DayNow = DateTime.Now.Day;
                       
                        DateTime s = new DateTime();
                        s = DateTime.Now;
                       
                        string now = s.ToShortDateString();
                        DayNow +=1;
                        DateTime g = new DateTime();
                        g = s.AddDays(1);
                        string today = g.ToShortDateString();
                        string w2 = "insert into [dbo].[Student_profile](id_of_student,Number_of_group,id_of_theme,points,spisok_words_which_wrong,spisok_words_which_right,time_of_restart_Right_words,time_of_restart_Wrong_words,count_right_words,count_wrong_words,count_id_of_theme,setter)values('" + rand + "','" + Group.SelectedItem.ToString() + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + now + "','" + today + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                        SqlCommand cmd2 = new SqlCommand(w2, con);
                        cmd2.ExecuteNonQuery();
                    }
                    DataTable dtbase4 = Select("SELECT * FROM [dbo].[Student_profile]");
                    if (dtbase4.Rows.Count != 0)
                    {
                        for (int i = 0; i < dtbase4.Rows.Count; i++)
                        {  
                            rand = Convert.ToInt32(dtbase4.Rows[i][0]);
                           
                        }
                    }
                    else
                    {
                        rand = 1;
                    }
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Open && Propusk == false)
                        {
                            string w1 = "insert into [dbo].[User](Name,Age,Id_profile,Number_of_Group)values('" + Sername.Text + "','" + Convert.ToDateTime(Age.Text) + "','" + rand + "','" + Group.SelectedItem.ToString() + "')";
                            SqlCommand cmd1 = new SqlCommand(w1, con);
                            cmd1.ExecuteNonQuery();
                        }
                        if (Propusk == false)
                        {
                            MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Вводите Дату через (.)", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        //throw;
                    }
                    
                    
                    
            }
            else if (Age.Text == "" || Sername.Text == "" || Password.Password == "" || Group.Text == "" && Prepod.IsChecked == false)
            {
                MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            if (Prepod.IsChecked == true)
            {

                for (int i = 0; i < dtbase1.Rows.Count; i++)
                {
                    if (Password.Password == dtbase1.Rows[i][2].ToString())
                    {
                        Prepodavatel.Id = Convert.ToInt32(dtbase1.Rows[i][0]);
                        Prepodavatel.Inputer(FIO_Prepod.SelectedItem.ToString()); 
                        MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Prepod_Profile s = new Prepod_Profile();
                        this.Close();
                        s.ShowDialog();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
            }
        }

        private void Prepod_Checked(object sender, RoutedEventArgs e)
        {
            if (propusk_do_prepod == false)
            {
                DataTable dtbase = Select("SELECT * FROM [dbo].[Prepod]");
                Student.IsChecked = false;
                Admin.IsChecked = false;
                Age.Visibility = Visibility.Hidden;
                Sername.Visibility = Visibility.Hidden;
                AGE_label.Visibility = Visibility.Hidden;
                FIO_label.Visibility = Visibility.Visible;
                FIO_Prepod.Visibility = Visibility.Visible;
                Fam_and_Name_label.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Visible;
                Password_label.Visibility = Visibility.Visible;
                Group.Visibility = Visibility.Hidden;
                Name_of_group.Visibility = Visibility.Hidden;
                login.Visibility = Visibility.Hidden;
                //Name_of Margin="265,168,0,0"
                //Group Margin = "357,168,0,0"
                //Margin="265,191,0,0"
                //Margin="357,195,0,0"
                FIO_label.Margin = new Thickness(265, 168, 0, 0);
                FIO_Prepod.Margin = new Thickness(357, 168, 0, 0);
                Password_label.Margin = new Thickness(265, 191, 0, 0);
                Password.Margin = new Thickness(357, 195, 0, 0);
                First_start_admin.Visibility = Visibility.Hidden;
                Admin_label.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Профилей преподавателя нет", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Student_Checked(object sender, RoutedEventArgs e)
        {
            if (propusk_do_student == false)
            {
                Prepod.IsChecked = false;
                Admin.IsChecked = false;
                Age.Visibility = Visibility.Visible;
                Sername.Visibility = Visibility.Visible;
                AGE_label.Visibility = Visibility.Visible;
                FIO_label.Visibility = Visibility.Hidden;
                FIO_Prepod.Visibility = Visibility.Hidden;
                Fam_and_Name_label.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Hidden;
                Password_label.Visibility = Visibility.Hidden;
                Group.Visibility = Visibility.Visible;
                Name_of_group.Visibility = Visibility.Visible;
                login.Visibility = Visibility.Visible;
                First_start_admin.Visibility = Visibility.Hidden;
                Admin_label.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Отсутствуют группы", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prepod_Profile s = new Prepod_Profile();
            this.Close();
            s.ShowDialog();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        } 
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {


        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Prepod.IsChecked = false;
            Student.IsChecked = false;
            Age.Visibility = Visibility.Hidden;
            Sername.Visibility = Visibility.Hidden;
            AGE_label.Visibility = Visibility.Hidden;
            FIO_label.Visibility = Visibility.Hidden;
            FIO_Prepod.Visibility = Visibility.Hidden;
            Fam_and_Name_label.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Hidden;
            Password_label.Visibility = Visibility.Hidden;
            Group.Visibility = Visibility.Hidden;
            Name_of_group.Visibility = Visibility.Hidden;
            login.Visibility = Visibility.Hidden;
            First_start_admin.Visibility = Visibility.Hidden;
            
            DataTable dtbase = Select("SELECT * FROM [dbo].[Admin]");
            
                if(dtbase.Rows.Count == 0)
                {
                    First_start_admin.Visibility = Visibility.Visible;
                }
                else
                {
                    Admin_label.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
                Password.Margin = new Thickness(357, 168, 0, 0);
                    //Margin="357,168,0,0"
                }
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Admin]");
            if (con.State == System.Data.ConnectionState.Open)
            {
                string w1 = "insert into [dbo].[Admin](Id,Login_admin)values('" + 1 + "','" + "Admin" + "')";
                SqlCommand cmd1 = new SqlCommand(w1, con);
                cmd1.ExecuteNonQuery();
            }
            Admin s = new Admin();
            this.Close();
            s.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process.Start("Help.chm");

        }
    }
}
