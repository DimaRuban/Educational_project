﻿using StorePhone.Сontracts;
using System.Text.RegularExpressions;

namespace StorePhone.Validation
{
    public class Validator : IValidator
    {
        public bool IsPhoneNumberValid(string message)
        {
            string patternForPhoneNumber = @"\+?([0-9]{2})?[0]\(?[0-9]{2}\)?\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2}";
            var expressionForPhoneNumber = new Regex(patternForPhoneNumber, RegexOptions.Compiled);
            var isMatch = expressionForPhoneNumber.IsMatch(message);

            if (isMatch == true)
                return true;
            else return false;
        }
        public bool IsHomeAddressValid(string message)
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