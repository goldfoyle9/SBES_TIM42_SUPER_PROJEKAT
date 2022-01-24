using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Models
{
    public class IdentitiesModel
    {
        #region fields
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
        private int id;
        #endregion

        public IdentitiesModel()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Nickname);
            sb.Append("|");
            sb.Append(Title);
            sb.Append("|");
            sb.Append(Gender);
            sb.Append("|");
            sb.Append(FirstName);
            sb.Append("|");
            sb.Append(LastName);
            sb.Append("|");
            sb.Append(Email);
            sb.Append("|");
            sb.Append(Number);
            sb.Append("|");
            sb.Append(FirstAddress);
            sb.Append("|");
            sb.Append(SecondAddress);
            sb.Append("|");
            sb.Append(ZIPCode);
            sb.Append("|");
            sb.Append(City);
            sb.Append("|");
            sb.Append(Country);
            sb.Append("|");
            sb.Append(Additional);

            return sb.ToString();
        }
        #region props
        public string Nickname { get => nickname; set => nickname = value; }
        public string Title { get => title; set => title = value; }
        public string Gender { get => gender; set => gender = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Number { get => number; set => number = value; }
        public string FirstAddress { get => firstAddress; set => firstAddress = value; }
        public string SecondAddress { get => secondAddress; set => secondAddress = value; }
        public string ZIPCode { get => zIPCode; set => zIPCode = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Additional { get => additional; set => additional = value; }
        public int Id { get => id; set => id = value; }
        #endregion
        public static IdentitiesModel Deserialize(string value, int id)
        {
            if (value == "")
                return null;
            IdentitiesModel model = new IdentitiesModel();
            string[] array = value.Split('|');
            model.Nickname = array[0];
            model.Title = array[1];
            model.Gender = array[2];
            model.FirstName = array[3];
            model.LastName = array[4];
            model.Email = array[5];
            model.Number = array[6];
            model.FirstAddress = array[7];
            model.SecondAddress = array[8];
            model.ZIPCode = array[9];
            model.City = array[10];
            model.Country = array[11];
            model.Additional = array[12];
            model.Id = id;
            return model;
        }
    }
}
