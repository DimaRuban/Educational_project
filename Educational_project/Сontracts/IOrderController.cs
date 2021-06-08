namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
        decimal CountPriceToUsd(decimal totalPrice);
        decimal CountPriceToEur(decimal totalPrice);
        decimal CountPriceToBtc(decimal totalPriceUsd);
        decimal CountTotalPrice(int idProductForBuy, int quantity);
        void Buy(decimal totalPrice, int quantity, string userName, string phoneNumber, string address);
    }
}