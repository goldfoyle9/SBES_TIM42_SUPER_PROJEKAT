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
    public class AddPasswordCommand : CommandBase
    {
        private PasswordViewModel viewModel;
        private static int i = 0;
        public AddPasswordCommand(PasswordViewModel pvm)
        {
            viewModel = pvm;  
        }
        public override void Execute(object parameter)
        {
            PasswordModel  model = new PasswordModel(viewModel.Value, viewModel.Nickname, viewModel.Website, viewModel.Username, viewModel.Additional);
            DatabaseManager.Add(model.ToString(), i++, "Passwords", false);
        }

    }
}
