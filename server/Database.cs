using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace server
{
    class Database
    {
        string serverIp = "<Server IP or Hostname>";
        string username = "<DB username>";
        string password = "<DB password>";
        string databaseName = "<DB name>";
        public Database()
        {
           
        }
        

        string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
        string query = "SELECT * FROM YourTable";

        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
        conn.Open();
 
MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

 
while (reader.Read())
{
 someValue = reader["SomeColumnName"];

        // Do something with someValue
    }
}

