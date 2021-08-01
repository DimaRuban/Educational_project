using System.Collections.Generic;

namespace EF_Store.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}