using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;

namespace WPFUI.Models
{
    public class DealersViewModel: ViewBase<Dealer>
    {
        public DealersViewModel(IDealersService dealersService) : base(dealersService)
        {
        }
    }
}
