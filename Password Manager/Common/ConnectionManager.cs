using System;
using System.Collections.Generic;
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
            connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\minec\source\repos\SBES_TIM42_SUPER_PROJEKAT\Password Manager\Common\Database1.mdf; Integrated Security = True");
            connection.Open();
        }

       
    }
}
