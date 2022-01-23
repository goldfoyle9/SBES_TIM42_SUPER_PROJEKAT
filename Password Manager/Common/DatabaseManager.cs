using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DatabaseManager
    {
   

        public static void Add(string data, int id, string tableName, bool update)
        {
            string query = "";
            if (!update)
            {
                query = $"INSERT into {tableName} (id, value) VALUES (@id, @data);";
            }
            else
            {
                query = $"UPDATE {tableName}  SET id = @id, VALUE = @data WHERE id = @id";
            }
            byte[] value = EncryptionManager.EncryptStringToBytes_Aes(data);
          
            using (SqlCommand command = new SqlCommand(query, ConnectionManager.Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@data", value);
                command.ExecuteNonQuery();

            }
        }

        public static Tuple<int, string> GetOne(int id, string tableName)
        {
            string query = $"SELECT * from {tableName} where id = @id";
            Dictionary<int, string> returnDictionary = new Dictionary<int, string>();
            using (SqlCommand command = new SqlCommand(query, ConnectionManager.Connection))
            {
                command.Parameters.AddWithValue("@tb", tableName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tuple<int, string>((int)reader[0], EncryptionManager.DecryptStringFromBytes_Aes((byte[])reader[1]));

                    }
                }
            }
            return null;
        }

        public static Dictionary<int, string> Get(string tableName)
        {
            string query = $"SELECT * from {tableName}";
            Dictionary<int, string> returnDictionary = new Dictionary<int, string>();
            using (SqlCommand command = new SqlCommand(query, ConnectionManager.Connection))
            {
       
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnDictionary.Add((int)reader[0], EncryptionManager.DecryptStringFromBytes_Aes((byte[])reader[1]));
                    }
                    
                }
            }
            return returnDictionary;
        }

    }
}
