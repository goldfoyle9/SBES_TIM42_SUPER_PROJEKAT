using Common;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Commands._2FACommands
{
    public class Delete2FACommand : CommandBase
    {
        public Delete2FACommand()
        { 
        }
        public override void Execute(object parameter)
        {
            if((int)parameter != -1)
                DatabaseManager.Delete("_2FA", (int)parameter);
            _2FAViewModel.SelectedID = -1;
        }

    }
}
