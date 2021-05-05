namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        bool CheckingUserName(string userName)
        {
            return true;
        }
        void CheckingPhoneNumber(string message) { }
        void CheckingHomeAdrress(string message) { }
    }
}
