using System;
using System.Collections.Generic;
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
            Button_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pin = pinBox1.Password + pinBox1_Copy.Password + pinBox1_Copy1.Password + pinBox1_Copy2.Password + pinBox1_Copy3.Password + pinBox1_Copy4.Password;
                using (StreamReader sr = new StreamReader("G:\\pin"))
                    if (pin == sr.ReadToEnd().Trim())
                    {
                        Window window = new MainWindow();
                        window.Show();
                        this.Close();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Access without USB drive.");
            }
        }
    }
}
