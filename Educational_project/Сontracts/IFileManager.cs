namespace StorePhone.Сontracts
{
    public interface IFileManager
    {
        void WorkWithFiles(string message);
        void WorkWithSerializationFileProducts(string message);
        void WorkWithSerializationFileOrders(string message);
        void WorkWithSerializationFileUsers(string message);
    }
}