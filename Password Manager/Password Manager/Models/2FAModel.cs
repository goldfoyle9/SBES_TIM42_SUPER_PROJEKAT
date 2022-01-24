using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.Models
{
    public class _2FAModel
    {
        #region fields
        private string nickname;
        private string secret;
        private string additional;
        private int id;
        #endregion
        #region props

        public string Nickname { get => nickname; set => nickname = value; }
        public string Secret { get => secret; set => secret = value; }
        public string Additional { get => additional; set => additional = value; }
        public int Id { get => id; set => id = value; }


        #endregion
        public _2FAModel()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Nickname);
            sb.Append("|");
            sb.Append(Secret);
            sb.Append("|");
            sb.Append(Additional);

            return sb.ToString();
        }

        public static _2FAModel Deserialize(string value, int id)
        {
            _2FAModel model = new _2FAModel();
            string[] array = value.Split('|');
            model.Nickname = array[0];
            model.Secret = array[1];
            model.Additional = array[2];
            model.Id = id;
            return model;
        }
    }
}
