using StorePhone.Сontracts;
using System;
using System.IO;
using System.Text;

namespace StorePhone.Logging
{
    public class FileManager : IFileManager
    {
        private char _pathSeparator = Path.DirectorySeparatorChar;

        private string GetDirectoryPath()
        {
            return Directory.GetCurrentDirectory() + _pathSeparator + "Store Phone system files";
        }

        private void CreateFolder()
        {
            if (!Directory.Exists(GetDirectoryPath()))
            {
                Directory.CreateDirectory(GetDirectoryPath());
            }
        }

        private void CreateFile()
        {
            CreateFolder();

            var filePath = GetDirectoryPath() + _pathSeparator + DateTime.Now.ToShortDateString() + ".txt";

            if (!File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate)) { }
            }
        }

        public void WorkWithFiles(string message)
        {
            CreateFile();

            var filePath = GetDirectoryPath() + _pathSeparator + DateTime.Now.ToShortDateString() + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }

        public void WorkWithSerializationFileProducts(string message)
        {
            var serializationProductsPath = GetDirectoryPath() + _pathSeparator + "Serialization Products.txt";

            if (File.Exists(serializationProductsPath))
                File.Delete(serializationProductsPath);

            if (!File.Exists(serializationProductsPath))
                using (FileStream fstream = new FileStream(serializationProductsPath, FileMode.OpenOrCreate)) { }

            using (StreamWriter streamWriter = new StreamWriter(serializationProductsPath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
        public void WorkWithSerializationFileOrders(string message)
        {
            var serializationOrdersPath = GetDirectoryPath() + _pathSeparator + "Serialization Orders.txt";

            if (File.Exists(serializationOrdersPath))
                File.Delete(serializationOrdersPath);

            if (!File.Exists(serializationOrdersPath))
                using (FileStream fstream = new FileStream(serializationOrdersPath, FileMode.OpenOrCreate)) { }

            using (StreamWriter streamWriter = new StreamWriter(serializationOrdersPath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
        public void WorkWithSerializationFileUsers(string message)
        {
            var serializationUsersPath = GetDirectoryPath() + _pathSeparator + "Serialization Users.txt";

            if (File.Exists(serializationUsersPath))
                File.Delete(serializationUsersPath);

            if (!File.Exists(serializationUsersPath))
                using (FileStream fstream = new FileStream(serializationUsersPath, FileMode.OpenOrCreate)) { }

            using (StreamWriter streamWriter = new StreamWriter(serializationUsersPath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}