using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Models
{
    public class PasswordModel
    {
        public PasswordModel(string value, string nickname, string website, string username, string additional)
        {
            Value = value;
            Nickname = nickname;
            Website = website;
            Username = username;
            Additional = additional;
        }

        public string Value { get; private set; }
        public string Nickname { get; private set; }
        public string Website { get; private set; }
        public string Username { get; private set; }
        public string Additional { get; private set; }
     
    }
}
