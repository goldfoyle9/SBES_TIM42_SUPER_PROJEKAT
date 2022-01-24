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
    /// Interaction logic for _2FAView.xaml
    /// </summary>
    public partial class _2FAView : UserControl
    {
        DispatcherTimer timer;
        _2FAViewModel viewModel;
        public _2FAView()
        {
            InitializeComponent();
            viewModel = new _2FAViewModel();
            StackPanel.ItemsSource = viewModel._2FACollection;
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
            StackPanel.ItemsSource = viewModel._2FACollection;
            deletebtn.CommandParameter = _2FAViewModel.SelectedID;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = true;
            tb_additional.IsReadOnly = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = false;
            tb_additional.IsReadOnly = false;
        }
        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            tb_nickname.IsReadOnly = false;
            tb_additional.IsReadOnly = false;
            tb_nickname.Text = "";
            pb_secret.Password = "";
            tb_additional.Text = "";
            CardsViewModel.SelectedID = -1;
        }
    }
}
