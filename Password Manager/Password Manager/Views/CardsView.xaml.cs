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
    /// Interaction logic for CardsView.xaml
    /// </summary>
    public partial class CardsView : UserControl
    {
        DispatcherTimer timer;
        CardsViewModel viewModel;
        public CardsView()
        {
            InitializeComponent();
             viewModel = new CardsViewModel();
            StackPanel.ItemsSource = viewModel.CardCollection;
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
            StackPanel.ItemsSource = viewModel.CardCollection;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = true;
            tb_name.IsReadOnly = true;
            tb_number.IsReadOnly = true;
            tb_type.IsReadOnly = true;
            tb_country.IsReadOnly = true;
            tb_issuance_date.IsReadOnly = true;
            tb_expiration_date.IsReadOnly = true;
            tb_additional.IsReadOnly = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = false;
            tb_name.IsReadOnly = false;
            tb_number.IsReadOnly = false;
            tb_type.IsReadOnly = false;
            tb_country.IsReadOnly = false;
            tb_issuance_date.IsReadOnly = false;
            tb_expiration_date.IsReadOnly = false;
            tb_additional.IsReadOnly = false;
        }
    }
}
