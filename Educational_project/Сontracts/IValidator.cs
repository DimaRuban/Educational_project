namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        bool IsUserNameValid(string userName);

        bool IsPhoneNumberValid(string message);

        bool IsHomeAddressValid(string message);
    }
}