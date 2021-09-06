namespace EF_Store.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
    }
}