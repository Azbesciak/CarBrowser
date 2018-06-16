using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using Kups.CarBrowser.WPFUI.Wrappers;

namespace Kups.CarBrowser.WPFUI.Models
{
    public class DealersViewModel: ViewBase<Dealer>
    {
        public DealersViewModel(IDealersService dealersService) : base(dealersService)
        {}

        protected override ViewModelBase<Dealer> CreateEditableModel(Dealer existing, RelayCommand commitCmd) => new EditableDealer(existing);

        protected override long GetEntityId(Dealer entity) => entity.Id;
    }
}
