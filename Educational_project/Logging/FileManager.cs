using System;
using System.IO;

using System.Text;

namespace StorePhone.Logging
{
    public static class FileManager
    {      
        private static string GetDirectoryPath()
        {
            return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Store Phone system files";
        }

        public static string GetProductsPath()
        {
            return GetDirectoryPath() + Path.DirectorySeparatorChar + "Serialization Products.txt";
        }

        public static string GetOrdersPath()
        {
            return GetDirectoryPath() + Path.DirectorySeparatorChar + "Serialization Orders.txt";
        }

        public static string GetUsersPath()
        {
            return GetDirectoryPath() + Path.DirectorySeparatorChar + "Serialization Users.txt";
        }

        private static void CreateFolder()
        {
            if (!Directory.Exists(GetDirectoryPath()))
            {
                Directory.CreateDirectory(GetDirectoryPath());
            }
        }

        private static void CreateFile()
        {
            CreateFolder();

            var filePath = GetDirectoryPath() + Path.DirectorySeparatorChar + DateTime.Now.ToShortDateString() + ".txt";

            if (!File.Exists(filePath))
            {
                using var file = new FileStream(filePath, FileMode.Create);
            }
        }

        public static void Write(string message)
        {
            CreateFile();

            var filePath = GetDirectoryPath() + Path.DirectorySeparatorChar + DateTime.Now.ToShortDateString() + ".txt";

            using var stream = new StreamWriter(filePath, false, Encoding.UTF8);
            stream.WriteLine(message);
        }

        public static void Write(string message, string path)
        {
            using var stream = new StreamWriter(path, false, Encoding.UTF8);
            stream.WriteLine(message);
        }
    }
}