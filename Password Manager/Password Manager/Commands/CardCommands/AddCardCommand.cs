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
    public class AddCardCommand : CommandBase
    {
        private CardsViewModel viewModel;
        private static int i = 0;
        public AddCardCommand(CardsViewModel cvm)
        {
            viewModel = cvm;  
        }
        public override void Execute(object parameter)
        {
            CardsModel model = new CardsModel();
            model.Additional = viewModel.Additional;
            model.Country = viewModel.Country;
            model.Nickname = viewModel.Nickname;
            model.Number = viewModel.Number;
            model.Type = viewModel.Type;
            model.IssuanceDate = viewModel.IssuanceDate;
            model.ExpirationDate = viewModel.ExpirationDate;
            model.Name = viewModel.Name;
            DatabaseManager.Add(model.ToString(), i++, "Cards", false);
        }

    }
}
