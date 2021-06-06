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
    }
}