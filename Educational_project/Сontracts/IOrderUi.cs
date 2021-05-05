namespace StorePhone.Сontracts
{
    public interface IOrderUi 
    {
        int IdProductForBuy { get; set; }
        string UserName { get; set; }
        string Adress { get; set; }
        int QuantityProductForOrder { get; set; }
        int ConfirmButton { get; set; }
        void ChoiceProductUi() { }
        void BuyUi() { }
        void PrintTotalPrice(decimal totalPrice) {}
        void InformAboutSuccess() { }
    }
}
