namespace StorePhone.Сontracts
{
    public interface IAccountController
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        void Registration() { }
    }
}