using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.DAOMock
{
    public class MockDao: IDao
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IDealersRepository _dealersRepository;
        
        public MockDao()
        {
            _carsRepository = new MockCarsRepository();
            _dealersRepository = new MockDealersRepository();
        }

        public ICarsRepository GetCarsRepository() => _carsRepository;

        public IDealersRepository GetSellersRepository() => _dealersRepository;
    }
}