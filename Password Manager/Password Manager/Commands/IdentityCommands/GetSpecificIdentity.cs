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
    public class GetSpecificIdentity : CommandBase
    {
        private IdentitiesViewModel viewModel;
        public GetSpecificIdentity(IdentitiesViewModel ivm)
        {
            viewModel = ivm;  
        }
        public override void Execute(object parameter)
        {
            IdentitiesModel identitiesModel = viewModel.IdentityCollection.Find(x => x.Id == (int)parameter);
            viewModel.Title = identitiesModel.Title;
            viewModel.Gender = identitiesModel.Gender;
            viewModel.FirstName = identitiesModel.FirstName;
            viewModel.LastName = identitiesModel.LastName;
            viewModel.Email = identitiesModel.Email;
            viewModel.FirstAddress = identitiesModel.FirstAddress;
            viewModel.SecondAddress = identitiesModel.SecondAddress;
            viewModel.ZIPCode = identitiesModel.ZIPCode;
            viewModel.City = identitiesModel.City;
            viewModel.Country = identitiesModel.Country;
            viewModel.Additional = identitiesModel.Additional;
            viewModel.Number = identitiesModel.Number;
            viewModel.Nickname = identitiesModel.Nickname;
            IdentitiesViewModel.SelectedID = (int)parameter;

        }

    }
}
