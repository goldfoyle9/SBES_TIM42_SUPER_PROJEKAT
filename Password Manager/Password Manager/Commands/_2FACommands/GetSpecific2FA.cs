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
    public class GetSpecific2FA : CommandBase
    {
        private _2FAViewModel viewModel;
        public GetSpecific2FA(_2FAViewModel cvm)
        {
            viewModel = cvm;  
        }
        public override void Execute(object parameter)
        {
            _2FAModel _2fa = viewModel._2FACollection.Find(x=>x.Id == (int)parameter);
            viewModel.Secret = _2fa.Secret;
            viewModel.Additional = _2fa.Additional;
            viewModel.Nickname = _2fa.Nickname;
            _2FAViewModel.SelectedID = (int)parameter;

        }

    }
}
