using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        DispatcherTimer timer;
        public StartWindow()
        {
            InitializeComponent();

            if (Environment.GetEnvironmentVariable("numb", EnvironmentVariableTarget.User) != null)
            {
                Window window = new PinWindow();
                try
                {
                    window.Show();
                }
                catch (Exception)
                {

                }
                this.Close();
            }
        }



        private void phoneNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Window window = new TotpWindow();
            window.Show();
            timer.Stop();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsPhoneNumber(phoneNum.Text))
            {
                TwoFactorCodeGenerator.SendTotpCode(phoneNum.Text);
                spin_me_round.Visibility = Visibility.Visible;
                if (timer == null)
                {
                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(3);
                    timer.Tick += timer_Tick;
                    timer.Start();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid phone number!", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
        private bool IsPhoneNumber(string number)
        {
            if(number[0] != '+'  || number.Length > 14 || number.Any(x => char.IsLetter(x)))
            {
                return false;
            }
            return true;
            
        }
    }
}
    