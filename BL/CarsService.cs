using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.BL
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