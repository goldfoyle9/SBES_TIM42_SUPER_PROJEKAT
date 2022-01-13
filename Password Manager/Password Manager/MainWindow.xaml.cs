using Common;
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

namespace Password_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionManager connection;
        public MainWindow()
        {

            connection = new ConnectionManager();
            InitializeComponent();
        }

        private void addPassword_Click(object sender, RoutedEventArgs e)
        {
            string nickname = passwordID.Text;
            byte[] password = EncryptionManager.EncryptStringToBytes_Aes(passwordValue.Text);
            MessageBox.Show(EncryptionManager.DecryptStringFromBytes_Aes(password));

            var query = "INSERT INTO [Table] (nickname, password) VALUES (@nick, @pass);";
            var command = new SqlCommand(query, connection.Connection);
            command.Parameters.AddWithValue("@nick", nickname);
            command.Parameters.AddWithValue("@pass", password);
            command.ExecuteNonQuery();
        }
    }
}
