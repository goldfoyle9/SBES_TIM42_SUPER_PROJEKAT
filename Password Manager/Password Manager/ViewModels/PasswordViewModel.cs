using Common;
using Password_Manager.Commands.PasswordCommands;
using Password_Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Password_Manager.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        private ObservableCollection<PasswordModel> passwordCollection;
        private string password;
        private string nickname;
        private string website;
        private string username;
        private string additional;

        #region props
        public ObservableCollection<PasswordModel> PasswordCollection
        {
            get { return passwordCollection; }
            set
            { 
                passwordCollection = value;
            }
        }
        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Nickname 
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
                OnPropertyChanged("Nickname");
            }
        }
        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                website = value;
                OnPropertyChanged("Website");
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Additional
        {
            get
            {
                return additional;
            }
            set
            {
                additional = value;
                OnPropertyChanged("Additional");
            }
        }
        #endregion

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GetSpecificPassword { get; }

        public PasswordViewModel()
        {
            AddCommand = new AddPasswordCommand(this);
            GetSpecificPassword = new GetSpecificPassword(this);
            UpdateList();
        }

        public ObservableCollection<PasswordModel> passwordModels(Dictionary<int, string> getValues)
        {
            ObservableCollection<PasswordModel> retList = new ObservableCollection<PasswordModel>();
            
            foreach(int id in getValues.Keys)
            {
                retList.Add(PasswordModel.Deserialize(getValues[id], id));
            }

            return retList; 
        }

        public void UpdateList()
        {
            passwordCollection = passwordModels(DatabaseManager.Get("Passwords"));
        }
    }
}
