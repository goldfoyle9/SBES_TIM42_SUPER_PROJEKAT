using Common;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Commands.IdentityCommands
{
    public class DeleteIdentityCommand : CommandBase
    {
        public DeleteIdentityCommand()
        { 
        }
        public override void Execute(object parameter)
        {
            if((int)parameter != -1)
                DatabaseManager.Delete("Identities", (int)parameter);
            IdentitiesViewModel.SelectedID = -1;
        }

    }
}
