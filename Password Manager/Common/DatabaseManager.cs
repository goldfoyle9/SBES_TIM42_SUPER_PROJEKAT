using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DatabaseManager
    {
   

        public static bool Add(string data, int id, string tableName, bool update)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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
                if (value == null) return false;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@data", value);
                    command.ExecuteNonQuery();

                }
            }
            return true;
        }

        public static Dictionary<int, string> Get(string tableName, string connString)
        {

            string query = $"SELECT * from {tableName}";
            Dictionary<int, string> returnDictionary = new Dictionary<int, string>();
            string connectionString = null;
            if(connString == "") {
                connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            }
            if(connectionString == null)
            {
                connectionString = connString;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnDictionary.Add((int)reader[0], EncryptionManager.DecryptStringFromBytes_Aes((byte[])reader[1]));
                        }

                    }
                }
    
            }
            return returnDictionary;
        }

        public static void Delete(string tableName, int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            string query = $"DELETE FROM {tableName} WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                
            }
            return;

        }

        public static void DeleteAll()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Cards;DELETE FROM Identities;DELETE FROM _2FA;DELETE FROM Passwords";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

    }
}
