using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SystemProgramming
{
    class FileHelper
    {
        public static string DirectoryPath = Directory.GetCurrentDirectory();

        public static void CreateOrUpdateFile(string content, string path, string fileName = "proccessed_text") 
        {
            fileName += ".txt";

            File.Create(DirectoryPath + fileName);

            using (FileStream fstream = new FileStream($"{DirectoryPath}\\{fileName}", FileMode.OpenOrCreate))
            {
                // parse to byte
                byte[] arr = System.Text.Encoding.Default.GetBytes(content);

                fstream.Write(arr, 0, arr.Length);
            }
        }

        public static string ReadFile(string path, string fileName = "proccessed_text")
        {
            fileName += ".txt";

            string content = "";

            using (FileStream fstream = File.OpenRead($"{DirectoryPath}\\{fileName}"))
            {
                byte[] arr = new byte[fstream.Length];

                fstream.Read(arr, 0, arr.Length);

                // parse to string
                content = System.Text.Encoding.Default.GetString(arr);
            }

            return content;
        }
    }
}
