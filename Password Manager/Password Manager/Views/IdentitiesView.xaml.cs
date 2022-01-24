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
    /// Interaction logic for IdentitiesView.xaml
    /// </summary>
    public partial class IdentitiesView : UserControl
    {
        DispatcherTimer timer;
        IdentitiesViewModel viewModel;
        public IdentitiesView()
        {
            InitializeComponent();
            viewModel = new IdentitiesViewModel();
            StackPanel.ItemsSource = viewModel.IdentityCollection;
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
            viewModel.UpdateList();
            StackPanel.ItemsSource = viewModel.IdentityCollection;
            deletebtn.CommandParameter = IdentitiesViewModel.SelectedID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = true;
            tb_title.IsReadOnly = true;
            tb_gender.IsReadOnly = true;
            tb_email.IsReadOnly = true;
            tb_first_name.IsReadOnly = true;
            tb_last_name.IsReadOnly = true;
            tb_phone_number.IsReadOnly = true;
            tb_first_address.IsReadOnly = true;
            tb_second_address.IsReadOnly = true;
            tb_zip.IsReadOnly = true;
            tb_city.IsReadOnly = true;
            tb_country.IsReadOnly = true;
            tb_additional.IsReadOnly = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = false;
            tb_title.IsReadOnly = false;
            tb_gender.IsReadOnly = false;
            tb_email.IsReadOnly = false;
            tb_first_name.IsReadOnly = false;
            tb_last_name.IsReadOnly = false;
            tb_phone_number.IsReadOnly = false;
            tb_first_address.IsReadOnly = false;
            tb_second_address.IsReadOnly = false;
            tb_zip.IsReadOnly = false;
            tb_city.IsReadOnly = false;
            tb_country.IsReadOnly = false;
            tb_additional.IsReadOnly = false;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = false;
            tb_title.IsReadOnly = false;
            tb_gender.IsReadOnly = false;
            tb_email.IsReadOnly = false;
            tb_first_name.IsReadOnly = false;
            tb_last_name.IsReadOnly = false;
            tb_phone_number.IsReadOnly = false;
            tb_first_address.IsReadOnly = false;
            tb_second_address.IsReadOnly = false;
            tb_zip.IsReadOnly = false;
            tb_city.IsReadOnly = false;
            tb_country.IsReadOnly = false;
            tb_additional.IsReadOnly = false; 
            tb_nickname.Text = "";
            tb_title.Text = "";
            tb_gender.Text = "";
            tb_email.Text = "";
            tb_first_name.Text = "";
            tb_last_name.Text = "";
            tb_phone_number.Text = "";
            tb_first_address.Text = "";
            tb_second_address.Text = "";
            tb_zip.Text = "";
            tb_city.Text = "";
            tb_country.Text = "";
            tb_additional.Text = "";
            IdentitiesViewModel.SelectedID = -1;
        }
    }
}
