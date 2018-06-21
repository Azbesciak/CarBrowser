using ConfigUtils;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.SqlDAO
{
    public class SqlDao : IDao
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IDealersRepository _dealersRepository;

        public SqlDao()
        {
            var connectionString = Config.ReadSetting("connectionString");
            _carsRepository = new SqlCarsRepository(connectionString);
            _dealersRepository = new SqlDealersRepository(connectionString);
        }

        public ICarsRepository GetCarsRepository() => _carsRepository;

        public IDealersRepository GetDealersRepository() => _dealersRepository;
    }
}