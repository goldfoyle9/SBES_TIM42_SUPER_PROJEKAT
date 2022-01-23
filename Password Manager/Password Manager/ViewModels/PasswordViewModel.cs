using Password_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        private IList<PasswordModel> _PasswordList;
        private string _value;
        private string nickname;
        private string website;
        private string username;
        private string additional;
        public string Value 
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
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

        public IList<PasswordModel> Passwords
        {
            get { return _PasswordList; }
            set { _PasswordList = value; }
        }
    }
}
