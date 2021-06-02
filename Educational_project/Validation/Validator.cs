using StorePhone.Сontracts;

namespace StorePhone.Validation
{
    public class Validator : IValidator
    {
        private readonly IDbContext _dbContext;

        public Validator(IDbContext dbContext, IDisplay display)
        {
            _dbContext = dbContext;
        }
        public bool IsUserExists(string userName)
        {
            foreach (var user in _dbContext.Users)
            {
                if (user.UserName == userName)
                {                 
                    return false;
                }
            }
            return true;
        }
    }
}