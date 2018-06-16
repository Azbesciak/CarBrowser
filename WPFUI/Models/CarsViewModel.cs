using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.WPFUI.Wrappers;

namespace Kups.CarBrowser.WPFUI.Models
{
    public class CarsViewModel: ViewBase<Car>
    {
        public CarsViewModel(ICarsService service) : base(service)
        {}
        protected override ViewModelBase<Car> CreateEditableModel(Car existing, RelayCommand commitCmd) => new EditableCar(existing);
        protected override long GetEntityId(Car entity) => entity.Id;
    }
}
