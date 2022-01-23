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
            int index = (int)parameter;
            viewModel.Title = viewModel.IdentityCollection[index].Title;
            viewModel.Gender = viewModel.IdentityCollection[index].Gender;
            viewModel.FirstName = viewModel.IdentityCollection[index].FirstName;
            viewModel.LastName = viewModel.IdentityCollection[index].LastName;
            viewModel.Email = viewModel.IdentityCollection[index].Email;
            viewModel.FirstAddress = viewModel.IdentityCollection[index].FirstAddress;
            viewModel.SecondAddress = viewModel.IdentityCollection[index].SecondAddress;
            viewModel.ZIPCode = viewModel.IdentityCollection[index].ZIPCode;
            viewModel.City = viewModel.IdentityCollection[index].City;
            viewModel.Country = viewModel.IdentityCollection[index].Country;
            viewModel.Additional = viewModel.IdentityCollection[index].Additional;
            viewModel.Number = viewModel.IdentityCollection[index].Number;
            viewModel.Nickname = viewModel.IdentityCollection[index].Nickname;

        }

    }
}
