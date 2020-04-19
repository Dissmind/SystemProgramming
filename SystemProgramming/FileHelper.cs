using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SystemProgramming
{
    class FileHelper
    {
        private static string Path = Directory.GetCurrentDirectory();

        public static void CreateOrUpdateFile(string content, string fileName = "proccessed_text") 
        {
            fileName += ".txt";

            File.Create(Path + fileName);

            using (FileStream fstream = new FileStream($"{Path}\\{fileName}", FileMode.OpenOrCreate))
            {
                // parse to byte
                byte[] arr = System.Text.Encoding.Default.GetBytes(content);

                fstream.Write(arr, 0, arr.Length);
            }
        }
    }
}
