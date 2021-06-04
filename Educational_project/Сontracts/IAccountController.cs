namespace StorePhone.Сontracts
{
    public interface IAccountController
    {
        void Register(string firstName, string lastName, string emailAddress, string phoneNumber, string userName, string password) { }
    }
}