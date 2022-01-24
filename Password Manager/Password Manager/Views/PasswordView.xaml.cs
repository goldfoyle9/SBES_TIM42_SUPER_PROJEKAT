using Password_Manager.Models;
using Password_Manager.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Password_Manager.Views
{
    /// <summary>
    /// Interaction logic for PasswordView.xaml
    /// </summary>
    public partial class PasswordView : UserControl
    {
        PasswordViewModel passwordViewModel;
        DispatcherTimer timer;
        public PasswordView()
        {
            InitializeComponent();
            
            passwordViewModel = new PasswordViewModel();
            StackPanel.ItemsSource = passwordViewModel.PasswordCollection;
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            passwordViewModel.UpdateList();
            StackPanel.ItemsSource = passwordViewModel.PasswordCollection;
            deletebtn.CommandParameter = PasswordViewModel.SelectedID;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_username.IsReadOnly = true;
            tb_website.IsReadOnly = true;
            tb_addinfo.IsReadOnly = true;
            tb_nickname.IsReadOnly = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_username.IsReadOnly = false;
            tb_website.IsReadOnly = false;
            tb_addinfo.IsReadOnly = false;
            tb_nickname.IsReadOnly = false;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            tb_username.IsReadOnly = false;
            tb_website.IsReadOnly = false;
            tb_addinfo.IsReadOnly = false;
            tb_nickname.IsReadOnly = false;
            tb_username.Text = "";
            tb_website.Text = "";
            pb_password.Password = "";
            tb_addinfo.Text = "";
            tb_nickname.Text = "";
            PasswordViewModel.SelectedID = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(pb_password.Password);
        }
    }
}
