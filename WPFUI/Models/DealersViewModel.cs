using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;
using WPFUI.Wrappers;

namespace WPFUI.Models
{
    public class DealersViewModel: ViewBase<Dealer>
    {
        public DealersViewModel(IDealersService dealersService) : base(dealersService)
        {
        }

        protected override ViewModelBase<Dealer> CreateEditableModel(Dealer existing)
        {
            throw new System.NotImplementedException();
        }

        protected override long GetEntityId(Dealer entity) => entity.Id;
    }
}
