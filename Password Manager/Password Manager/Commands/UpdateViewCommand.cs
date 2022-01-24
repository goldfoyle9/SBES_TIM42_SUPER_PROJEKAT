using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private StartViewModel viewModel;

        public UpdateViewCommand(StartViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Password":
                    viewModel.SelectedViewModel = new PasswordViewModel();
                    break;
                case "Identities":
                    viewModel.SelectedViewModel = new IdentitiesViewModel();
                    break;
                case "2FA":
                    viewModel.SelectedViewModel = new _2FAViewModel();
                    break;
                case "Cards":
                    viewModel.SelectedViewModel = new CardsViewModel();
                    break;
                case "Settings":
                    //Common.Formatter.FormatDrive_CommandLine('G');
                    try
                    {
                        using (var streamWriter = new StreamWriter("G:\\key"))
                        {
                            var random = new Random();
                            string key = random.Next().ToString() + random.Next().ToString() + random.Next().ToString() + random.Next().ToString();
                            streamWriter.WriteLine(key);

                            File.SetAttributes("G:\\key", FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.System);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    viewModel.SelectedViewModel = new SettingsViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
