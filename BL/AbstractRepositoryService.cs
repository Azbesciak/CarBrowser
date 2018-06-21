using System.Collections.Generic;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    public abstract class AbstractRepositoryService<T> : IService<T>
    {
        private readonly IRepository<T> _repository;

        internal AbstractRepositoryService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetAll() => _repository.GetAll();
        public T GetById(long id) => _repository.GetById(id);
        public bool Add(T obj) => _repository.Add(obj);
        public T Update(T obj) => _repository.Update(obj);
        public bool Remove(long id) => _repository.Remove(id);
    }
}
