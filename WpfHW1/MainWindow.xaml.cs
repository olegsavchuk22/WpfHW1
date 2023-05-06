using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHW1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool check = false;
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement item in Calc.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "CE")
            {
                str = "";

                TB1.Text = str;
                TB2.Text = str;

            }
            if (str == "C")
            {
                str = "";

                TB1.Text = TB1.Text.Remove(TB1.Text.Length-1, 1);
                if (TB2.Text!=string.Empty)
                {
                    TB2.Text = TB2.Text.Remove(TB2.Text.Length - 1, 1);
                }
            }
            else if (str == "*")
            {
                check = true;
            }
            else if (str == "/")
            {
                check = true;
            }
            else if (str == "+")
            {
                check = true;
            }
            else if (str == "-")
            {
                check = true;
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(TB1.Text, null).ToString();
                TB2.Text = value;
                str = "";
                TB1.Text =value;
            }

            TB1.Text += str;
            TB2.Text += str;
            if (check)
            {
                TB2.Text = "";
                check = false;
            }
        }
    }
}
