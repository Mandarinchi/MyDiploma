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
    /// Interaction logic for Password_for_OKR.xaml
    /// </summary>
    public partial class Password_for_OKR : Window
    {
        public Password_for_OKR()
        {
            InitializeComponent();
        }
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static public DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
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
        //static string Peredacha_pass = "";
        public static class Pass
        {
            static bool _pass;
                       
            public static bool Passw
            {
                get { return _pass; }
                set { _pass = value; }
            }
        }
        public static  bool daleee = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtbase = Select("SELECT * FROM [dbo].[Prepod]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                if (Passworder.Password == dtbase.Rows[i][3].ToString())
                {

                    //Peredacha_pass = Passworder.Password;
                    Pass.Passw = true;
                    MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);                    
                    this.Close();                    
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
}
