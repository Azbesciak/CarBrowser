using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonDealersRepository: IDealersRepository
    {
        private readonly JsonReader<Dealer> _reader;

        public JsonDealersRepository(JsonReader<Dealer> reader)
        {
            _reader = reader;
        }

        public List<Dealer> GetAll() => _reader.LoadJsonList();

        public Dealer GetById(long id) => GetAll().Find(d => d.Id == id);
    }
}