using Common;
using Password_Manager.Commands.CardCommands;
using Password_Manager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Password_Manager.ViewModels
{
    public class CardsViewModel : BaseViewModel 
    {
        #region fields
        private string nickname;
        private string name;
        private string number;
        private string type;
        private string country;
        private string issuanceDate;
        private string expirationDate;
        private string additional;
        #endregion
        #region props
        public ObservableCollection<CardsModel> CardCollection { get; set; }
        public string Nickname { get { return nickname; } set { nickname = value; OnPropertyChanged("Nickname"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Number { get { return number; } set { number= value; OnPropertyChanged("Number"); } }
        public string Type { get { return type; } set { type = value; OnPropertyChanged("Type"); } }
        public string IssuanceDate { get { return issuanceDate; } set { issuanceDate= value; OnPropertyChanged("IssuanceDate"); } }
        public string ExpirationDate { get { return expirationDate; } set { expirationDate= value; OnPropertyChanged("ExpirationDate"); } }
        public string Country { get { return country; } set { country = value; OnPropertyChanged("Country"); } }
        public string Additional { get { return additional; } set { additional = value; OnPropertyChanged("Additional"); } }

        #endregion

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GetSpecificCard { get; }

        public CardsViewModel()
        {
            AddCommand = new AddCardCommand(this);
            GetSpecificCard = new GetSpecificCard(this);
            UpdateList();
        }

        public ObservableCollection<CardsModel> cardModels(Dictionary<int, string> getValues)
        {
            ObservableCollection<CardsModel> retList = new ObservableCollection<CardsModel>();

            foreach (int id in getValues.Keys)
            {
                retList.Add(CardsModel.Deserialize(getValues[id], id));
            }

            return retList;
        }
        public void UpdateList()
        {
            CardCollection = cardModels(DatabaseManager.Get("Cards"));
        }

    }
}
