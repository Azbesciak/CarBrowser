using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    internal class CarsService : AbstractRepositoryService<Car>, ICarsService
    {
        internal CarsService(ICarsRepository repository): base(repository)
        {
        } 
    }
}