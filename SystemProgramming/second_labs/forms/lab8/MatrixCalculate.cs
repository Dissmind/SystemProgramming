using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace SystemProgramming.second_labs.forms.lab8
{
    class MatrixCalculate
    {




        #region Variant 18

        public static double f(List<List<double>> Data, int RowSize, int ColumnSize)
        {
            Data = UpdataDataTableSize(Data, RowSize, ColumnSize);

            List<double> DataAboveMainDiagonal = GetDataAboveMainDiagonal(Data)
                    .Where(item => Math.Round(item, 0) % 2 == 0).ToList();

            if (DataAboveMainDiagonal.Count == 0)
            {
                Debug.WriteLine("Нету четных чисел");
                return -1;
            }

            double result = DataAboveMainDiagonal[0];

            for (int i = 1; i < DataAboveMainDiagonal.Count; i++)
            {
                result -= DataAboveMainDiagonal[i];
            }

            Debug.WriteLine("Ответ: " + ((result > 0) ? result : result * -1).ToString());

            return (result > 0)? result : result * -1;
        }


        private static List<double> GetDataAboveMainDiagonal(List<List<double>> Data)
        {
            var result = new List<double>();

            for (int i = 0; i < Data.Count; i++)
            {
                for (int j = 0; j < Data[i].Count; j++)
                {
                    if (i < j)
                    {
                        result.Add(Data[i][j]);
                    }
                }
            }

            return result;
        }

        #endregion

        private static List<List<double>> UpdataDataTableSize(List<List<double>> Data, int RowSize, int ColumnSize)
        {
            var result = new List<List<double>>();


            Debug.WriteLine("Data: ");
            Debug.WriteLine("===========================");
            foreach (var i in Data)
            {
                foreach (var j in i)
                {
                    Debug.Write(j + " ");
                }

                Debug.WriteLine("");
            }
            Debug.WriteLine("===========================");

            for (int i = 0; i < RowSize; i++)
            {
                var Row = new List<double>();

                for (int j = 0; j < ColumnSize; j++)
                {
                    Row.Add(Data[i][j]);
                }

                result.Add(Row);
            }
            Debug.WriteLine("NewData: ");
            Debug.WriteLine("===========================");
            for (int i = 0; i < Data.Count; i++)
            {
                for (int j = 0; j < Data[i].Count; j++)
                {
                    Debug.Write(Data[i] + " ");
                }

                Debug.WriteLine("");
            }
            Debug.WriteLine("===========================");

            return result;
        }
    }
}
