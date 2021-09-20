using StorePhone.Сontract;
using System.Text.RegularExpressions;

namespace StorePhone.Validation
{
    public class Validator : IValidator
    {
        public bool IsPhoneNumberValid(string message)
        {
            var phoneNumberPattern = @"\+?([0-9]{2})?[0]\(?[0-9]{2}\)?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}";
            var expressionPhoneNumber = new Regex(phoneNumberPattern, RegexOptions.Compiled);
           
            return expressionPhoneNumber.IsMatch(message);
        }
        public bool IsHomeAddressValid(string message)
        {
            var addressPattern = @"^(улица|ул\.)\s?[а-яA-Я]+(\.|,)\s?(дом|д\.)\s?[1-9]+(,\s?(квартира|кв\.)\s?[1-9]+)?$";
            var expressionAddress = new Regex(addressPattern, RegexOptions.Compiled);
            
            return expressionAddress.IsMatch(message);
        }
    }
}