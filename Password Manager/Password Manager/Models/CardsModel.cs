using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Models
{
    public class CardsModel
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
        private int id;
        #endregion
        #region props

        public string Nickname { get => nickname; set => nickname = value; }
        public string Name { get => name; set => name = value; }
        public string Number { get => number; set => number = value; }
        public string Type { get => type; set => type = value; }
        public string Country { get => country; set => country = value; }
        public string IssuanceDate { get => issuanceDate; set => issuanceDate = value; }
        public string ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string Additional { get => additional; set => additional = value; }
        public int Id { get => id; set => id = value; }


        #endregion
        public CardsModel()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Nickname);
            sb.Append("|");
            sb.Append(Name);
            sb.Append("|");
            sb.Append(Number);
            sb.Append("|");
            sb.Append(Type);
            sb.Append('|');
            sb.Append(Country);
            sb.Append("|");
            sb.Append(IssuanceDate);
            sb.Append("|");
            sb.Append(ExpirationDate);
            sb.Append("|");
            sb.Append(Additional);

            return sb.ToString();
        }

        public static CardsModel Deserialize(string value, int id)
        {
            CardsModel model = new CardsModel();
            string[] array = value.Split('|');
            model.Nickname = array[0];
            model.Name = array[1];
            model.Number = array[2];
            model.Type = array[3];
            model.Country = array[4];
            model.IssuanceDate = array[5];
            model.ExpirationDate = array[6];
            model.Additional = array[7];
            model.Id = id;
            return model;
        }
    }
}
