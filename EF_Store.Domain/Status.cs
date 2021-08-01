using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Status
    {
        public int Id { get; set; }

        public string StatusName { get; set; }


        public List<Order> Orders { get; set; } = new List<Order>();
    }
}