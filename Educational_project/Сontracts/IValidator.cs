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
        bool CheckingHomeAddress(string message) 
        {
            return true;
        }
    }
}