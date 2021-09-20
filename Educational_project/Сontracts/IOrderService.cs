using EF_Store.Domain;

namespace StorePhone.Сontract
{
    public interface IOrderService
    {
        string GetNameForProductId(int id);
        decimal CountTotalPrice(int idProductForBuy, int quantity);
        void BuyProduct( decimal totalPrice, int quantity, string userName, string phoneNumber, string address);
        void AddOrder(Order order);
    }
}