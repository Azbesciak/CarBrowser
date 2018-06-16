using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public class MockDealersRepository : MockRepo<Dealer>, IDealersRepository
    {
        private readonly List<Dealer> _dealers;

        public MockDealersRepository()
        {
            _dealers = new List<Dealer>(new[]
            {
                new Dealer(1, "Porsche Franowo", "Audi"),
                new Dealer(2, "Voyager Group", "Mazda"),
                new Dealer(3, "Karlik Poznań", "Honda", "Volvo"),
                new Dealer(4, "Olszowiec", "BMW"),
                new Dealer(5, "MB Motors", "Mercedes-Benz")
            });
        }

        public override List<Dealer> GetAll() => _dealers;
    }
}