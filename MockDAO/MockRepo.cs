using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public abstract class MockRepo<T> : IRepository<T> where T : Entity
    {
        protected MockRepo()
        {
        }

        public abstract List<T> GetAll();

        public T GetById(long id) => GetAll().Find(o => o.Id == id);

        public bool Add(T obj)
        {
            GetAll().Add(obj);
            return true;
        }


        public T Update(T obj)
        {
            int find = GetAll().FindIndex(o => obj.Id == o.Id);
            if (find >= 0)
            {
                GetAll()[find] = obj;
            }

            return obj;
        }

        public bool Remove(long id) => GetAll().RemoveAll(o => o.Id == id) > 0;
    }
}