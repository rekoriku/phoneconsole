﻿using System;
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

        public int AddRow(string message)
        {
            string[] arr = Parse(message);
            Connect();
            string query = $"INSERT INTO ds19_phonenumbers (lastname, firstname, address, phonenumber) VALUES('{arr[1]}', '{arr[2]}', '{arr[3]}', '{arr[4]}'); ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            Disconnect();
            return result;
        }

        public int DelRow(string message)
        {
            string[] arr = Parse(message);
            Connect();
            string query = $"DELETE FROM ds19_phonenumbers WHERE id={arr[1]}; "; //comment
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            Disconnect();
            return result;
        }
        public List<PhoneRecord> GetAllEntries(string table_name)
        {
            List<PhoneRecord> records = new List<PhoneRecord>();
            try
            {
                Connect();
                string query = "SELECT * FROM " + table_name;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    records.Add(new PhoneRecord((int)reader["id"], (string)reader["lastname"], (string)reader["firstname"], (string)reader["address"], (string)reader["phonenumber"]));
                }

                return records;
            }
            finally
            {
                Disconnect();
            }
        }

        public List<PhoneRecord> GetFromColumnByValue(string table_name, string column_name, string value)
        {
            List<PhoneRecord> records = new List<PhoneRecord>();
            try
            {
                Connect();
                string query = "SELECT * FROM " + table_name + " WHERE " + column_name + " = '" + value + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    records.Add(new PhoneRecord((int)reader["id"], (string)reader["lastname"], (string)reader["firstname"], (string)reader["address"], (string)reader["phonenumber"]));
                }

                return records;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
