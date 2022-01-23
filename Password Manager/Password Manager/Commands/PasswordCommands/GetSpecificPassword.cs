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
            viewModel.Password = viewModel.PasswordCollection[(int)parameter].Value;
            viewModel.Additional = viewModel.PasswordCollection[(int)parameter].Additional;
            viewModel.Nickname = viewModel.PasswordCollection[(int)parameter].Nickname;
            viewModel.Username = viewModel.PasswordCollection[(int)parameter].Username;
            viewModel.Website = viewModel.PasswordCollection[(int)parameter].Website;
        }

    }
}
