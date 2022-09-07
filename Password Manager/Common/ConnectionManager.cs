using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConnectionManager
    {
        private static SqlConnection connection;
        public static SqlConnection Connection { get { return connection; } }

       
        public ConnectionManager()
        {
            
        }
 
        public static void Close()
        {
            connection.Close();
        }

        public static void Open()
        {
            connection.Open();
        }
    }
}
