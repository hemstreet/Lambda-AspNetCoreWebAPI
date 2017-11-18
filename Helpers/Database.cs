using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AspNetCoreWebAPI.Helpers
{
    public class Database
    {

        private string DbUrl = Environment.GetEnvironmentVariable("DbUrl");
        private string DbUser = Environment.GetEnvironmentVariable("DbUser");
        private string DbPassword = Environment.GetEnvironmentVariable("DbPassword");
        private string DbPort = Environment.GetEnvironmentVariable("DbPort");
        private string DbName = Environment.GetEnvironmentVariable("DbName");
        
        private string GetConnectionString()
        {
            // https://www.connectionstrings.com/
            var connectionString = $"Server={DbUrl},{DbPort};" +
                                   $"Database={DbName};" +
                                   $"User ID={DbUser};" +
                                   $"Password={DbPassword};";
            
            return connectionString;
        }

        private SqlConnection ConnectToDatabase(string connectionString)
        {   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {   
                return connection;
            }
            
        }

        public SqlDataReader query(string query)
        {

            var connectionString = GetConnectionString();
            var connection = ConnectToDatabase(connectionString);

            try
            {

                connection.Open();
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    connection.Close();

                    return reader;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                connection.Close();
                throw;
            }
        }
    }
}