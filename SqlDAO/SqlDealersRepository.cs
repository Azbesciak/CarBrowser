using System.Data.Entity;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.SqlDAO
{
    public class SqlDealersRepository : SqlRepository<Dealer, DealerProxy>, IDealersRepository
    {
        public SqlDealersRepository(string connectionString) : base(connectionString)
        {
        }

        protected override DbSet<DealerProxy> GetSet(CarBrowserModel model) => model.Dealers;

        protected override DealerProxy CreateProxy(Dealer entity) => new DealerProxy
        {
            Id = entity.Id,
            Name = entity.Name,
            Brands = entity.Brands
        };

        protected override Dealer CreateEntity(DealerProxy proxy) =>
            new Dealer(proxy.Id, proxy.Name, proxy.Brands.ToArray());
    }
}