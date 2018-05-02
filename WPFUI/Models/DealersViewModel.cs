using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.Core;

namespace WPFUI.Models
{
    public class DealersViewModel
    {

        private readonly IDealersService _dealersService;
        public List<Dealer> Dealers => _dealersService.GetAll();
        public Dealer CurrentDealer { get; set; }

        public DealersViewModel(IDealersService dealersService)
        {
            _dealersService = dealersService;
        }
    }
}
