using System;
using System.Collections.Generic;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public abstract class JsonRepository<T>: IRepository<T>
    {

        private readonly JsonReader<T> _reader;
        private readonly Func<T, long> _idGetter;

        protected JsonRepository(JsonReader<T> reader, Func<T, long> idGetter)
        {
            _reader = reader;
            _idGetter = idGetter;
        }

        public List<T> GetAll() => _reader.LoadJsonList();

        public T GetById(long id) => GetAll().Find(d => _idGetter(d) == id);
        public bool Add(T obj) => _reader.Update(l =>
        {
            var id = _idGetter(obj);
            var dealer = l.Find(c => _idGetter(c) == id);
            if (dealer != null) return false;
            l.Add(obj);
            return true;
        });

        public T Update(T obj)
        {
            _reader.Update(l =>
            {
                var id = _idGetter(obj);
                var dealerIndex = l.FindIndex(c => id == _idGetter(c));
                if (dealerIndex < 0) return false;
                l[dealerIndex] = obj;
                return true;
            });
            return obj;
        }

        public bool Remove(long id) => _reader.Update(l => l.RemoveAll(c => id == _idGetter(c)) > 0);
    }
}
