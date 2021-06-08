namespace StorePhone.Сontracts
{
    public interface IFileManager
    {
        void WorkWithFiles(string message);
        void WorkWithSerializationFile(string message, string serializationPath);
    }
}