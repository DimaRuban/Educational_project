namespace StorePhone.Сontracts
{
    public interface IOrderUi 
    {
        void ChoiceProductUi() { }
        void BuyUi() { }
        void PrintTotalPriceUi(decimal totalPrice) {}
        void InformAboutSuccessUi() { }
    }
}
