namespace StorePhone.Сontract
{
    public interface IValidator
    {
        bool IsPhoneNumberValid(string message);

        bool IsHomeAddressValid(string message);
    }
}