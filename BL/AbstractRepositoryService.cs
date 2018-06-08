using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    public abstract class AbstractRepositoryService<T>: IService<T>
    {
        protected readonly IRepository<T> Repository;

        internal AbstractRepositoryService(IRepository<T> repository)
        {
            Repository = repository;
        }

        public List<T> GetAll() => Repository.GetAll();
        public T GetById(long id) => Repository.GetById(id);
        public bool Add(T obj) => Repository.Add(obj);
        public T Update(T obj) => Repository.Update(obj);
        public bool Remove(long id) => Repository.Remove(id);
    }
}
