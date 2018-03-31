using System.Drawing;

namespace Kups.CarBrowser.BO
{
    public class Car
    {
        public Car(long id, CarType carType, string model, string manufacturer, int productionYear, GearBox gearBox,
            Color color, Engine engine)
        {
            Id = id;
            CarType = carType;
            Model = model;
            Manufacturer = manufacturer;
            ProductionYear = productionYear;
            GearBox = gearBox;
            Color = color;
            Engine = engine;
        }

        public long Id { get; }
        public CarType CarType { get; }
        public string Model { get; }
        public string Manufacturer { get; }
        public int ProductionYear { get; }
        public GearBox GearBox { get; }
        public Color Color { get; }
        public Engine Engine { get; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(CarType)}: {CarType}, {nameof(Model)}: {Model}," +
                $" {nameof(Manufacturer)}: {Manufacturer}, {nameof(ProductionYear)}: {ProductionYear}," +
                $" {nameof(GearBox)}: {GearBox}, {nameof(Color)}: {Color}, {nameof(Engine)}: {Engine}";
        }
    }
}