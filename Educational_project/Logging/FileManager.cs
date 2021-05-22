using StorePhone.Сontracts;
using System;
using System.IO;
using System.Text;

namespace StorePhone.Logging
{
    public class FileManager : IFileManager
    {
        private void CreatFolder()
        {
            string path = Directory.GetCurrentDirectory() + "\\Store Phone system files";

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        private void CreatFile()
        {
            CreatFolder();

            string path = Directory.GetCurrentDirectory() + "\\Store Phone system files";

            string pathFile = path + "\\" + DateTime.Now.ToShortDateString() + ".txt";

            if (File.Exists(pathFile) == false)
            {
                using (FileStream fstream = new FileStream(pathFile, FileMode.OpenOrCreate)) { }
            }
        }

        public void WorkWithFiles(string message)
        {
            CreatFile();

            string path = Directory.GetCurrentDirectory() + "\\Store Phone system files";

            string pathFile = path + "\\" + DateTime.Now.ToShortDateString() + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(pathFile, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}