using System.Collections.Generic;

namespace Kups.CarBrowser.DAO
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(long id);
    }
}