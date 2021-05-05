namespace StorePhone.Сontracts
{
    public interface IOrderController
    {
         int IdProductForBuy { get; set; }
         decimal TotalPriceOrder { get; set; }
         void ChoiceProduct() { }
         void Buy() { }
    }
}
