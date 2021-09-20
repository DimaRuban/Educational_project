namespace StorePhone.Contracts
{
    public interface IValidator
    {
        bool IsPhoneNumberValid(string message);

        bool IsHomeAddressValid(string message);
    }
}