using System.Collections.Generic;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;
using Kups.CarBrowser.Interfaces;

namespace Kups.CarBrowser.CarBrowser
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