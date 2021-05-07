namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        bool CheckingUserName(string userName)
        {
            return true;
        }
        bool CheckingPhoneNumber(string message)
        {
            return true;
        }
        bool CheckingHomeAdress(string message)
        {
            return true;
        }
    }
}