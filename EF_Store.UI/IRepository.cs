using System.Collections.Generic;

namespace EF_Store.UI
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetObjects();
        T GetObject(int id);
        void CreateObject(T item);
        void UpdateObject(T item);
        void DeleteObject(int id);
    }
}