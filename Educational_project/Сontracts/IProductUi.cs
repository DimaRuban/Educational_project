namespace StorePhone.Сontracts
{
    public interface IProductUi
    {
         string NewProductName { get; set; }
         decimal NewProductPrice { get; set; }
         string NewProductColor { get; set; }
         int NewProductMemorySize { get; set; }
         void AddNewProductUi(){}
         void PrintProductUi(){}
         void InformAboutSuccess(){}
    }
}

