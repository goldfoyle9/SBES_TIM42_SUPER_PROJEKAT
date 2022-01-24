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
        public AddPasswordCommand(PasswordViewModel pvm)
        {
            viewModel = pvm;  
        }
        public override void Execute(object parameter)
        {
            PasswordModel model = new PasswordModel(viewModel.Password, viewModel.Nickname, viewModel.Website, viewModel.Username, viewModel.Additional);
            if (PasswordViewModel.SelectedID == -1)
                DatabaseManager.Add(model.ToString(), viewModel.FindFirstId(), "Passwords", false);
            else
                DatabaseManager.Add(model.ToString(), PasswordViewModel.SelectedID, "Passwords", true);
            PasswordViewModel.SelectedID = -1;
        }

    }
}
