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

namespace LearningWords
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //public string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
        string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Admin()
        {
            InitializeComponent();
            FIO_for_change.Visibility = Visibility.Hidden;
            Text_for_change.Visibility = Visibility.Hidden;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration s = new Registration();
            this.Close();
            s.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if(Pass_admin.Password == "" || Pass_admin_repeate.Password == "")
            //{
            //    MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            if(Pass_admin.Password == Pass_admin_repeate.Password && Pass_admin.Password != "" || Pass_admin_repeate.Password != "")
            {
                DataTable dtbase = Select("SELECT * FROM [dbo].[Admin]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                string das = "update Admin set Password='" + Pass_admin.Password + "'where Id= '" + 1 + "'";
                SqlCommand cmd = new SqlCommand(das, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Поля пустые или Пароли не совпадают", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool Propusk = false;
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Groups]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                if (Group_text.Text == dtbase.Rows[i][1].ToString())
                {
                    Propusk = true;
                    MessageBox.Show("Такая группа есть в базе", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (con.State == System.Data.ConnectionState.Open && Propusk == false && Group_text.Text != "")
            {
                string w2 = "insert into [dbo].[Groups](Groups)values('" + Group_text.Text + "')";
                SqlCommand cmd2 = new SqlCommand(w2, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            if(Group_text.Text == "")
            {
                MessageBox.Show("Поле пустое", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            bool Propusk = false;
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Prepod]");
            if (Check.IsChecked == false)
            {
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                    if (Add_Prepod.Text == dtbase.Rows[i][1].ToString())
                    {
                        Propusk = true;
                        MessageBox.Show("Такой преподаватель есть в базе", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (con.State == System.Data.ConnectionState.Open && Propusk == false && Add_Prepod.Text != "" && Pass_prepod.Password != "")
                {
                    string w2 = "insert into [dbo].[Prepod](FIO,Password)values('" + Add_Prepod.Text + "','" + Pass_prepod.Password + "')";
                    SqlCommand cmd2 = new SqlCommand(w2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                int id = 0;
                bool Propuk = false;
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {

                    if (Text_for_change.Text == dtbase.Rows[i][1].ToString())
                    {

                       id = Convert.ToInt32(dtbase.Rows[i][0]);
                        //id;
                        Propuk = true;
                    }
                   

                }
                 if(Propuk == false && Text_for_change.Text != "")
                {
                    MessageBox.Show("С таким именем преподавателя нет", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (Propuk == true && Text_for_change.Text != "")
                {
                    string dass = "update Prepod set FIO='" + Add_Prepod.Text + "'where Id= '" + id + "'";
                    SqlCommand cmd1 = new SqlCommand(dass, con);                    
                    string das = "update Prepod set Password='" + Pass_prepod.Password + "'where Id= '" + id + "'";
                    SqlCommand cmd = new SqlCommand(das, con);
                    cmd1.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }

                if (Add_Prepod.Text == "" || Pass_prepod.Password == "" || Text_for_change.Text == "")
                {
                    MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (Add_Prepod.Text == "" || Pass_prepod.Password == "" )
            {
                MessageBox.Show("Поля пустые", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Label_Add_prepod.Margin = new Thickness(290, 88, 0, 0);
            Add_Prepod.Margin = new Thickness(10, 87, 0, 0);
            Label_password_prepod.Margin = new Thickness(290, 120, 0, 0);
            Pass_prepod.Margin = new Thickness(10, 121, 0, 0);
            Button_OK.Margin = new Thickness(106, 153, 0, 0);
            FIO_for_change.Visibility = Visibility.Visible;
            Text_for_change.Visibility = Visibility.Visible;
            FIO_for_change.Margin = new Thickness(290, 58, 0, 0);
            Text_for_change.Margin = new Thickness(9.6, 58, 0, 0);
            
        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_Add_prepod.Margin = new Thickness(290, 58, 0, 0);
            Add_Prepod.Margin = new Thickness(9.6, 58, 0, 0);
            Label_password_prepod.Margin = new Thickness(290, 90, 0, 0);
            Pass_prepod.Margin = new Thickness(9.6, 91, 0, 0);
            Button_OK.Margin = new Thickness(105.6, 123, 0, 0);
            FIO_for_change.Visibility = Visibility.Hidden;
            Text_for_change.Visibility = Visibility.Hidden;
           
        }
    }
}

  