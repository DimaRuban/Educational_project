namespace StorePhone.Contracts
{
    public interface IOrderUi 
    {
        void ChooseProductUi() { }
        private void BuyUi() { }
        private void PrintTotalPriceUi(decimal totalPrice) {}
        private void InformAboutSuccessUi() { }
    }
}