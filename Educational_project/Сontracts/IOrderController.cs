namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
        string GetNameForProductId(int id);
        decimal CountTotalPrice(int idProductForBuy, int quantity);
        void Buy( decimal totalPrice, int quantity, string userName, string phoneNumber, string address);
    }
}