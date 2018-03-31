using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;
using Kups.CarBrowser.DAOMock;

namespace Kups.CarBrowser.CarBrowser
{
    public class CarBrowser
    {
        public ICarsService CarsService { get; }
        public IDealersService DealersService { get; }

        public CarBrowser()
        {
            IDao dao = new MockDao();
            CarsService = new CarsService(dao.GetCarsRepository());
            DealersService = new DealersService(dao.GetDealersRepository());
        }
    }
}