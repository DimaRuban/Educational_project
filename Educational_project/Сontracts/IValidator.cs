namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        bool IsUserExists(string userName);
    }
}