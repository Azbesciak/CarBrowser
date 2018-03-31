namespace Kups.CarBrowser.BO
{
    public class Engine
    {
        public Engine(long id, string name, EngineType type, int horsePower)
        {
            Id = id;
            Name = name;
            Type = type;
            HorsePower = horsePower;
        }

        public long Id { get; }
        public string Name { get; }
        public EngineType Type { get; }
        public int HorsePower { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}," +
                   $" {nameof(Type)}: {Type}, {nameof(HorsePower)}: {HorsePower}";
        }
    }
}