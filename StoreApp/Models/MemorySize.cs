namespace StoreApp.Models
{
    public class MemorySize
    {
        public MemorySize()
        {
        }
        public MemorySize(int id, int size)
        {
            Id = id;
            Size = size;
        }

        public int Id { get; set; }

        public int Size { get; set; }
    }
}