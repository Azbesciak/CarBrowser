using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonCarsRepository  : ICarsRepository
    {
        private readonly JsonReader<Car> _reader;

        public JsonCarsRepository(JsonReader<Car> reader)
        {
            _reader = reader;
        }

        public List<Car> GetAll() => _reader.LoadJsonList();

        public Car GetById(long id) => GetAll().Find(c => c.Id == id);
    }
}