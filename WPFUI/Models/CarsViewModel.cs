using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;

namespace WPFUI.Models
{
    public class CarsViewModel
    {
        private readonly ICarsService _carsService;
        public List<Car> Cars => _carsService.GetAll();
        public Car CurrentCar { get; set; }
        public CarsViewModel(ICarsService service)
        {
            _carsService = service;
        }
    }
}
