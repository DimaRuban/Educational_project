using StorePhone.Сontracts;
using System;
using System.IO;
using System.Text;

namespace StorePhone.Logging
{
    public class FileManager : IFileManager
    {
        private readonly string path = Directory.GetCurrentDirectory() + "\\Store Phone system files";
        private void CreatFolder()
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        private void CreatFile()
        {
            CreatFolder();           

            string pathFile = path + "\\" + DateTime.Now.ToShortDateString() + ".txt";

            if (File.Exists(pathFile) == false)
            {
                using (FileStream fstream = new FileStream(pathFile, FileMode.OpenOrCreate)) { }
            }       
        }

        public void WorkWithFiles(string message)
        {
            CreatFile();

            string pathFile = path + "\\" + DateTime.Now.ToShortDateString() + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(pathFile, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }

        public void WorkWithSerializationFileProducts(string message)
        {
            string pathSerializationProducts = path + "\\Serialization Products.txt";

            if (File.Exists(pathSerializationProducts) == true)
            {
                File.Delete(pathSerializationProducts);
            }

            if (File.Exists(pathSerializationProducts) == false)
            {
                File.Delete(pathSerializationProducts);
                using (FileStream fstream = new FileStream(pathSerializationProducts, FileMode.OpenOrCreate)) { }
            }

            using (StreamWriter streamWriter = new StreamWriter(pathSerializationProducts, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
        public void WorkWithSerializationFileOrders(string message)
        {
            string pathSerializationOrders = path + "\\Serialization Orders.txt";

            if (File.Exists(pathSerializationOrders) == true)
            {
                File.Delete(pathSerializationOrders);
            }
            if (File.Exists(pathSerializationOrders) == false)
            {
                using (FileStream fstream = new FileStream(pathSerializationOrders, FileMode.OpenOrCreate)) { }
            }

            using (StreamWriter streamWriter = new StreamWriter(pathSerializationOrders, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
        public void WorkWithSerializationFileUsers(string message)
        {
            string pathSerializationUsers = path + "\\Serialization Users.txt";
           
            if (File.Exists(pathSerializationUsers) == true)
            {
                File.Delete(pathSerializationUsers);
            }
            if (File.Exists(pathSerializationUsers) == true)
            {
                using (FileStream fstream = new FileStream(pathSerializationUsers, FileMode.OpenOrCreate)) { }
            }

            using (StreamWriter streamWriter = new StreamWriter(pathSerializationUsers, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}