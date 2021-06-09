namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
        decimal ConvertCurrencyRate(decimal totalPrice, string carrencyName);
        decimal CountTotalPrice(int idProductForBuy, int quantity);
        void Buy(decimal totalPrice, int quantity, string userName, string phoneNumber, string address);
    }
}