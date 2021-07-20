namespace StoreApp.Models
{
    public class Provider
    {
        public Provider()
        {               
        }

        public Provider(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}