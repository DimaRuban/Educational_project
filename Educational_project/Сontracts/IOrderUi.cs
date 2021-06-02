namespace StorePhone.Сontracts
{
    public interface IOrderUi 
    {
        void ChooseProductUi() { }
        void BuyUi() { }
        void PrintTotalPriceUi(decimal totalPrice) {}
        void InformAboutSuccessUi() { }
    }
}
