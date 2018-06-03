using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public abstract class MockRepo<T>:IRepository<T>
    {
        private readonly Func<T, long> _idGetter;

        protected MockRepo(Func<T, long> idGetter)
        {
            _idGetter = idGetter;
        }

        public abstract List<T> GetAll();
        

        public T GetById(long id) => GetAll().Find(o => _idGetter(o) == id);
        public bool Add(T obj)
        {
            GetAll().Add(obj);
            return true;
        }


        public T Update(T obj)
        {
            var id = _idGetter(obj);
            int find = GetAll().FindIndex(o => id == _idGetter(o));
            if (find >= 0)
            {
                GetAll()[find] = obj;
            }
            return obj;
        }

        public bool Remove(long id) => GetAll().RemoveAll(o => _idGetter(o) == id) > 0;
    }
}
