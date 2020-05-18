using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace lab10_var3
{
    class NoteModel
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public string Type { get; set; }
        public bool InCredit { get; set; }
        public string Description { get; set; }
    }


    class Repository
    {
        public static void Add(NoteModel note)
        {
            int inCredit = (note.InCredit) ? 1 : 0;

            DBHelper.NonQueryCommand($"INSERT INTO 'car' ('name', 'price', 'type', 'inCredit', description) VALUES ('{note.Name}', {note.Price}, '{note.Type}', {inCredit}, '{note.Description}');");
        }


        public static List<NoteModel> GetAllNotes()
        {
            var list = new List<NoteModel>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM 'car';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                var model = new NoteModel();

                model.Name        = record["name"].ToString();
                model.Price       = Int32.Parse(record["price"].ToString());
                model.Type        = record["type"].ToString();
                model.InCredit    = Boolean.Parse(record["inCredit"].ToString());
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
            var command = new SQLiteCommand("SELECT * FROM 'car';", connection);

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


        public static void UpdateByName(NoteModel note, string name)
        {
            // TODO: DBHelper.NonQueryCommand($"UPDATE 'car' name='{note.Name}', price='{note.Price}', type='{note.Type}', inCredit='{note.InCredit}', description='{note.Description}' WHERE name='{name}';");

            DeleteByName(name);
            Add(note);
        }

        
        public static NoteModel GetNote(string name)
        {

            var list = new List<string>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand($"SELECT * FROM 'car' WHERE name='{name}';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            var note = new NoteModel();

            foreach (DbDataRecord record in reader)
            {
                note.Name = record["name"].ToString();
                note.Price = Int32.Parse(record["price"].ToString());
                note.Type = record["type"].ToString();
                note.InCredit = (record["inCredit"].ToString() == "1") ? true : false;
                note.Description = record["description"].ToString();
            }

            return note;
        }


        public static void DeleteByName(string name)
        {
            DBHelper.NonQueryCommand($"DELETE FROM 'car' WHERE name='{name}'");
        }
    }
}
