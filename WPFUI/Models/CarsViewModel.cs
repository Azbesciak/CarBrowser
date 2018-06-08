using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;

namespace WPFUI.Models
{
    public class CarsViewModel: ViewBase<Car>
    {
        public CarsViewModel(ICarsService service) : base(service)
        {
        }
    }
}
