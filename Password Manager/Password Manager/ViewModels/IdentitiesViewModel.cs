﻿using Common;
using Password_Manager.Commands.IdentityCommands;
using Password_Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.ViewModels
{
    public class IdentitiesViewModel : BaseViewModel
    {
        private string nickname;
        private string title;
        private string gender;
        private string firstName;
        private string lastName;
        private string email;
        private string number;
        private string firstAddress;
        private string secondAddress;
        private string zIPCode;
        private string city;
        private string country;
        private string additional;

        #region props
        public ObservableCollection<IdentitiesModel> IdentityCollection { get; set; }
        public string Nickname { get { return nickname; } set { nickname = value; OnPropertyChanged("Nickname"); } }
        public string Title { get { return title; } set { title = value; OnPropertyChanged("Title"); } }
        public string Gender { get { return gender; } set { gender = value; OnPropertyChanged("Gender"); } }
        public string FirstName { get { return firstName; } set { firstName = value; OnPropertyChanged("FirstName"); } }
        public string LastName { get { return lastName; } set { lastName = value; OnPropertyChanged("LastName"); } }
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public string Number { get { return number; } set { number = value; OnPropertyChanged("Number"); } }
        public string FirstAddress { get { return firstAddress; } set { firstAddress = value; OnPropertyChanged("FirstAddress"); } }
        public string SecondAddress { get { return secondAddress; } set { secondAddress = value; OnPropertyChanged("SecondAddress"); } }
        public string ZIPCode { get { return zIPCode; } set { zIPCode = value; OnPropertyChanged("ZIPCode"); } }
        public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }
        public string Country { get { return country; } set { country = value; OnPropertyChanged("Country"); } }
        public string Additional { get { return additional; } set { additional = value; OnPropertyChanged("Additional"); } }

        #endregion

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GetSpecificIdentity { get; }

        public IdentitiesViewModel()
        {
            AddCommand = new AddIdentityCommand(this);
            GetSpecificIdentity = new GetSpecificIdentity(this);
            UpdateList();
        }

        public ObservableCollection<IdentitiesModel> identityModels(Dictionary<int, string> getValues)
        {
            ObservableCollection<IdentitiesModel> retList = new ObservableCollection<IdentitiesModel>();

            foreach (int id in getValues.Keys)
            {
                retList.Add(IdentitiesModel.Deserialize(getValues[id], id));
            }

            return retList;
        }
        public void UpdateList()
        {
            IdentityCollection = identityModels(DatabaseManager.Get("Identities"));
        }

    }
}
