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

        public int Id { get; private set; }
        public string Value { get; private set; }
        public string Nickname { get; private set; }
        public string Website { get; private set; }
        public string Username { get; private set; }
        public string Additional { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Value);
            sb.Append("|");
            sb.Append(Nickname);
            sb.Append("|");
            sb.Append(Website);
            sb.Append("|");
            sb.Append(Username);
            sb.Append("|");
            sb.Append(Additional);
            return sb.ToString();
        }

        public PasswordModel()
        {

        }


        public static PasswordModel Deserialize(string value, int id)
        {
            if (value == "")
                return null;
            PasswordModel model = new PasswordModel();
            string[] array = value.Split('|');
            model.Value = array[0];
            model.Nickname = array[1];
            model.Website = array[2];
            model.Username = array[3];
            model.Additional = array[4];
            model.Id = id;
            return model;
        }

    }
}
