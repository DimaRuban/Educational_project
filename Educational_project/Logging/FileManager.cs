using StorePhone.Сontracts;
using System;
using System.IO;
using System.Text;

namespace StorePhone.Logging
{
    public class FileManager : IFileManager
    {
        string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Store Phone logging";
        string dateNow = DateTime.Now.ToShortDateString();

        void CreatFolder()
        {
            if (Directory.Exists(pathDesktop) == false)
            {
                Directory.CreateDirectory(pathDesktop);
            }
        }

        void CreatFile()
        {
            CreatFolder();

            string pathFile = pathDesktop + "\\" + dateNow + ".txt";

            if (File.Exists(pathFile) == false)
            {
                using (FileStream fstream = new FileStream(pathFile, FileMode.OpenOrCreate)){}
            }
        }

        public void WorkWithFiles(string message)
        {
            CreatFile();

            string pathFile = pathDesktop + "\\" + dateNow + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(pathFile, true, Encoding.Default))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}