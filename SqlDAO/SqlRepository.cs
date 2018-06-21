using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.SqlDAO
{
    public abstract class SqlRepository<T, TP> : IRepository<T>
        where T : Entity
        where TP : Proxy
    {
        private readonly string _connectionString;

        protected SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected abstract DbSet<TP> GetSet(CarBrowserModel model);
        protected abstract TP CreateProxy(T entity);
        protected abstract T CreateEntity(TP proxy);
        private TX GetData<TX>(Func<DbSet<TP>, TX> consumer)
        {
            using (var db = new CarBrowserModel(_connectionString))
            {
                var dbSet = GetSet(db);
                var result = consumer(dbSet);
                db.SaveChanges();
                return result;
            }
        }

        public List<T> GetAll() => GetData(d => d.ToList().ConvertAll(CreateEntity));
        
        public T GetById(long id)
        {
            var proxy = GetData(d => d.Find(id));
            return proxy != null ? CreateEntity(proxy) : null;
        }

        public bool Add(T obj) => GetData(d => d.Add(CreateProxy(obj)) != null);

        public T Update(T obj)
        {
            using (var db = new CarBrowserModel(_connectionString))
            {
                var dbSet = GetSet(db);
                var entity = dbSet.Find(obj.Id);
                db.Entry(entity).CurrentValues.SetValues(CreateProxy(obj));
                db.SaveChanges();
                return obj;
            }
        }

        public bool Remove(long id) => GetData(d => Rem(d, id) != null);

        private static TP Rem(IDbSet<TP> set, long id)
        {
            var entry = set.First(x => x.Id == id);
            return set.Remove(entry);
        }
    }
}