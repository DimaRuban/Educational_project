namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        bool IsUserExists(string userName);

        bool IsPhoneNumberValid(string message);

        bool IsHomeAddressValid(string message);
    }
}