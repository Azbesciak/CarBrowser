using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public class MockDao : IDao
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IDealersRepository _dealersRepository;

        public MockDao()
        {
            _carsRepository = new MockCarsRepository();
            _dealersRepository = new MockDealersRepository();
        }

        public ICarsRepository GetCarsRepository() => _carsRepository;

        public IDealersRepository GetDealersRepository() => _dealersRepository;
    }
}