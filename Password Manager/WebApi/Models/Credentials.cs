using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public static Credentials Deserialize(string value, int id, string website)
        {
            if (value == "")
                return null;
            Credentials model = new Credentials();
            string[] array = value.Split('|');
            model.Password = array[0];
            model.Website = array[2];
            model.Username = array[3];

            if (model.Website.Contains(website))
            {
                return model;
            }
            else
            {
                return null;
            }
            
        }
    }
}
