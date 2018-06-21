using System.Data.Entity;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.SqlDAO
{
    public class SqlCarsRepository : SqlRepository<Car, CarProxy>, ICarsRepository
    {
        public SqlCarsRepository(string connectionString) : base(connectionString)
        {}

        protected override DbSet<CarProxy> GetSet(CarBrowserModel model) => model.Cars;

        protected override CarProxy CreateProxy(Car entity) => new CarProxy
        {
            Id = entity.Id,
            CarType = entity.CarType,
            Model = entity.Model,
            Manufacturer = entity.Manufacturer,
            ProductionYear = entity.ProductionYear,
            GearBox = entity.GearBox,
            Color = entity.Color,
            Engine = new EngineProxy
            {
                Id = entity.Engine.Id,
                Name = entity.Engine.Name,
                Type = entity.Engine.Type,
                HorsePower = entity.Engine.HorsePower
            }
        };

        protected override Car CreateEntity(CarProxy proxy) => new Car(
            proxy.Id,
            proxy.CarType,
            proxy.Model,
            proxy.Manufacturer,
            proxy.ProductionYear,
            proxy.GearBox,
            proxy.Color,
            new Engine(proxy.Engine.Id, proxy.Engine.Name, proxy.Engine.Type, proxy.Engine.HorsePower)
        );
    }
}