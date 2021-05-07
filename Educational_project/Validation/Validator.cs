using StorePhone.Сontracts;
using System.Text.RegularExpressions;

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
       public bool CheckingPhoneNumber(string message)
        {
            string patternForPhoneNumber1 = @"^((8|\+38)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            var expressionForPhoneNumber1 = new Regex(patternForPhoneNumber1, RegexOptions.Compiled);
            var isMatch1 = expressionForPhoneNumber1.IsMatch(message);

            string patternForPhoneNumber2 = @"\+\d{3}\(\d{2}\)\d{3}\s\d{2}\s\d{2}";
            var expressionForPhoneNumber2 = new Regex(patternForPhoneNumber2, RegexOptions.Compiled);
            var isMatch2 = expressionForPhoneNumber2.IsMatch(message);

            if (isMatch1 == isMatch2==true)
                return true;
            else return false;
        }

        public bool CheckingHomeAdress(string message) 
        {
            string patternForHomeAdress = @"^(улица|ул\.)\s?[а-яA-Я]+(\.|,)\s?(дом|д\.)\s?[1-9]+(,\s?(квартира|кв\.)\s?[1-9]+)?$";
            var expressionForHomeAdress = new Regex(patternForHomeAdress, RegexOptions.Compiled);
            var isMatch = expressionForHomeAdress.IsMatch(message);
            if (isMatch == true)
                return true;
            else return false;
        }
    }
}