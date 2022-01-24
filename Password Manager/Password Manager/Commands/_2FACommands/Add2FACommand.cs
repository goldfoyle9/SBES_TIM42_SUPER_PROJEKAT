using Common;
using Password_Manager.Models;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.Commands._2FACommands
{
    public class Add2FACommand : CommandBase
    {
        private _2FAViewModel viewModel;
        private static int i = 0;
        public Add2FACommand(_2FAViewModel cvm)
        {
            viewModel = cvm;  
        }
        public override void Execute(object parameter)
        {
            _2FAModel model = new _2FAModel();
            model.Additional = viewModel.Additional;
            model.Nickname = viewModel.Nickname;
            model.Secret = viewModel.Secret;

            if (CardsViewModel.SelectedID == -1)
                DatabaseManager.Add(model.ToString(), viewModel.FindFirstId(), "_2FA", false);
            else
                DatabaseManager.Add(model.ToString(), _2FAViewModel.SelectedID, "_2FA", true);
            _2FAViewModel.SelectedID = -1;
        }

    }
}
