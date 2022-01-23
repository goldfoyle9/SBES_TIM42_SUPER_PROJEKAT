using Common;
using Password_Manager.Models;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.Commands.PasswordCommands
{
    public class GetSpecificPassword : CommandBase
    {
        private PasswordViewModel viewModel;
        public GetSpecificPassword(PasswordViewModel pvm)
        {
            viewModel = pvm;  
        }
        public override void Execute(object parameter)
        {
            PasswordModel passModel = viewModel.PasswordCollection.Find(t => t.Id == (int)parameter);
            viewModel.Password = passModel.Value;
            viewModel.Additional = passModel.Additional;
            viewModel.Nickname = passModel.Nickname;
            viewModel.Username = passModel.Username;
            viewModel.Website = passModel.Website;
            PasswordViewModel.SelectedID = (int)parameter;
        }

    }
}
