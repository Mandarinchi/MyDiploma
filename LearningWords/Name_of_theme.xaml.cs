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
    /// Interaction logic for Name_of_theme.xaml
    /// </summary>
    public partial class Name_of_theme : Window
    {
        public Name_of_theme()
        {
            InitializeComponent();
           
        }
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
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
        static public string reference = "";
        //public int Digit_in_string(string str)
        //{
        //    int digit = Convert.ToInt32(str.Where(x => Char.IsDigit(x)).ToArray());
        //    return digit;
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            DataTable dtbase = Select("SELECT * FROM [dbo].[Rules]");
            Prepod_Profile pr1 = new Prepod_Profile();
            if (pr1.Check.IsChecked == false)
            {
                reference = Name_of_theme_txbox.Text;
               
               // Themes.Theme = Digit_in_string(reference);
            }
            else
            {
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                    reference = Name_of_theme_txbox.Text;
                  //  Themes.Theme = Digit_in_string(reference);
                }

                //Передать на форму Препод 
            }
            this.Close();
        }
    }
}
