using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace lab10_var3
{
    class DBHelper
    {
        public static string DatabaseName = Environment.CurrentDirectory + "data.db";


        public static void CreateDB()
        {
           

            if (!File.Exists(DatabaseName))
            {
                SQLiteConnection.CreateFile(DatabaseName);

                var connection = new SQLiteConnection(string.Format("Data Source={0};", DatabaseName));
                var command = new SQLiteCommand("CREATE TABLE car (name TEXT PRIMARY KEY, price INTEGER, type TEXT, inCredit INTEGER, description TEXT);", connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public static void NonQueryCommand(string query)
        {
            // Example query: "INSERT INTO 'test' ('name', 'price', 'type', 'inCredit', description) VALUES ('BMW', '123', 'light', 0, 'desc');"

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DatabaseName));

            var command = new SQLiteCommand(query, connection);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
