using lab10_var3;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemProgramming.second_labs.forms.lab10
{
    /// <summary>
    /// Interaction logic for Lab10.xaml
    /// </summary>
    public partial class Lab10 : Window
    {
        public Lab10()
        {
            InitializeComponent();

            DBHelper.CreateDB();
        }


        private void Button_Click_OpenAdd(object sender, RoutedEventArgs e)
        {
            var window = new AddNote();
            window.ShowDialog();
        }


        private void Button_Click_EditNote(object sender, RoutedEventArgs e)
        {
            if (Repository.GetAllName().Count == 0)
            {
                MessageBox.Show("В базе не найденно не одной записи");
                return;
            }

            var window = new UpdateNote();
            window.ShowDialog();
        }


        private void Button_Click_StructDB(object sender, RoutedEventArgs e)
        {
            // TODO

            var list = new List<string>();

            var connection = new SQLiteConnection(string.Format("Data Source={0};", DBHelper.DatabaseName));

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM 'car';", connection);

            SQLiteDataReader reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                Debug.WriteLine("Name: " + record["name"].ToString());
                Debug.WriteLine("Price: " + record["price"].ToString());
                Debug.WriteLine("Type: " + record["type"].ToString());
                Debug.WriteLine("InCredit: " + record["inCredit"].ToString());
                Debug.WriteLine("Description: " + record["description"].ToString());

                Debug.WriteLine("*************");
            }
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
