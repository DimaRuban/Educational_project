namespace StorePhone.Сontracts
{
    public interface ISerializer
    {
        void SerializeProducts();

        void SerializeOrders();

        void SerializeUsers();

        void DeserializeProducts();

        void DeserializeOrders();

        void DeserializeUsers();       
    }
}