namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
        string GetNameForProductId(int id);
        decimal CountTotalPrice(int idProductForBuy, int quantity);
        void BuyProduct(decimal totalPrice, int quantity, string userName, string phoneNumber, string address);
    }
}
