using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Сontracts
{
    public interface IValidator
    {
        void CheckingPhoneNumber(string message) { }
        void CheckingHomeAdrress(string message) { }
    }
}
