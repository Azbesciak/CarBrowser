using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    internal class DealersService: AbstractRepositoryService<Dealer>, IDealersService
    {
        internal DealersService(IDealersRepository repository): base(repository)
        {}
    }
}