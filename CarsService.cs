using System.Collections.Generic;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;
using Kups.CarBrowser.Interfaces;

namespace Kups.CarBrowser.CarBrowser
{
    internal class CarsService: ICarsService
    {
        private readonly ICarsRepository _repository;

        internal CarsService(ICarsRepository repository)
        {
            _repository = repository;
        }

        public List<Car> GetAll() => _repository.GetAll();

        public Car GetById(long id) => _repository.GetById(id);
    }
}