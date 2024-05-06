using MySql.Data.MySqlClient;
using System;

namespace HealthCare_System
{
    public static class DatabaseConnection
    {
        private static MySqlConnection conn;

        // Connection String
        private static string connectionString = "SERVER = localhost; DATABASE = healthcare_db; UID = root; PASSWORD = 1234;";

        static DatabaseConnection()
        {
            conn = new MySqlConnection(connectionString);
        }

        public static bool Connection()
        {
            try
            {
                conn.Open();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public static MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}
