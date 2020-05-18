using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace lab10_var3
{
    class MedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }


    class Repository
    {
        public static void Add(MedModel med)
        {

            DBHelper.NonQueryCommand($"INSERT INTO 'med' ('id', 'name', 'adress', 'type', 'description') VALUES ('{med.Id}', '{med.Name}', '{med.Adress}', '{med.Type}', '{med.Description}');");
        }


        public static List<MedModel> GetAllMeds()
        {
            var list = new List<MedModel>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM 'med';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                var model = new MedModel();

                model.Id          = Int32.Parse(record["id"].ToString());
                model.Name        = record["name"].ToString();
                model.Adress      = record["adress"].ToString();
                model.Type        = record["type"].ToString();
                model.Description = record["description"].ToString();

                list.Add(model);
            }

            return list;
        }

        
        public static List<string> GetAllName()
        {
            var list = new List<string>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM 'med';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            try
            {
                foreach (DbDataRecord record in reader)
                {
                    list.Add(record["name"].ToString());
                }
            }
            catch
            {
                return list;
            }

            return list;
        }


        public static void UpdateByName(MedModel med, string name)
        {
            DeleteByName(med.Name);
            Add(med);
        }

        public static List<string> GetAllId()
        {
            var list = new List<string>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM 'med';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            try
            {
                foreach (DbDataRecord record in reader)
                {
                    list.Add(record["id"].ToString());
                }
            }
            catch
            {
                return list;
            }

            return list;
        }


        public static MedModel GetMed(string name)
        {

            var list = new List<string>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand($"SELECT * FROM 'med' WHERE name='{name}';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            var model = new MedModel();

            foreach (DbDataRecord record in reader)
            {
                model.Id = Int32.Parse(record["id"].ToString());
                model.Name = record["name"].ToString();
                model.Adress = record["adress"].ToString();
                model.Type = record["type"].ToString();
                model.Description = record["description"].ToString();
            }

            return model;
        }


        public static void DeleteByName(string name)
        {
            DBHelper.NonQueryCommand($"DELETE FROM 'med' WHERE name='{name}'");
        }
    }
}
