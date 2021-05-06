namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
        int IdProductForBuy { get; set; }
        decimal TotalPriceOrder { get; set; }
        string UserName { get; set; }
        string Adress { get; set; }
        int QuantityProductForOrder { get; set; }
        int ConfirmButton { get; set; }
        void ChoiceProduct() { }
        void Buy() { }
    }
}
