using Common;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Commands.PasswordCommands
{
    public class DeletePasswordCommand : CommandBase
    {
        public DeletePasswordCommand()
        { 
        }
        public override void Execute(object parameter)
        {
            if((int)parameter != -1)
                DatabaseManager.Delete("Passwords", (int)parameter);
            PasswordViewModel.SelectedID = -1;
        }

    }
}
