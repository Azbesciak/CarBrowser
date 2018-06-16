using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public abstract class JsonRepository<T> : IRepository<T> where T : Entity
    {
        private readonly JsonReader<T> _reader;

        protected JsonRepository(JsonReader<T> reader)
        {
            _reader = reader;
        }

        public List<T> GetAll() => _reader.LoadJsonList();

        public T GetById(long id) => GetAll().Find(d => d.Id == id);

        public bool Add(T obj) => _reader.Update(l =>
        {
            var dealer = l.Find(c => c.Id == obj.Id);
            if (dealer != null) return false;
            l.Add(obj);
            return true;
        });

        public T Update(T obj)
        {
            _reader.Update(l =>
            {
                var dealerIndex = l.FindIndex(c => obj.Id == c.Id);
                if (dealerIndex < 0) return false;
                l[dealerIndex] = obj;
                return true;
            });
            return obj;
        }

        public bool Remove(long id) => _reader.Update(l => l.RemoveAll(c => id == c.Id) > 0);
    }
}