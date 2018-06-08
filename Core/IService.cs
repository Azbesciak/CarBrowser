using System.Collections.Generic;

namespace Kups.CarBrowser.Core
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(long id);
        bool Add(T obj);
        T Update(T obj);
        bool Remove(long id);
    }
}