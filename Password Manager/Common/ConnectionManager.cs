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
        private SqlConnection connection;
        public SqlConnection Connection { get { return connection; } }
        public ConnectionManager()
        {
            connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\HP\Desktop\clonesbes\Password Manager\Common\Database1.mdf; Integrated Security = True");
            connection.Open();
        }
    }
}
