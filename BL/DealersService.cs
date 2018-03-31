using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
{
    internal class DealersService: IDealersService
    {
        private readonly IDealersRepository _repository;

        internal DealersService(IDealersRepository repository)
        {
            _repository = repository;
        }

        public List<Dealer> GetAll() => _repository.GetAll();

        public Dealer GetById(long id) => _repository.GetById(id);
    }
}