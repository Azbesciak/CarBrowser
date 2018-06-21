using System.Drawing;

namespace Kups.CarBrowser.BO
{
    public class Car : Entity
    {
        public Car(long id, CarType carType, string model, string manufacturer, int productionYear, GearBox gearBox,
            Color color, Engine engine) : base(id)
        {
            CarType = carType;
            Model = model;
            Manufacturer = manufacturer;
            ProductionYear = productionYear;
            GearBox = gearBox;
            Color = color;
            Engine = engine;
        }

        public CarType CarType { get; }
        public string Model { get; }
        public string Manufacturer { get; }
        public int ProductionYear { get; }
        public GearBox GearBox { get; }
        public Color Color { get; }
        public Engine Engine { get; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id}, {nameof(CarType)}: {CarType}, {nameof(Model)}: {Model}," +
            $" {nameof(Manufacturer)}: {Manufacturer}, {nameof(ProductionYear)}: {ProductionYear}," +
            $" {nameof(GearBox)}: {GearBox}, {nameof(Color)}: {Color}, {nameof(Engine)}: {Engine}";
    }
}