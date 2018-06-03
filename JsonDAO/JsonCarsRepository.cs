using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonCarsRepository : JsonRepository<Car>, ICarsRepository
    {
        public JsonCarsRepository(JsonReader<Car> reader) : base(reader, c => c.Id)
        {}
    }
}