using System;
using System.Collections.Generic;
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
    /// Interaction logic for Variant.xaml
    /// </summary>
    public partial class Variant : Window
    {
        public Variant()
        {
            InitializeComponent();
        }
       public static string peredacha_varianta = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Variant_t.Text != "")
            {
                peredacha_varianta = Variant_t.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
