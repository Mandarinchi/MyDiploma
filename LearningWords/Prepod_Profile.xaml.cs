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
    /// Interaction logic for Prepod_Profile.xaml
    /// </summary>
    public partial class Prepod_Profile : Window
    {
        static string Fio = Prepodavatel.FIO;
        static int numb_ofrule;
        public Prepod_Profile()
        {
            InitializeComponent();
            Prepod_profile.Width = 268;
            Accept.Margin = new Thickness(137, 210, 0, 0);
            DataTable dtbase = Select("SELECT * FROM [dbo].[Groups]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                Group.Items.Add(dtbase.Rows[i][1].ToString());
            }
            
            Sername.Content = Prepodavatel.FIO;

        }
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //static public string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
       // static public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Электронно-обучающая программа\Электронно-обучающая программа\Data\Data.mdf;Integrated Security=True";
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
            if (Check.IsChecked == true)
            {                
                Prepod_profile.Width = 800;
                Accept.Margin = new Thickness(499, 211, 0, 0);
                
            }

        }
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Check.IsChecked == false)
            {
                Prepod_profile.Width = 268;
                Accept.Margin = new Thickness(137, 210, 0, 0);
                            
            }
        }
        public string Dialog_link()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                 filename = dlg.FileName;
            }
            return filename;
        }
        static public int bufer = 0;
        private void Theme_button_Click(object sender, RoutedEventArgs e)
        {
            //Dialog_link();
            bool check;
            if (Check.IsChecked == false)
            {
                check = false;
                Name_of_theme wind = new Name_of_theme();
                wind.ShowDialog();
                Read(Dialog_link(), check);
            }
            else
            {
                check = true;
                if (Updateter.Text == "")
                {
                    MessageBox.Show("Укажите номер темы", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    DataTable dtbase1 = Select("SELECT * FROM [dbo].[Rules]");
                    for (int i = 0; i < dtbase1.Rows.Count; i++)
                    {
                        if (Updateter.Text == dtbase1.Rows[i][4].ToString())
                        {
                            bufer = Convert.ToInt32(dtbase1.Rows[i][0]);
                        }
                    }
                    Read(Dialog_link(), check);

                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Read_string_and_paste(Dialog_link());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Updateter.Text != "")
            {
                numb_ofrule = Convert.ToInt32(Updateter.Text);
            }
            Read_string_and_paste_question( Dialog_link());
            //Read_string_and_paste_answers( Dialog_link());
        }
        static public  void Read_string_and_paste(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.ASCII))
                {
                    string line;
                    bool dalee = false;
                    int id = 0;
                    int numb = numb_ofrule;
                    while ((line =  sr.ReadLine()) != null)
                    {
                        DataTable dtbase1 = Select("SELECT * FROM [dbo].[Table]");
                        SqlConnection con = new SqlConnection(g);
                        con.Open();
                       // MessageBox.Show(line); // В базу
                        for (int i = 0; i < dtbase1.Rows.Count; i++)
                        {
                            if ((dtbase1.Rows[i][1].ToString() == line))
                            {
                                dalee = true;
                                break;

                            }


                        }
                        id = dtbase1.Rows.Count;
                        for (int i = 0; i < 1; i++)
                        {

                            if (dalee == false)
                            {
                                if (con.State == System.Data.ConnectionState.Open)
                                {
                                    string w2 = "insert into [dbo].[Table](Words,Translate,ID_of_theme,ID_of_words)values('" + line + "','" + "NULL" + "','" + numb + "','" + id + "')";//добавить тему сюда(вместо единицы, из текстого поля куда должен вписывать препод)
                                    SqlCommand cmd2 = new SqlCommand(w2, con);
                                    cmd2.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            dalee = false;
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего ввыбрать нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                //throw;
            }

            
        }
         public  void Read_string_and_paste(string path,bool rus)
        {
            // int j = 0;

            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    int jj = 0;
                    int gg = 0;
                    string line;
                    bool dalee = false;
                    while ((line =  sr.ReadLine()) != null)
                    {
                        DataTable dtbase1 = Select("SELECT * FROM [dbo].[Table]");
                        SqlConnection con = new SqlConnection(g);
                        con.Open();
                        //MessageBox.Show(line); // В базу
                        for (int i = 0; i < dtbase1.Rows.Count; i++)
                        {
                            if ((dtbase1.Rows[i][2].ToString() == "NULL"))
                            {
                                dalee = true;
                                jj = i;
                                gg = jj;
                                gg++;
                                break;

                            }

                        }
                        int numb = numb_ofrule;
                        if (dalee == true)
                        {
                            if (Updateter.Text == "")
                            {
                                for (int i = jj; i < gg; i++)
                                {


                                    string das = "update [dbo].[Table] set Translate='" + line.ToString() + "'where ID_of_words= '" + jj + "'";
                                    SqlCommand cmd = new SqlCommand(das, con);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    //con.Open();
                                }
                            }
                            else
                            {
                                string das = "update [dbo].[Table] set Translate='" + line.ToString() + "'where ID_of_words= '" + numb + "'";
                                SqlCommand cmd = new SqlCommand(das, con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            dalee = false;

                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ничего ввыбрать нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                //throw;
            }
            
            //con.Close();
        }
        static public  void Read_string_and_paste_question(string path)
        {
            //int j = 0;
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
            SqlConnection con = new SqlConnection(g);
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    bool proverka_ = false;
                    string line;
                    bool dalee = false;
                    int id = 0;

                   
                    int numb = numb_ofrule;
                    while ((line =  sr.ReadLine()) != null)
                    {
                        
                        //SqlConnection con = new SqlConnection(g);
                        con.Open();
                        if (proverka_ == false)
                        {
                            id = dtbase1.Rows.Count;
                            proverka_ = true;
                        }
                        
                        
                        // MessageBox.Show(line); // В базу
                        for (int i = 0; i < dtbase1.Rows.Count; i++)
                        {
                            if ((dtbase1.Rows[i][1].ToString() == line))
                            {
                                dalee = true;
                                break;

                            }


                        }

                        for (int i = 0; i < 1; i++)
                        {

                            if (dalee == false)
                            {
                                if (con.State == System.Data.ConnectionState.Open)
                                {

                                    string w2 = "insert into [dbo].[Questions_and_Answers](Questions,Answers,id_of_rules,ID_of_Questions_and_Answers) values('" + line + "','" + "NULL" + "','" + numb + "','" + id + "')";//добавить тему сюда(вместо единицы, из текстого поля куда должен вписывать препод)
                                    id++;
                                    SqlCommand cmd2 = new SqlCommand(w2, con);
                                    cmd2.ExecuteNonQuery();
                                    con.Close();
                                    //dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                                    
                                }
                            }
                            dalee = false;
                        }

                        //dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                    }
                    //dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ничего ввыбрать нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
           
        }
        static public  void Read_string_and_paste_answers(string path)
        {
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
            SqlConnection con = new SqlConnection(g);
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    int jj = 0;
                    int gg = 0;
                    string line;
                    bool dalee = false;
                    while ((line =  sr.ReadLine()) != null)
                    {
                        dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                        con = new SqlConnection(g);
                        con.Open();
                        //MessageBox.Show(line); // В базу
                        for (int i = 0; i < dtbase1.Rows.Count; i++)
                        {
                            if ((dtbase1.Rows[i][2].ToString() == "NULL"))
                            {
                                dalee = true;
                                jj = i;
                                gg = jj;
                                gg++;
                                break;

                            }

                        }
                        if (dalee == true)
                        {
                            for (int i = jj; i < gg; i++)
                            {


                                string das = "update [dbo].[Questions_and_Answers] set Answers='" + line.ToString() + "'where ID_of_Questions_and_Answers= '" + jj + "'";
                                SqlCommand cmd = new SqlCommand(das, con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                               // dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                            }
                            dalee = false;

                        }
                    }
                    //dtbase1 = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ничего ввыбрать нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            
        }
        
        static public  void Read(string path,bool check)
        {
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[User]");
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Prepod]");
            DataTable dtbase2 = Select("SELECT * FROM [dbo].[Rules]");
            string nubm_of_theme = "";
            string name_of_theme = Name_of_theme.reference;
            string theme = "";
            int id = 0;
            if (check == false)
            {
                
                for (int i = 0; i < dtbase1.Rows.Count; i++)
                {
                    if (dtbase1.Rows[i][3].ToString() == Registration.FIO_of_prepod)
                    {
                        id = Convert.ToInt32(dtbase1.Rows[i][0]);
                    }
                }               
                
                if (dtbase2.Rows.Count == 0)
                {
                    nubm_of_theme = "1";
                }
                else
                {
                    nubm_of_theme = Convert.ToString(Convert.ToInt32(dtbase2.Rows.Count)+1);
                }
                for (int i = 0; i < dtbase1.Rows.Count; i++)
                {
                    if (dtbase1.Rows[i][1].ToString() == Fio)
                    {
                        id = Convert.ToInt32(dtbase1.Rows[i][0]);
                    }
                }
                try
                {

                    using (StreamReader sr = new StreamReader(path))
                    {
                        MessageBox.Show($"{theme =  sr.ReadToEnd()}");         
                    }
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        string w2 = "insert into [dbo].[Rules](Rules,id_of_prepod_rules,string_format_of_rules_number,string_format_of_rules_name)values('" + theme + "','" + id + "','" + nubm_of_theme + "','" + name_of_theme + "')";
                        SqlCommand cmd2 = new SqlCommand(w2, con);
                        cmd2.ExecuteNonQuery();
                        numb_ofrule = Convert.ToInt32(nubm_of_theme);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    MessageBox.Show($"{theme =  sr.ReadToEnd()}");
                }
                using (var conq = new SqlConnection(g))
                {
                    string das = "update Rules set Rules='" + theme + "'where Id= '" + bufer + "'";
                    SqlCommand cmd = new SqlCommand(das, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        private void Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student.Items.Clear();
            DataTable dtbase = Select("SELECT * FROM [dbo].[User]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                if (Group.SelectedItem.ToString() == dtbase.Rows[i][4].ToString())
                {
                    Student.Items.Add(dtbase.Rows[i][1].ToString());
                }
            }
        }

        private void Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Student.Items.Clear();
            DataTable dtbase2 = Select("SELECT * FROM [dbo].[Student_profile]");
            DataTable dtbase = Select("SELECT * FROM [dbo].[User]");
            if (Student.SelectedItem != null)
            {
                Sername_Copy.Content = Student.SelectedItem.ToString();
            }
            else
            {
                Sername_Copy.Content = "";
                MessageBox.Show("Студентов в этой группе нет", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

           


                Point.Content = "Баллы:";
                amount_wrong_words.Content = "Кол-во неправильных слов:";
                amount_theme.Content = "Кол-во пройденных тем:";
                amount_right_words.Content = "Кол-во правильных слов:";
                Last_complete_theme.Content = "Последняя пройденная тема:";
                for (int i = 0; i < dtbase2.Rows.Count; i++)
                {
                    if (Group.SelectedItem.ToString() == dtbase2.Rows[i][2].ToString())
                    {

                        for (int j = 0; j < 1; j++)
                        {
                        try
                        {
                            if (Student.SelectedItem != null)
                            {
                                if (Student.SelectedItem.ToString() == dtbase.Rows[i][1].ToString())
                                {
                                    Point.Content += dtbase2.Rows[i][4].ToString();
                                    amount_wrong_words.Content += dtbase2.Rows[i][10].ToString();
                                    string a = "";
                                    a += dtbase2.Rows[i][11].ToString();
                                    string NewString = a.TrimEnd(',');
                                    amount_theme.Content += NewString;
                                    amount_right_words.Content += dtbase2.Rows[i][9].ToString();
                                    Last_complete_theme.Content += dtbase2.Rows[i][3].ToString();
                                }
                            }
                           
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("АА");
                            throw;
                        }
                    }
                    }
                }
            
            

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            
            if ( Check.IsChecked == true)
            {
              
                
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Theme_window s = new Theme_window();
            s.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Create_words_window s = new Create_words_window();
            s.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Test_window s = new Test_window();
            s.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            bool rus = true;
            Read_string_and_paste(Dialog_link(), rus);
        }
        public string Dialog_link1()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.FileName = "Document"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            //dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dlg.Title;
            }
            return filename;
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(g);
            con.Open();
            string das = "update Adress set Adress='" + Dialog_link1() + "'where Id= '" + 0 + "'";
            SqlCommand cmd = new SqlCommand(das, con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Read_string_and_paste_answers(Dialog_link());
        }

        private void Back_to_menu(object sender, RoutedEventArgs e)
        {
            Registration s = new Registration();
            this.Close();
            s.ShowDialog();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            OKR_Creater s = new OKR_Creater();
            s.ShowDialog();
        }
        static string name_of_fi = "";
        static public  void Read_okr(string path)
        {
            bool buler = false;
            string name_of_file = path;
            name_of_file = System.IO.Path.GetFileName(name_of_file);
            name_of_file = name_of_file.Replace(".txt", "");
            SqlConnection con = new SqlConnection(g);
            con.Open();
            DataTable dtbase = Select("SELECT * FROM [dbo].[OKR]");
            //DataTable dtbase12 = Select("SELECT COUNT(*) FROM [dbo].[OKR] WHERE table_catalog = 'database_name' — the database AND table_name = 'table_name'");
            int f = 0;
            string theme = "";
            try
            {
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                    if (dtbase.Rows[i][2].ToString() == "")
                    {
                        //  = Convert.ToInt32(dtbase.Rows[i][2]);
                        f = i;
                        buler = true;
                        break;

                    }
                    else
                    {
                        f = dtbase.Rows.Count;
                        buler = false;
                    }
                }
                f++;
                using (StreamReader sr = new StreamReader(path))
                {
                    MessageBox.Show($"{theme =  sr.ReadToEnd()}");
                }
                if (buler == true)
                {
                    using (var conq = new SqlConnection(g))
                    {
                        string das = "update OKR set Sentences_for_second_okr='" + theme + "'where Id= '" + f + "'";
                        SqlCommand cmd = new SqlCommand(das, con);
                        string dass = "update OKR set Sentences_for_second_okr_Name_of_theme='" + name_of_file + "'where Id= '" + f + "'";
                        SqlCommand cmdd = new SqlCommand(dass, con);
                        cmd.ExecuteNonQuery();
                        cmdd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    string w2 = "insert into [dbo].[OKR](Sentences,Sentences_for_second_okr,Sentences_for_second_okr_questions,Sentences_for_second_okr_answer,Sentences_for_second_okr_Name_of_theme_for_questions,Sentences_for_second_okr_Name_of_theme)values('" + null + "','" + theme + "','" + null + "','" + null + "','" + null + "','" + name_of_file + "')";
                    SqlCommand cmd2 = new SqlCommand(w2, con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Создание","ЫЫЫ",MessageBoxButton.OK);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            name_of_fi = name_of_file;


        }
        static public  void Read_string_and_paste_OKR_zad2(string path,string file)
        {
            List<string> list1_vopros = new List<string>();
            List<string> list_otvet = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.ASCII))
                {
                    bool buler = false;
                    int jj = 0;
                    int gg = 0;
                    string line;
                    bool dalee = false;
                    int f = 0;
                    string theme = "";
                    DataTable dtbase = Select("SELECT * FROM [dbo].[OKR]");
                    SqlConnection con = new SqlConnection(g);
                    con.Open();
                    while ((line =  sr.ReadLine()) != null)
                    {

                        // MessageBox.Show(line); // В базу
                        string[] words = line.Split(new char[] { '*' });

                        foreach (string s in words)
                        {
                            if (s == "True" || s == "False")
                            {
                                list_otvet.Add(s);
                            }
                            else
                            {
                                list1_vopros.Add(s);
                            }

                        }
                    }

                    try
                    {
                        for (int i = 0; i < dtbase.Rows.Count; i++)
                        {
                            if (dtbase.Rows[i][3].ToString() == "")
                            {
                                buler = true;
                                f = i;
                                break;
                            }
                            else
                            {
                                buler = false;
                                f = dtbase.Rows.Count;
                            }
                        }
                        f++;                        
                        using (var conq = new SqlConnection(g))
                        {

                            for (int i = 0; i < list1_vopros.Count; i++)
                            {
                                
                                if (con.State == System.Data.ConnectionState.Open)
                                {

                                }
                                else
                                {
                                    
                                    con.Open();
                                    for (int j = 0; j < dtbase.Rows.Count; j++)
                                    {
                                        
                                        if (dtbase.Rows[j][3].ToString() == "")
                                        {
                                            buler = true;
                                            
                                            break;
                                        }
                                        else
                                        {
                                            buler = false;

                                        }

                                    }
                                    
                                }
                                
                                if (buler == true)
                                {
                                    string das = "update OKR set Sentences_for_second_okr_questions='" + list1_vopros[i] + "'where Id= '" + f + "'";
                                    SqlCommand cmd = new SqlCommand(das, con);
                                    string dass = "update OKR set Sentences_for_second_okr_answer='" + list_otvet[i] + "'where Id= '" + f + "'";
                                    SqlCommand cmdd = new SqlCommand(dass, con);
                                    string dasss = "update OKR set Sentences_for_second_okr_Name_of_theme_for_questions='" + file + "'where Id= '" + f + "'";
                                    SqlCommand cmddd = new SqlCommand(dasss, con);
                                    cmd.ExecuteNonQuery();
                                    cmdd.ExecuteNonQuery();
                                    cmddd.ExecuteNonQuery();
                                    con.Close();
                                    f++;
                                   // MessageBox.Show("Обновление", "ААА", MessageBoxButton.OK);

                                }
                                else
                                {
                                    
                                    string w2 = "insert into [dbo].[OKR](Sentences,Sentences_for_second_okr,Sentences_for_second_okr_questions,Sentences_for_second_okr_answer,Sentences_for_second_okr_Name_of_theme_for_questions,Sentences_for_second_okr_Name_of_theme)values('" + null + "','" + null + "','" + list1_vopros[i] + "','" + Convert.ToBoolean(list_otvet[i]) + "','" + file + "','" + null + "')";
                                    SqlCommand cmd2 = new SqlCommand(w2, con);
                                    cmd2.ExecuteNonQuery();   
                                    con.Close();
                                    f++;
                                    //MessageBox.Show("Создание", "BBB", MessageBoxButton.OK);
                                }
                                dtbase = Select("SELECT * FROM [dbo].[OKR]");
                            }


                        }
                    }
                    catch (Exception e)
                    {
                       // throw;
                        MessageBox.Show(e.Message);
                    }



                    foreach (string s in list1_vopros)
                    {

                        MessageBox.Show(s);
                    }
                    foreach (string s in list_otvet)
                    {

                        MessageBox.Show(s);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего ввыбрать нельзя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }


        static public  void Read_string_and_paste_OKR_zad3(string path)
        {
            try
            { 
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<string> list_sentenses = new List<string>();
                string line;
                bool buler = false;
                int f = 0;
                DataTable dtbase = Select("SELECT * FROM [dbo].[OKR]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                while ((line =  sr.ReadLine()) != null)
                {
                    list_sentenses.Add(line);
                    
                }

                
              
                    for (int i = 0; i < dtbase.Rows.Count; i++)
                    {
                        if (dtbase.Rows[i][1].ToString() == "")
                        {
                            buler = true;
                            f = i;
                            break;
                        }
                        else
                        {
                            buler = false;
                            f = dtbase.Rows.Count;
                        }
                    }
                    f++;
                    using (var conq = new SqlConnection(g))
                    {

                        for (int i = 0; i < list_sentenses.Count; i++)
                        {

                            if (con.State == System.Data.ConnectionState.Open)
                            {

                            }
                            else
                            {

                                con.Open();
                                for (int j = 0; j < dtbase.Rows.Count; j++)
                                {

                                    if (dtbase.Rows[j][1].ToString() == "")
                                    {
                                        buler = true;

                                        break;
                                    }
                                    else
                                    {
                                        buler = false;

                                    }

                                }

                            }

                            if (buler == true)
                            {
                                string das = "update OKR set Sentences='" + list_sentenses[i] + "'where Id= '" + f + "'";
                                SqlCommand cmd = new SqlCommand(das, con);                               
                                cmd.ExecuteNonQuery();                               
                                con.Close();
                                f++;
                                //MessageBox.Show("Обновление", "ААА", MessageBoxButton.OK);

                            }
                            else
                            {

                                string w2 = "insert into [dbo].[OKR](Sentences,Sentences_for_second_okr,Sentences_for_second_okr_questions,Sentences_for_second_okr_answer,Sentences_for_second_okr_Name_of_theme_for_questions,Sentences_for_second_okr_Name_of_theme)values('" + list_sentenses[i] + "','" + null + "','" + null + "','" + null + "','" + null + "','" + null + "')";
                                SqlCommand cmd2 = new SqlCommand(w2, con);
                                cmd2.ExecuteNonQuery();
                                con.Close();
                                f++;
                                //MessageBox.Show("Создание", "BBB", MessageBoxButton.OK);
                            }
                            dtbase = Select("SELECT * FROM [dbo].[OKR]");
                        }


                    }
                }
                

            }
            catch (Exception e)
            {
                // throw;
                MessageBox.Show(e.Message);
            }
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            string file = "";
            Read_okr(Dialog_link());
            file = name_of_fi;
            Read_string_and_paste_OKR_zad2(Dialog_link(), name_of_fi);

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (Password_for_okr.Password != "")
            {
                DataTable dtbase = Select("SELECT * FROM [dbo].[Prepod]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                string das = "update Prepod set Groups='" + Password_for_okr.Password + "'where Id= '" + (Prepodavatel.Id + 1) + "'";
                SqlCommand cmd = new SqlCommand(das, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Попробуйте снова", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Read_string_and_paste_OKR_zad3(Dialog_link());
        }

        private void Updateter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
