using Common;
using Password_Manager.Models;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.Commands.IdentityCommands
{
    public class AddIdentityCommand : CommandBase
    {
        private IdentitiesViewModel viewModel;
        public AddIdentityCommand(IdentitiesViewModel ivm)
        {
            viewModel = ivm;  
        }
        public override void Execute(object parameter)
        {
            IdentitiesModel model = new IdentitiesModel();
            model.Additional = viewModel.Additional;
            model.FirstAddress = viewModel.FirstAddress;
            model.Email = viewModel.Email;
            model.Country = viewModel.Country;
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;    
            model.Gender = viewModel.Gender;
            model.ZIPCode = viewModel.ZIPCode;
            model.City = viewModel.City;
            model.Nickname = viewModel.Nickname;
            model.Number = viewModel.Number;
            model.SecondAddress = viewModel.SecondAddress;
            model.Title = viewModel.Title;

            if (IdentitiesViewModel.SelectedID == -1)
                DatabaseManager.Add(model.ToString(), viewModel.FindFirstId(), "Identities", false);
            else
                DatabaseManager.Add(model.ToString(), IdentitiesViewModel.SelectedID, "Identities", true);
            IdentitiesViewModel.SelectedID = -1;
        }

    }
}
