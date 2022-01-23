using Common;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Password_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionManager connection;
        DispatcherTimer timer;

        public MainWindow()
        {
            connection = new ConnectionManager();
            InitializeComponent();
            DataContext = new StartViewModel();
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(30);
                timer.Tick += timer_Tick;
                timer.Start();
            }


            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var idleTime = IdleTimeDetector.GetIdleTimeInfo();
            if(idleTime.IdleTime.TotalSeconds > 5)
            {
                MessageBox.Show("STOP! YOU'VE VIOLATED THE LAW! PAY THE COURT A FINE OR SERVE YOUR SENTENCE! YOUR STOLEN GOODS ARE NOW FORFEIT, VANDAL!", "STOP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addPassword_Click(object sender, RoutedEventArgs e)
        {
            /*string nickname = passwordID.Text;
            byte[] password = EncryptionManager.EncryptStringToBytes_Aes(passwordValue.Text);
            MessageBox.Show(EncryptionManager.DecryptStringFromBytes_Aes(password));

            var query = "INSERT INTO [Table] (nickname, password) VALUES (@nick, @pass);";
            var command = new SqlCommand(query, connection.Connection);
            command.Parameters.AddWithValue("@nick", nickname);
            command.Parameters.AddWithValue("@pass", password);
            command.ExecuteNonQuery();*/
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
