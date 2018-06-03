using System.Collections.Generic;
using System.Drawing;
using Kups.CarBrowser.BO;
using Kups.CarBrowser.DAO;

namespace Kups.CarBrowser.MockDAO
{
    public class MockCarsRepository : MockRepo<Car>, ICarsRepository
    {
        private readonly List<Car> _cars;

        public MockCarsRepository() : base(c => c.Id)
        {
            _cars = new List<Car>(new[]
            {
                new Car(1, CarType.Combi, "R6", "Audi", 2016, GearBox.Automatic, Color.Chocolate,
                    new Engine(1, "TDI", EngineType.Diesel, 400)),
                new Car(2, CarType.Coupe, "AMG C 63 S Coupe", "Mercedes-Benz", 2018, GearBox.Automatic, Color.Red,
                    new Engine(2, "AMG 4.0L V8 biturbo", EngineType.Petrol, 503)),
                new Car(3, CarType.Sedan, "S60", "Volvo", 2017, GearBox.Automatic, Color.Black,
                    new Engine(3, "T4", EngineType.Petrol, 190)),
                new Car(4, CarType.Hatchback, "Civic", "Honda", 2017, GearBox.Automatic, Color.Gray,
                    new Engine(4, "CVT", EngineType.Petrol, 174)),
                new Car(5, CarType.Sedan, "6", "Mazda", 2017, GearBox.Automatic, Color.Crimson,
                    new Engine(5, "2.5 SKY-G", EngineType.Petrol, 192)),
                new Car(6, CarType.Suv, "Cayenne S", "Porche", 2016, GearBox.Automatic, Color.DarkGray,
                    new Engine(6, "3.0 litre 340 hp V6 turbo", EngineType.Petrol, 324))
            });
        }

        public override List<Car> GetAll() => _cars;
    }
}