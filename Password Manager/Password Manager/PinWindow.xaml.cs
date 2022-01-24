using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Password_Manager
{
    /// <summary>
    /// Interaction logic for PinWindow.xaml
    /// </summary>
    public partial class PinWindow : Window
    {
        DispatcherTimer timer;
        public PinWindow()
        {
            InitializeComponent();
        }

        private bool CollectInput()
        {
            string pin1 = pinBox1.Password + pinBox1_Copy.Password + pinBox1_Copy1.Password + pinBox1_Copy2.Password + pinBox1_Copy3.Password + pinBox1_Copy4.Password;
            string pin2 = pinBox1_Copy5.Password + pinBox1_Copy6.Password + pinBox1_Copy7.Password + pinBox1_Copy8.Password + pinBox1_Copy9.Password + pinBox1_Copy10.Password;
            try
            {

                if (pin1 == pin2)
                {
                    using (StreamWriter sw = new StreamWriter("G:\\pin"))
                        sw.WriteLine(pin1);
                    File.SetAttributes("G:\\pin", FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.System);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input USB Drive.");
                return false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            timer.Stop();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(2000);
            if (!CollectInput())
            {
                MessageBox.Show("Pin codes don't match!", "Nope!", MessageBoxButton.OK);
            }
            else
            {
                spin_me_round.Visibility = Visibility.Visible;
                if (timer == null)
                {
                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(3);
                    timer.Tick += timer_Tick;
                    timer.Start();
                }
            }
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
            pinBox1_Copy5.Focus();
        }

        private void pinBox1_Copy5_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy6.Focus();
        }

        private void pinBox1_Copy6_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy7.Focus();
        }

        private void pinBox1_Copy7_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy8.Focus();
        }

        private void pinBox1_Copy8_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy9.Focus();
        }

        private void pinBox1_Copy9_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pinBox1_Copy10.Focus();
        }

        private void pinBox1_Copy10_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
        }
    }
}
