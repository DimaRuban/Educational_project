namespace EF_Store.UI
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
    }
}