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
//using Электронно_обучающая_программа.Lessons;

namespace LearningWords
{
    /// <summary>
    /// Interaction logic for Control_Work.xaml
    /// </summary>
    public class boo
    {
        public bool reshenie1 = false;
        public bool reshenie2 = false;
        public bool reshenie3 = false;
        public bool reshenie4 = false;
        public int Count_all_points_OKR = 0;
    }
    
    public partial class Control_Work : Window
    {
        boo b = new boo();

        static string[] mas_without_razdeleniy = new string[] { };
        public List<string> list_Questions = new List<string>();
        List<string> list_Answers = new List<string>();
        public Random ra = new Random();
        public string Firsts;
        public string Second;
        public string Third;
        Com_points Poi = new Com_points();
        //Lesson_1 s = new Lesson_1();
        public int index_of_true = 0;
        static bool Proverka_bool = false;
        List<bool> otvetov = new List<bool>();
        public class Com_points
        {
            double point;
            int CCont = 0;
            public double Points
            {
                get { return point; }
                set { point = value; }
            }
            public int CConts
            {
                get { return CCont; }
                set { CCont = value; }
            }
        }
        public Control_Work()
        {

            InitializeComponent();
            
            Label_russian_words.Visibility = Visibility.Hidden;
            Label_english_words.Visibility = Visibility.Visible;  

            Label_rus_zad_2.Visibility = Visibility.Hidden;
            Label_eng_zad_2.Visibility = Visibility.Visible;
            
            Label_rus_zad_3.Visibility = Visibility.Hidden;
            Label_eng_zad_3.Visibility = Visibility.Visible;
            
            Label_rus_zad_4.Visibility = Visibility.Hidden;
            Label_eng_zad_4.Visibility = Visibility.Visible;
            

            DataTable dtbase_Questions = Select("SELECT * FROM [dbo].[Questions_and_Answers]");
            DataTable dtbase = Select("SELECT * FROM [dbo].[Table]");
            DataTable dtbase_OKR = Select("SELECT * FROM [dbo].[OKR]");
            int Varik = 0;

            //Control_Work s = new Control_Work();
            //s.ShowDialog();
            List<int> list = new List<int>();
            int slovo = 0;
            Varik =  Convert.ToInt32(Variant.peredacha_varianta);
            int count_of_Random = 0;
            bool dalee = false;
            while (count_of_Random != 5)
            {
                dalee = false;
                Random ra = new Random();
                while (dalee != true)
                {
                    slovo = ra.Next(1, dtbase.Rows.Count);


                    if (Varik == 2)
                    {
                        if (slovo % Varik == 0 && list.Contains(slovo) == false)
                        {
                            list.Add(slovo);
                            dalee = true;

                            

                        }
                    }
                    if (Varik == 1)
                    {
                        if (slovo % Varik + 1 != 0 && list.Contains(slovo) == false)
                        {
                            list.Add(slovo);
                            dalee = true;

                            

                        }
                    }
                }
                Words.Add(dtbase.Rows[slovo][1].ToString(), dtbase.Rows[slovo][2].ToString());


                switch (count_of_Random)
                {
                    case 0:
                        {
                            foreach (var item in Words)
                            {
                                Label_Word_1.Text = item.Value;
                            }

                            break;
                        }
                    case 1:
                        {
                            foreach (var item in Words)
                            {
                                Label_Word_2.Text = item.Value;
                            }
                            
                            break;
                        }
                    case 2:
                        {
                            foreach (var item in Words)
                            {
                                Label_Word_3.Text = item.Value;
                            }
                            
                            break;
                        }
                    case 3:
                        {
                            foreach (var item in Words)
                            {
                                Label_Word_4.Text = item.Value;
                            }
                            break;
                        }
                    case 4:
                        {
                            foreach (var item in Words)
                            {
                                Label_Word_5.Text = item.Value;
                            }
                           
                            break;
                        }
                    default:
                        break;
                }




                count_of_Random++;


            }
           
            Control_work.Title = "Контрольная Работа " + "Вариант №" + Varik.ToString();
            VARa.Content += Varik.ToString();
            string[] mas = new string[dtbase_OKR.Rows.Count];
            mas_without_razdeleniy = new string[dtbase_OKR.Rows.Count];
            for (int i = 0; i < dtbase_OKR.Rows.Count; i++)
            {
                mas[i] = dtbase_OKR.Rows[i][1].ToString();
                mas_without_razdeleniy[i] = dtbase_OKR.Rows[i][1].ToString();
            }
            for (int i = 0; i < mas_without_razdeleniy.Length; i++)
            {
                
                mas_without_razdeleniy[i] = mas_without_razdeleniy[i].Replace("|", "");
                
            }
            
            int cou = (mas.Length * 2) - 1;
            List<string> Raz = new List<string>();
            string[] Razdel = new string[cou];
            for (int i = 0; i < mas.Length; i++)
            {
                if (i != cou)
                {
                    Razdel = mas[i].Split(new char[] { '|' });
                    foreach (var item in Razdel)
                    {
                        Raz.Add(item);
                    }
                }
            }

            Random rar = new Random();
            list.Clear();
            slovo = 0;
            int count_digit = 0;
            while (count_digit != Raz.Count)
            {
                
                dalee = false;
                while (dalee != true)
                {
                    slovo = rar.Next(0, Raz.Count);
                    if (list.Contains(slovo) == false  && slovo % 2 == 0 && Raz[slovo].ToString() != "")
                    {
                        switch (count_digit)
                        {
                            case 0:
                                {
                                    
                                    Text_First_Part_1.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 1:
                                {
                                    Text_Second_Part_1.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 2:
                                {
                                    Text_Third_Part_1.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 3:
                                {
                                    Text_Fourth_Part_1.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            default:
                                break;
                        }
                    }

                    if (list.Contains(slovo) == false  && slovo % 2 != 0 && Raz[slovo].ToString() != "")
                    {
                        switch (count_digit)
                        {
                            case 4:
                                {
                                    Text_First_Part_2.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 5:
                                {
                                    Text_Second_Part_2.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 6:
                                {
                                    Text_Third_Part_2.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            case 7:
                                {
                                    Text_Fourth_Part_2.Text = Raz[slovo].ToString();
                                    dalee = true;
                                    list.Add(slovo);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                count_digit++;
                if (count_digit == 8)
                {
                    break;
                }
                // }
            }

            Random ar = new Random();
            
            list.Clear();
            slovo = 0;
            int sdd = MainWindow.sas;
            int amount_of_questions = 10;
            for (int i = 0; i < dtbase_Questions.Rows.Count; i++)
            {
                slovo = rar.Next(0, dtbase_Questions.Rows.Count);
                if (Varik == 2)
                {
                    if (list.Contains(slovo) == false && slovo % Varik == 0 && amount_of_questions > 0)
                    {
                        list_Questions.Add(dtbase_Questions.Rows[slovo][1].ToString());
                        list_Answers.Add(dtbase_Questions.Rows[slovo][2].ToString());
                        amount_of_questions--;
                        list.Add(slovo);

                    }
                }
                if (Varik == 1)
                {
                    if (list.Contains(slovo) == false && slovo % Varik + 1 != 0 && amount_of_questions > 0)
                    {
                        list_Questions.Add(dtbase_Questions.Rows[slovo][1].ToString());
                        list_Answers.Add(dtbase_Questions.Rows[slovo][2].ToString());
                        amount_of_questions--;
                        list.Add(slovo);

                    }
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
            int slov = 0;
            bool proverka_na_null = false;
            Random random = new Random();

            while (proverka_na_null == true)
            {
                slov = random.Next(i, dtbase_OKR.Rows.Count - 1);
                if (dtbase_OKR.Rows[slov][2] != null)
                {
                    proverka_na_null = true;
                }

            }



            Text.Text = dtbase_OKR.Rows[slov][2].ToString();
            Name_of_text.Content = dtbase_OKR.Rows[slov][6].ToString();
            int count_t = 0;
            for (int i = 0; i < dtbase_OKR.Rows.Count; i++)
            {
                if (count_t > 5)
                {
                    break;
                }
                if (dtbase_OKR.Rows[slov][6].ToString() == dtbase_OKR.Rows[i][5].ToString())
                {
                    count_t++;
                    switch (count_t)
                    {
                        case 1:
                            {
                                Question_1.Content = dtbase_OKR.Rows[i][3].ToString();
                                otvetov.Add(Convert.ToBoolean(dtbase_OKR.Rows[i][4]));
                                break;
                            }
                        case 2:
                            {
                                Question_2.Content = dtbase_OKR.Rows[i][3].ToString();
                                otvetov.Add(Convert.ToBoolean(dtbase_OKR.Rows[i][4]));
                                break;
                            }
                        case 3:
                            {
                                Question_3.Content = dtbase_OKR.Rows[i][3].ToString();
                                otvetov.Add(Convert.ToBoolean(dtbase_OKR.Rows[i][4]));
                                break;
                            }
                        case 4:
                            {
                                Question_4.Content = dtbase_OKR.Rows[i][3].ToString();
                                otvetov.Add(Convert.ToBoolean(dtbase_OKR.Rows[i][4]));
                                break;
                            }
                        case 5:
                            {
                                Question_5.Content = dtbase_OKR.Rows[i][3].ToString();
                                otvetov.Add(Convert.ToBoolean(dtbase_OKR.Rows[i][4]));
                                break;
                            }
                        default:
                            break;
                    }
                }
            }

        }


        static int Proverka_int;
        public bool Odnorazovaya_peremennay = false;
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
                if (words[i].Contains("True"))
                {
                    index_of_true = i;
                    words[i] = words[i].Replace("True", "");
                }
            }
            First = words[0];
            Second = words[1];
            Third = words[2];

        }
        public int j = 0;
        public int i = 0;
        static string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // public static string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = Electronaya_obuc_programma; Integrated Security = True";
        public string Insert_into_backspaces(string a)
        {
            string peremennaya_for_take_symbol = "";
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
            if (peremennaya_for_take_symbol.Contains(","))
            {
                string[] sympols = peremennaya_for_take_symbol.Split(',');
                char[] massiv = a.ToCharArray();
                int count = 0;
                for (int i = 0; i < massiv.Length; i++)
                {
                    if (massiv[i] == '_')
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
        Dictionary<string, string> Words = new Dictionary<string, string>();
        
        bool[,] massiv_boley = new bool[,] {{ false, false, false, false },
                                            { false, false, false, false },
                                            { false, false, false, false },
                                            { false, false, false, false } };
        
        private void First_Part_1_Checked(object sender, RoutedEventArgs e)
        {

            if(First_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                //First_to_First.Visibility = Visibility.Visible;
                //First_to_Second.Visibility = Visibility.Hidden;
                //First_to_Third.Visibility = Visibility.Hidden;
                //First_to_Fourth.Visibility = Visibility.Hidden;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;

                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_First_Part_1.Text + Text_First_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        b.reshenie1 = true;
                        massiv_boley[0, 0] = true;
                       
                    }
                }
                if (massiv_boley[0, 0] == true)
                {
                    First_to_First.Visibility = Visibility.Visible;
                }
                


            }
            if(First_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                //First_to_First.Visibility = Visibility.Hidden;
                //First_to_Second.Visibility = Visibility.Visible;
                //First_to_Third.Visibility = Visibility.Hidden;
                //First_to_Fourth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
               
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_First_Part_1.Text + Text_Second_Part_2.Text == item)
                    {
                        b.reshenie1 = true;
                        massiv_boley[0, 1] = true;
                        MessageBox.Show("WWW");
                    }
                }
                if (massiv_boley[0, 1] == true)
                {
                    First_to_Second.Visibility = Visibility.Visible;
                }
                
            }
            if(First_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                //First_to_First.Visibility = Visibility.Hidden;
                //First_to_Second.Visibility = Visibility.Hidden;
                //First_to_Third.Visibility = Visibility.Visible;
                //First_to_Fourth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //Third_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
               
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_First_Part_1.Text + Text_Third_Part_2.Text == item)
                    {
                        b.reshenie1 = true;
                        massiv_boley[0, 2] = true;
                        MessageBox.Show("WWW");
                    }
                }
                if (massiv_boley[0, 2] == true)
                {
                    First_to_Third.Visibility = Visibility.Visible;
                }
                
            }
            if(First_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                //First_to_First.Visibility = Visibility.Hidden;
                //First_to_Second.Visibility = Visibility.Hidden;
                //First_to_Third.Visibility = Visibility.Hidden;
                //First_to_Fourth.Visibility = Visibility.Visible;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                
                //Fourth_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_First_Part_1.Text + Text_Fourth_Part_2.Text == item)
                    {
                        b.reshenie1 = true;
                        massiv_boley[0, 3] = true;
                        MessageBox.Show("WWW");
                    }
                }
                if (massiv_boley[0, 3] == true)
                {
                    First_to_Fourth.Visibility = Visibility.Visible;
                }
                
            }
        }
        private void First_Part_1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == false || First_Part_2.IsChecked == false)
            {
                First_to_First.Visibility = Visibility.Hidden;
            }
            if (First_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                First_to_Second.Visibility = Visibility.Hidden;
            }
            if (First_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                First_to_Third.Visibility = Visibility.Hidden;
            }
            if (First_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                First_to_Fourth.Visibility = Visibility.Hidden;
            }
        }
        ///////////////////////
        private void Second_Part_1_Checked(object sender, RoutedEventArgs e)
        {
            if (Second_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                
                //Second_to_First.Visibility = Visibility.Visible;
                //Second_to_Second.Visibility = Visibility.Hidden;
                //Second_to_Third.Visibility = Visibility.Hidden;
                //Second_to_Forth.Visibility = Visibility.Hidden;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
               
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Second_Part_1.Text + Text_First_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[1, 0] = true;
                        b.reshenie2 = true;
                    }
                }
                if (massiv_boley[1, 0] == true)
                {
                    Second_to_First.Visibility = Visibility.Visible;
                }
                

            }
            if (Second_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                //Second_to_First.Visibility = Visibility.Hidden;
                //Second_to_Second.Visibility = Visibility.Visible;
                //Second_to_Third.Visibility = Visibility.Hidden;
                //Second_to_Forth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                if (b.reshenie1 == true)
                {
                   // First_to_First.Visibility = Visibility.Visible;
                }
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Second_Part_1.Text + Text_Second_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[1, 1] = true;
                        b.reshenie2 = true;
                    }
                }
                if (massiv_boley[1, 1] == true)
                {
                    Second_to_Second.Visibility = Visibility.Visible;
                }
                
            }
            if (Second_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                //Second_to_First.Visibility = Visibility.Hidden;
                //Second_to_Second.Visibility = Visibility.Hidden;
                //Second_to_Third.Visibility = Visibility.Visible;
                //Second_to_Forth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
               
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Second_Part_1.Text + Text_Third_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[1, 2] = true;
                        b.reshenie2 = true;
                    }
                }
                if (massiv_boley[1, 2] == true)
                {
                    Second_to_Third.Visibility = Visibility.Visible;
                }
                
            }
            if (Second_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                //Second_to_First.Visibility = Visibility.Hidden;
                //Second_to_Second.Visibility = Visibility.Hidden;
                //Second_to_Third.Visibility = Visibility.Hidden;
                //Second_to_Forth.Visibility = Visibility.Visible;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Second_Part_1.Text + Text_Fourth_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[1, 3] = true;
                        b.reshenie2 = true;
                    }
                }
                if (massiv_boley[1, 3] == true)
                {
                    Second_to_Forth.Visibility = Visibility.Visible;
                }
                
            }


        }
        private void Second_Part_1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Second_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Second_to_First.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Second_to_Second.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Second_to_Third.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Second_to_Forth.Visibility = Visibility.Hidden;
            }
        }       
        //////////////////////
        private void Third_Part_1_Checked(object sender, RoutedEventArgs e)
        {
            if (Third_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                //Third_to_First.Visibility = Visibility.Visible;
                //Third_to_Second.Visibility = Visibility.Hidden;
                //Third_to_Third.Visibility = Visibility.Hidden;
                //Third_to_Forth.Visibility = Visibility.Hidden;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //Second_Part_1.IsChecked = false;
                //First_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Third_Part_1.Text + Text_First_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[2, 0] = true;
                    }
                }
                if (massiv_boley[2, 0] == true)
                {
                    Third_to_First.Visibility = Visibility.Visible;
                }
                
            }
            if (Third_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                //Third_to_First.Visibility = Visibility.Hidden;
                //Third_to_Second.Visibility = Visibility.Visible;
                //Third_to_Third.Visibility = Visibility.Hidden;
                //Third_to_Forth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Third_Part_1.Text + Text_Second_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[2, 1] = true;
                    }
                }
                if (massiv_boley[2, 1] == true)
                {
                    Third_to_Second.Visibility = Visibility.Visible;
                }
                

            }
            if (Third_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                //Third_to_First.Visibility = Visibility.Hidden;
                //Third_to_Second.Visibility = Visibility.Hidden;
                //Third_to_Third.Visibility = Visibility.Visible;
                //Third_to_Forth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Third_Part_1.Text + Text_Third_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[2, 2] = true;
                    }
                }
                if (massiv_boley[2, 2] == true)
                {
                    Third_to_Third.Visibility = Visibility.Visible;
                }
                
            }
            if (Third_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                //Third_to_First.Visibility = Visibility.Hidden;
                //Third_to_Second.Visibility = Visibility.Hidden;
                //Third_to_Third.Visibility = Visibility.Hidden;
                //Third_to_Forth.Visibility = Visibility.Visible;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Fourth_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Third_Part_1.Text + Text_Fourth_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[2, 3] = true;
                    }
                }
                if (massiv_boley[2, 3] == true)
                {
                    Third_to_Forth.Visibility = Visibility.Visible;
                }
                
            }
        }
        private void Third_Part_1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Third_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Third_to_First.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Third_to_Second.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Third_to_Third.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Third_to_Forth.Visibility = Visibility.Hidden;
            }
        }

        //////////////////////
        private void Fourth_Part_1_Checked(object sender, RoutedEventArgs e)
        {
            if (Fourth_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                //Fourth_to_First.Visibility = Visibility.Visible;
                //Fourth_to_Second.Visibility = Visibility.Hidden;
                //Fourth_to_Third.Visibility = Visibility.Hidden;
                //Fourth_to_Fourth.Visibility = Visibility.Hidden;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //First_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Fourth_Part_1.Text + Text_First_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[3, 0] = true;
                    }
                }
                if (massiv_boley[3, 0] == true)
                {
                    Fourth_to_First.Visibility = Visibility.Visible;
                }
               
            }
            if (Fourth_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                //Fourth_to_First.Visibility = Visibility.Hidden;
                //Fourth_to_Second.Visibility = Visibility.Visible;
                //Fourth_to_Third.Visibility = Visibility.Hidden;
                //Fourth_to_Fourth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Fourth_Part_1.Text + Text_Second_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[3, 1] = true;
                    }
                }
                if (massiv_boley[3, 1] == true)
                {
                    Fourth_to_Second.Visibility = Visibility.Visible;
                }
                

            }
            if (Fourth_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                //Fourth_to_First.Visibility = Visibility.Hidden;
                //Fourth_to_Second.Visibility = Visibility.Hidden;
                //Fourth_to_Third.Visibility = Visibility.Visible;
                //Fourth_to_Fourth.Visibility = Visibility.Hidden;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Fourth_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                    if (Text_Fourth_Part_1.Text + Text_Third_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[3, 2] = true;
                    }
                }
                if (massiv_boley[3, 2] == true)
                {
                    Fourth_to_Third.Visibility = Visibility.Visible;
                }
                
            }
            if (Fourth_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                //Fourth_to_First.Visibility = Visibility.Hidden;
                //Fourth_to_Second.Visibility = Visibility.Hidden;
                //Fourth_to_Third.Visibility = Visibility.Hidden;
                //Fourth_to_Fourth.Visibility = Visibility.Visible;
                //First_Part_2.IsChecked = false;
                //Second_Part_2.IsChecked = false;
                //Third_Part_2.IsChecked = false;
                
                //First_Part_1.IsChecked = false;
                //Second_Part_1.IsChecked = false;
                //Third_Part_1.IsChecked = false;
                //if (reshenie1 == true)
                //{
                //    First_to_First.Visibility = Visibility.Visible;
                //}
                foreach (var item in mas_without_razdeleniy)
                {
                   
                    if (Text_Fourth_Part_1.Text + Text_Fourth_Part_2.Text == item)
                    {
                        MessageBox.Show("WWW");
                        massiv_boley[3, 3] = true;
                    }
                }
                if (massiv_boley[3, 3] == true)
                {
                    Fourth_to_Fourth.Visibility = Visibility.Visible;
                }
                
            }
        }
        private void Fourth_Part_1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Fourth_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Fourth_to_First.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Fourth_to_Second.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Fourth_to_Third.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Fourth_to_Fourth.Visibility = Visibility.Hidden;
            }
        }
        //////////////////////......................................................................................................................
        private void First_Part_2_Checked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                
                if (b.reshenie1 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_First_Part_1.Text + Text_First_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2","Cообщение",MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[0, 0] = true;
                            b.reshenie1 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[0, 0] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            
                            First_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[0, 0] == true)
                {
                    First_to_First.Visibility = Visibility.Visible;
                }
                
            }
            if (Second_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                
                if (b.reshenie2 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Second_Part_1.Text + Text_First_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[1, 0] = true;
                            b.reshenie2 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[1, 0] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            First_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[1, 0] == true)
                {
                    Second_to_First.Visibility = Visibility.Visible;
                }
                

            }
            if (Third_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                
                if (b.reshenie3 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Third_Part_1.Text + Text_First_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[2, 0] = true;
                            b.reshenie3 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[2, 0] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            First_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[2, 0] == true)
                {
                    Third_to_First.Visibility = Visibility.Visible;
                }
                
            }
            if (Fourth_Part_1.IsChecked == true && First_Part_2.IsChecked == true)
            {
                
                if (b.reshenie4 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Fourth_Part_1.Text + Text_First_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[3, 0] = true;
                            b.reshenie4 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[3, 0] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            First_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[3, 0] == true)
                {
                    Fourth_to_First.Visibility = Visibility.Visible;
                }
                
            }

        }
        private void First_Part_2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == false || First_Part_2.IsChecked == false)
            {
                First_to_First.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Second_to_First.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Third_to_First.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || First_Part_2.IsChecked == true)
            {
                Fourth_to_First.Visibility = Visibility.Hidden;
            }

        }
        //////////////////////
        private void Second_Part_2_Checked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                
                if (b.reshenie1 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_First_Part_1.Text + Text_Second_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            b.reshenie1 = true;
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[0, 1] = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[0, 1] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Second_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[0, 1] == true)
                {
                    First_to_Second.Visibility = Visibility.Visible;
                }
                
            }
            if (Second_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                
                if (b.reshenie2 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Second_Part_1.Text + Text_Second_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            b.reshenie2 = true;
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[1, 1] = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[1, 1] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Second_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[1, 1] == true)
                {
                    Second_to_Second.Visibility = Visibility.Visible;
                }
                
            }
            if (Third_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                
                if (b.reshenie3 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Third_Part_1.Text + Text_Second_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[2, 1] = true;
                            b.reshenie3 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[2, 1] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Second_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[2, 1] == true)
                {
                    Third_to_Second.Visibility = Visibility.Visible;
                }
                
            }
            if (Fourth_Part_1.IsChecked == true && Second_Part_2.IsChecked == true)
            {
                
                if (b.reshenie4 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Fourth_Part_1.Text + Text_Second_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[3, 1] = true;
                            b.reshenie4 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[3, 1] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Second_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[3, 1] == true)
                {
                    Fourth_to_Second.Visibility = Visibility.Visible;
                }
                
            }

        }
        private void Second_Part_2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                First_to_Second.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Second_to_Second.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Third_to_Second.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Second_Part_2.IsChecked == true)
            {
                Fourth_to_Second.Visibility = Visibility.Hidden;
            }
        }
        //////////////////////
        private void Third_Part_2_Checked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
               
                if (b.reshenie1 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_First_Part_1.Text + Text_Third_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            b.reshenie1 = true;
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[0, 2] = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[0, 2] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Third_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[0, 2] == true)
                {
                    First_to_Third.Visibility = Visibility.Visible;
                }
               
            }
            if (Second_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                
                if (b.reshenie2 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Second_Part_1.Text + Text_Third_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            b.reshenie2 = true;
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[1, 2] = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[1, 2] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Third_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[1, 2] == true)
                {
                    Second_to_Third.Visibility = Visibility.Visible;
                }
                
            }
            if (Third_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
               
                if (b.reshenie3 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Third_Part_1.Text + Text_Third_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[2, 2] = true;
                            b.reshenie3 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[2, 2] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Third_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[2, 2] == true)
                {
                    Third_to_Third.Visibility = Visibility.Visible;
                }
               
            }
            if (Fourth_Part_1.IsChecked == true && Third_Part_2.IsChecked == true)
            {
                
                if (b.reshenie4 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Fourth_Part_1.Text + Text_Third_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[3, 2] = true;
                            b.reshenie4 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[3, 2] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Third_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[3, 2] == true)
                {
                    Fourth_to_Third.Visibility = Visibility.Visible;
                }
                
            }
        }
        private void Third_Part_2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                First_to_Third.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Second_to_Third.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Third_to_Third.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Third_Part_2.IsChecked == true)
            {
                Fourth_to_Third.Visibility = Visibility.Hidden;
            }
        }
        //////////////////////
        private void Fourth_Part_2_Checked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                
                if (b.reshenie1 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {

                        if (Text_First_Part_1.Text + Text_Fourth_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[0, 3] = true;
                            b.reshenie1 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[0, 3] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Fourth_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[0, 3] == true)
                {
                    First_to_Fourth.Visibility = Visibility.Visible;
                }
               
            }
            if (Second_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                
                if (b.reshenie2 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Second_Part_1.Text + Text_Fourth_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            b.reshenie2 = true;
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[1, 3] = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[1, 3] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Fourth_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[1, 3] == true)
                {
                    Second_to_Forth.Visibility = Visibility.Visible;
                }
               
            }
            if (Third_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                
                if (b.reshenie3 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Third_Part_1.Text + Text_Fourth_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[2, 3] = true;
                            b.reshenie3 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[2, 3] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Fourth_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[2, 3] == true)
                {
                    Third_to_Forth.Visibility = Visibility.Visible;
                }
                
            }
            if (Fourth_Part_1.IsChecked == true && Fourth_Part_2.IsChecked == true)
            {
                
                if (b.reshenie4 == false)
                {
                    for (int i = 0; i < mas_without_razdeleniy.Length; i++)
                    {
                        if (Text_Fourth_Part_1.Text + Text_Fourth_Part_2.Text == mas_without_razdeleniy[i])
                        {
                            MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                            b.Count_all_points_OKR += 2;
                            massiv_boley[3, 3] = true;
                            b.reshenie4 = true;
                        }
                        int count = 0;
                        count = i;
                        count++;
                        if (mas_without_razdeleniy.Length == count && massiv_boley[3, 3] != true)
                        {
                            MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            if (b.Count_all_points_OKR != 0)
                            {
                                b.Count_all_points_OKR -= 2;
                            }
                            Fourth_Part_2.IsChecked = false;
                        }
                    }
                }
                if (massiv_boley[3, 3] == true)
                {
                    Fourth_to_Fourth.Visibility = Visibility.Visible;
                }
                
            }
        } 
        private void Fourth_Part_2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (First_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                First_to_Fourth.Visibility = Visibility.Hidden;
            }
            if (Second_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Second_to_Forth.Visibility = Visibility.Hidden;
            }
            if (Third_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Third_to_Forth.Visibility = Visibility.Hidden;
            }
            if (Fourth_Part_1.IsChecked == true || Fourth_Part_2.IsChecked == true)
            {
                Fourth_to_Fourth.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int digit = 0;
            foreach (var item in Words)
            {
                digit++;
                if (item.Key.Contains(Word_1.Text.ToLower()) & Word_1.Text != "")
                {
                    MessageBox.Show("Nise First ");
                    b.Count_all_points_OKR += 2;
                }
                
                if(digit == 1)
                {
                    if (item.Key.Contains(Word_1.Text.ToLower()) == false || Word_1.Text == "")
                    {
                        if(b.Count_all_points_OKR != 0)
                        {
                            b.Count_all_points_OKR -= 2;
                        }
                        MessageBox.Show("В первом слове допущена ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    continue;
                }
                if (item.Key.Contains(Word_2.Text.ToLower()) && Word_2.Text != "")
                {
                    MessageBox.Show("Nise Second");
                    b.Count_all_points_OKR += 2;
                }
               
                if (digit == 2)
                {
                    if (item.Key.Contains(Word_2.Text.ToLower()) == false ||/* digit == 2 &*/ Word_2.Text == "")
                    {
                        if (b.Count_all_points_OKR != 0)
                        {
                            b.Count_all_points_OKR -= 2;
                        }
                        MessageBox.Show("Во втором слове допущена ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    continue;
                }
                if (item.Key.Contains(Word_3.Text.ToLower()) && Word_3.Text != "")
                {
                    MessageBox.Show("Nise Third");
                    b.Count_all_points_OKR += 2;
                }
               
                if (digit == 3)
                {
                    if (item.Key.Contains(Word_3.Text.ToLower()) == false || /*digit == 3 &*/ Word_3.Text == "")
                    {
                        if (b.Count_all_points_OKR != 0)
                        {
                            b.Count_all_points_OKR -= 2;
                        }
                        MessageBox.Show("В третьем слове допущена ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    continue;
                }
                if (item.Key.Contains(Word_4.Text.ToLower()) && Word_4.Text != "")
                {
                    MessageBox.Show("Nise Fourth");
                    b.Count_all_points_OKR += 2;
                }
                
                if (digit == 4)
                {
                    if (item.Key.Contains(Word_4.Text.ToLower()) == false || /*digit == 4 &*/ Word_4.Text == "")
                    {
                        if (b.Count_all_points_OKR != 0)
                        {
                            b.Count_all_points_OKR -= 2;
                        }
                        MessageBox.Show("В четвертом слове допущена ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    continue;
                }
                if (item.Key.Contains(Word_5.Text.ToLower()) && Word_5.Text != "")
                {
                    MessageBox.Show("Nise Fiveth");
                    b.Count_all_points_OKR += 2;
                }
                
                if (digit == 5)
                {
                    if (item.Key.Contains(Word_5.Text.ToLower()) == false || /*digit == 5 &*/ Word_5.Text == "")
                    {
                        if (b.Count_all_points_OKR != 0)
                        {
                            b.Count_all_points_OKR -= 2;
                        }
                        MessageBox.Show("В пятом слове допущена ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    continue;
                }
            }

        }

        private void First_word_Click(object sender, RoutedEventArgs e)
        {

            Odnorazovaya_peremennay = false;
            if (index_of_true == 0 && list_Questions.Count != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                Poi.Points++;
                //Complete_points.Points++;
                MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                b.Count_all_points_OKR += 2;

            }
            if (index_of_true != 0)
            {
                //MessageBox.Show("Неправильный ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                //if (Complete_points.Points != 0)
                //{
                //    double points = 0;
                //    points = Poi.Points;
                //    points -= 0.2;
                //    Poi.Points = points;

                //}
            }
            if (list_Questions.Count == 0)
            {
                MessageBox.Show("Конечная");
            }
        }

        private void Second_word_Click(object sender, RoutedEventArgs e)
        {
            Odnorazovaya_peremennay = false;
            if (index_of_true == 1 && list_Questions.Count != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                //Complete_points.Points++;
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                //Poi.Points++;
                MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                b.Count_all_points_OKR += 2;
            }
            if (index_of_true != 1)
            {
                MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                //MessageBox.Show("Неправильный ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                //if (Complete_points.Points != 0)
                //{
                //    double points = 0;
                //    points = Poi.Points;
                //    points -= 0.2;
                //    Poi.Points = points;

                //}
            }
            if (list_Questions.Count == 0)
            {
                MessageBox.Show("Конечная");
            }
        }

        private void Third_word_Click(object sender, RoutedEventArgs e)
        {
            Odnorazovaya_peremennay = false;
            if (index_of_true == 2 && list_Questions.Count != 0)
            {
                Questions.Text = Insert_into_backspaces(Questions.Text);
                //Complete_points.Points++;
                int count = 0;
                count = Poi.CConts;
                count--;
                Poi.CConts = count;
                //Poi.Points++;
                MessageBox.Show("+2", "Cообщение", MessageBoxButton.OK);
                b.Count_all_points_OKR += 2;
            }
            if (index_of_true != 2)
            {
                MessageBox.Show("Ошибка -2 балла", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                //MessageBox.Show("Неправильный ответ", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                //if (Complete_points.Points != 0)
                //{
                //    double points = 0;
                //    points = Poi.Points;
                //    points -= 0.2;
                //    Poi.Points = points;

                //}
            }
            if (list_Questions.Count == 0)
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
                MessageBox.Show("Конечная");
            }
            //else
            //{
            //    int sdd = MainWindow.sas;
            //    DataTable dtbase_Questions = Select("SELECT * FROM [dbo].[Student_profile]");
            //   // Exit.Visibility = Visibility.Visible;
            //    SqlConnection con = new SqlConnection(g);
            //    if (Convert.ToInt32(dtbase_Questions.Rows[(Studentt.ID - 1)][3]) != sdd)
            //    {
            //        double po = Poi.Points;
            //        po += Convert.ToDouble(dtbase_Questions.Rows[(Studentt.ID - 1)][4]);
            //        con.Open();
            //        string das = "update Student_profile set id_of_theme='" + sdd + "'where Id= '" + Studentt.ID + "'";
            //        SqlCommand cmd = new SqlCommand(das, con);
            //        string dass = "update Student_profile set points='" + po + "'where Id= '" + Studentt.ID + "'";
            //        SqlCommand cmdd = new SqlCommand(dass, con);
            //        string dasss = "update Student_profile set count_id_of_theme='" + $"{sdd}," + "'where Id= '" + Studentt.ID + "'";
            //        SqlCommand cmddd = new SqlCommand(dasss, con);
            //        cmd.ExecuteNonQuery();
            //        cmdd.ExecuteNonQuery();
            //        cmddd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
        }

        
        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Question_1_Yes_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = true;
            if (Prroverka == otvetov[0])
            {
                MessageBox.Show("+2");
            }
        }

        private void Question_1_No_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = false;
            if (Prroverka == otvetov[0])
            {
                MessageBox.Show("+2");
            }
        }

        private void Question_2_Yes_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = true;
            if (Prroverka == otvetov[1])
            {
                MessageBox.Show("+2");
            }
        }

        private void Question_2_No_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = false;
            if (Prroverka == otvetov[1])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_3_Yes_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = true;
            if (Prroverka == otvetov[2])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_3_No_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = false;
            if (Prroverka == otvetov[2])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_4_Yes_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = true;
            if (Prroverka == otvetov[3])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_4_No_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = false;
            if (Prroverka == otvetov[3])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_5_Yes_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = true;
            if (Prroverka == otvetov[4])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Question_5_No_Click(object sender, RoutedEventArgs e)
        {
            bool Prroverka = false;
            if (Prroverka == otvetov[4])
            {
                MessageBox.Show("+2");
                b.Count_all_points_OKR += 2;
            }
            else
            {
                if (b.Count_all_points_OKR != 0)
                {
                    b.Count_all_points_OKR -= 2;
                }
                MessageBox.Show("-2");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (b.Count_all_points_OKR > 40)
            {
                MessageBox.Show($"Ваша оценка 9, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 35 && b.Count_all_points_OKR < 40)
            {
                MessageBox.Show($"Ваша оценка 8, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 30 && b.Count_all_points_OKR < 35)
            {
                MessageBox.Show($"Ваша оценка 7, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 25 && b.Count_all_points_OKR < 30)
            {
                MessageBox.Show($"Ваша оценка 6, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 20 && b.Count_all_points_OKR < 25)
            {
                MessageBox.Show($"Ваша оценка 5, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 15 && b.Count_all_points_OKR < 20)
            {
                MessageBox.Show($"Ваша оценка 4, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR > 10 && b.Count_all_points_OKR < 15)
            {
                MessageBox.Show($"Ваша оценка 3, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR >= 5 && b.Count_all_points_OKR < 10)
            {
                MessageBox.Show($"Ваша оценка 2, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
            if (b.Count_all_points_OKR >= 0 && b.Count_all_points_OKR <= 5)
            {
                MessageBox.Show($"Ваша оценка 1, ваше кол-во баллов = {b.Count_all_points_OKR}", "Результат");
            }
        }

        private void Sentences_Checked(object sender, RoutedEventArgs e)
        {
            Label_russian_words.Visibility = Visibility.Visible;
            Label_english_words.Visibility = Visibility.Hidden;
        } 
        private void Sentences_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_russian_words.Visibility = Visibility.Hidden;
            Label_english_words.Visibility = Visibility.Visible;
        }

        private void Zadanie2_Checked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_2.Visibility = Visibility.Visible;
            Label_eng_zad_2.Visibility = Visibility.Hidden;
        }
        private void Zadanie2_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_2.Visibility = Visibility.Hidden;
            Label_eng_zad_2.Visibility = Visibility.Visible;
        }

        private void Zadanie3_Checked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_3.Visibility = Visibility.Visible;
            Label_eng_zad_3.Visibility = Visibility.Hidden;
        }
        private void Zadanie3_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_3.Visibility = Visibility.Hidden;
            Label_eng_zad_3.Visibility = Visibility.Visible;
        }

        private void Zadanie4_Checked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_4.Visibility = Visibility.Visible;
            Label_eng_zad_4.Visibility = Visibility.Hidden;
        }
        private void Zadanie4_Unchecked(object sender, RoutedEventArgs e)
        {
            Label_rus_zad_4.Visibility = Visibility.Hidden;
            Label_eng_zad_4.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow s = new MainWindow();
            this.Close();
            s.ShowDialog();
        }
    }
}
