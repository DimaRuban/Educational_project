using StorePhone.Сontracts;

namespace StorePhone.Validation
{
    public class Validator : IValidator
    {
        private readonly IDbContext _dbContext;
        private readonly IDisplay _display;

        public Validator(IDbContext dbContext, IDisplay display)
        {
            _dbContext = dbContext;
            _display = display;
        }
        public bool CheckingUserName(string userName)
        {
            foreach (var user in _dbContext.Users)
            {
                if (user.UserName == userName)
                {
                    _display.PrintForDisplay("\nЭто имя пользователя уже занято, выберете другое!\n");
                    return false;
                }
            }
            return true;
        }
        void CheckingPhoneNumber(string message){}

        void CheckingHomeAdrress(string message) { }
    }
}
