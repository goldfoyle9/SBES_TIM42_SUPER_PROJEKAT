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

namespace Password_Manager
{
    /// <summary>
    /// Interaction logic for TimeoutWindow.xaml
    /// </summary>
    public partial class TimeoutWindow : Window
    {
        public TimeoutWindow()
        {
            InitializeComponent();
        }
        private void pinBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy.Focus();
        }

        private void pinBox1_Copy_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy1.Focus();
        }

        private void pinBox1_Copy1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy2.Focus();
        }

        private void pinBox1_Copy2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy3.Focus();
        }

        private void pinBox1_Copy3_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy4.Focus();
        }
        private void pinBox1_Copy4_PasswordChanged(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
