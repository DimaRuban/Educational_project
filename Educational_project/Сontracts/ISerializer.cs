using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePhone.Сontracts
{
    public interface ISerializer
    {
        void SerializeProducts() { }
       
        void SerializeOrders() { }
       
        void SerializeUsers() { }
        
        void DeSerializeProducts() { }
        
        void DeSerializeOrders() { }
       
        void DeSerializeUsers() { }
        
    }
}
