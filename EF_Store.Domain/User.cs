namespace EF_Store.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}