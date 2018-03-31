using System.Collections.Generic;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public class MockDealersRepository: IDealersRepository
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

        public List<Dealer> GetAll() => _dealers;

        public Dealer GetById(long id) => _dealers.Find(d => d.Id == id);
    }
}