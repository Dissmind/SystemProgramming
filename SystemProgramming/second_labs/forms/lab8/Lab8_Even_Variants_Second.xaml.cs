using System;
using System.Collections.Generic;
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

namespace SystemProgramming.second_labs.forms.lab8
{

    public class TableData
    {
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }
        public string C5 { get; set; }
        public string C6 { get; set; }
        public string C7 { get; set; }
        public string C8 { get; set; }
        public string C9 { get; set; }
        public string C10 { get; set; }
        

        public TableData(List<string> data)
        {
            this.C1 = data[0];
            this.C2 = data[1];
            this.C3 = data[2];
            this.C4 = data[3];
            this.C5 = data[4];
            this.C6 = data[5];
            this.C7 = data[6];
            this.C8 = data[7];
            this.C9 = data[8];
            this.C10 = data[9];
        }
    }


    /// <summary>
    /// Interaction logic for Lab8_Even_Variants_Second.xaml
    /// </summary>
    public partial class Lab8_Even_Variants_Second : Window
    {
        private static List<List<double>> Data;


        public Lab8_Even_Variants_Second()
        {
            InitializeComponent();

            Data = GeneratedTableData();

            AddColumns(ref Table, 4);
            AddRows(ref Table, 5);
        }

        private static void AddColumns(ref DataGrid Table, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Table.Columns.Add(new DataGridTextColumn
                {
                    Header = "",
                    Binding = new Binding("C" + (i + 1).ToString())
                });
            }
        }


        private static void AddRows(ref DataGrid Table, int count)
        {
            for (int i = 0; i < count; i++)
            {
                List<List<string>> strData = ListDoubleParseToString(Data);

                Table.Items.Add(new TableData(strData[i]));
            }
        }


        private static List<List<string>> ListDoubleParseToString(List<List<double>> dataList) 
        {
            var result = new List<List<string>>();

            for (int i = 0; i < dataList.Count; i++)
            {
                var stringRow = new List<string>();

                for (int j = 0; j < dataList[i].Count; j++)
                {
                    stringRow.Add(dataList[i][j].ToString());
                }

                result.Add(stringRow);
            }

            return result;
        }


        private static List<List<double>> GeneratedTableData()
        {
            var result = new List<List<double>>();

            for (int i = 0; i < 10; i++)
            {
                var list = new List<double>() 
                {
                    // TODO: randow double value
                    21.11, 20.11, 19.11, 18.11, 17.11, 16.11, 15.11, 14.11, 12.11, 11.11
                };

                result.Add(list);
            }

            return result;
        }
    }
}
