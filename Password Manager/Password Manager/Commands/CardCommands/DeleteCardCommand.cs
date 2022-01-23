using Common;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Commands.CardCommands
{
    public class DeleteCardCommand : CommandBase
    {
        public DeleteCardCommand()
        { 
        }
        public override void Execute(object parameter)
        {
            if((int)parameter != -1)
                DatabaseManager.Delete("Cards", (int)parameter);
            CardsViewModel.SelectedID = -1;
        }

    }
}
