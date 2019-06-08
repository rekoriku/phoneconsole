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


        public string[] Parse(string message)
        {
            return message.Split(",");
        }

        public void AddRow(string[] arr)
        {
            Connect();
            string query = $"INSERT INTO ds19_phonenumbers (lastname, firstname, address, phonenumber) VALUES('{arr[1]}', '{arr[2]}', '{arr[3]}', '{arr[4]}'); ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Disconnect();
        }

        public void DelRow(string[] arr)
        {
            Connect();
            string query = $"DELETE FROM ds19_phonenumbers WHERE id={arr[1]}; ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Disconnect();
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

        public List<PhoneRecord> GetFromColumnByValue(string table_name, string column_name, string value)
        {
            List<PhoneRecord> records = new List<PhoneRecord>();
            try
            {
                Connect();
                string query = "SELECT * FROM " + table_name + " WHERE " + column_name + " = " + value;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    records.Add(new PhoneRecord((int)reader["id"], (string)reader["lastname"], (string)reader["firstname"], (string)reader["address"], (string)reader["phonenumber"]));
                }

                return records;
            }
            catch(Exception e)
            {
                //TODO: Handle exceptions and send error
                return records;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}