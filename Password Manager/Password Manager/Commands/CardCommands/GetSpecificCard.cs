using Common;
using Password_Manager.Models;
using Password_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.Commands.CardCommands
{
    public class GetSpecificCard : CommandBase
    {
        private CardsViewModel viewModel;
        public GetSpecificCard(CardsViewModel cvm)
        {
            viewModel = cvm;  
        }
        public override void Execute(object parameter)
        {
            int index = (int)parameter;
            viewModel.ExpirationDate = viewModel.CardCollection[index].ExpirationDate;
            viewModel.Country = viewModel.CardCollection[index].Country;
            viewModel.Additional = viewModel.CardCollection[index].Additional;
            viewModel.Number = viewModel.CardCollection[index].Number;
            viewModel.Nickname = viewModel.CardCollection[index].Nickname;
            viewModel.IssuanceDate = viewModel.CardCollection[index].IssuanceDate;
            viewModel.Name = viewModel.CardCollection[index].Name;
            viewModel.Type = viewModel.CardCollection[index].Type;

        }

    }
}
