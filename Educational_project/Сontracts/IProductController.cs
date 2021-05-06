namespace StorePhone.Сontracts
{
    public interface IProductController
    {
        string NewProductName { get; set; }
        decimal NewProductPrice { get; set; }
        string NewProductColor { get; set; }
        int NewProductMemorySize { get; set; }
        void AddNewProduct() { }
    }
}