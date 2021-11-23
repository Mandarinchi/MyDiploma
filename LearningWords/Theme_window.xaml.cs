using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Theme_window.xaml
    /// </summary>
    public partial class Theme_window : Window
    {
        public Theme_window()
        {
            InitializeComponent();
        }
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
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
            //DataTable dtbase = Select("SELECT * FROM [dbo].[Adress]");
            
            string path = "" /*= dtbase.Rows[0][1].ToString()*/;


           path = /*dtbase.Rows[0][1].ToString() +*/ Name_of_theme.reference;
            //DirectoryInfo dirInfo = new DirectoryInfo(path);
            //if (!dirInfo.Exists)
            //{
            //    dirInfo.Create();
            //}
           
            string text = Text_of_theme.Text;

            // запись в файл
            using (FileStream fstream = new FileStream($"{path}.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.UTF8.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);

               
            }
            MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Name_of_theme s = new Name_of_theme();
            s.ShowDialog();
        }
    }
}
