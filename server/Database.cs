using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace server
{
    class Database
    {
        string serverIp;
        string username;
        string password;
        string databaseName;
        MySqlConnection conn;

        public Database(string serverIp, string username, string password, string databaseName)
        {
            this.serverIp = serverIp;
            this.username = username;
            this.password = password;
            this.databaseName = databaseName;
        }

        private void Connect()
        {
            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            conn = new MySqlConnection(dbConnectionString);
            conn.Open();
        }

        private void Disconnect()
        {
            conn.Close();
        }

        public void GetAllEntries(string table_name)
        {
            Connect();
            string query = "SELECT * FROM " + table_name;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["firstname"]);
            }
            Disconnect();
        }
    }
}