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
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }


            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var idleTime = IdleTimeDetector.GetIdleTimeInfo();
            if(idleTime.IdleTime.TotalSeconds > 30)
            {
                Window timeout = new TimeoutWindow();
                timeout.Show();
                this.Close();
                timer.Stop();
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
