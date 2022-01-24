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
            try
            {
                CardsModel card = viewModel.CardCollection.Find(x => x.Id == (int)parameter);
                viewModel.ExpirationDate = card.ExpirationDate;
                viewModel.Country = card.Country;
                viewModel.Additional = card.Additional;
                viewModel.Number = card.Number;
                viewModel.Nickname = card.Nickname;
                viewModel.IssuanceDate = card.IssuanceDate;
                viewModel.Name = card.Name;
                viewModel.Type = card.Type;
                CardsViewModel.SelectedID = (int)parameter;
            }
            catch (Exception ex)
            {

            }

        }

    }
}
