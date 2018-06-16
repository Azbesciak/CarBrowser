using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonDealersRepository : JsonRepository<Dealer>, IDealersRepository
    {
        public JsonDealersRepository(JsonReader<Dealer> reader) : base(reader)
        {}
    }
}