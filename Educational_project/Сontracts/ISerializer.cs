namespace StorePhone.Сontracts
{
    public interface ISerializer
    {
        void SerializeProducts();

        void SerializeOrders();

        void SerializeUsers();

        void DeSerializeProducts();

        void DeSerializeOrders();

        void DeSerializeUsers();       
    }
}