using Common;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for TotpWindow.xaml
    /// </summary>
    public partial class TotpWindow : Window
    {
        DispatcherTimer timer;
        public TotpWindow()
        {
            InitializeComponent();
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
            if (!TwoFactorCodeGenerator.VerifyTotpCode(code.Text))
            {
                MessageBox.Show("Incorrect code", "Nope!", MessageBoxButton.OK);
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
    }
}
