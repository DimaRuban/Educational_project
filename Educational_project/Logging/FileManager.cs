using StorePhone.Сontracts;
using System;
using System.IO;
using System.Text;

namespace StorePhone.Logging
{
    public class FileManager : IFileManager
    {
        private char pathSeparator = Path.DirectorySeparatorChar;

        private string GetDirectoryPath()
        {
            return Directory.GetCurrentDirectory() + pathSeparator + "Store Phone system files";
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

            var filePath = GetDirectoryPath() + pathSeparator + DateTime.Now.ToShortDateString() + ".txt";

            if (!File.Exists(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate)) { }
            }
        }

        public void WorkWithFiles(string message)
        {
            CreateFile();

            var filePath = GetDirectoryPath() + pathSeparator + DateTime.Now.ToShortDateString() + ".txt";

            using (var streamWriter = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }

        public void WorkWithSerializationFile(string message, string serializationPath)
        {
            var serializationProductsPath = GetDirectoryPath() + pathSeparator + serializationPath;

            if (!File.Exists(serializationProductsPath))
                using (var fileStream = new FileStream(serializationProductsPath, FileMode.OpenOrCreate)) { }

            using (var streamWriter = new StreamWriter(serializationProductsPath, false, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}