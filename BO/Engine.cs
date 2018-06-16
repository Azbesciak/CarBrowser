namespace Kups.CarBrowser.BO
{
    public class Engine: Entity
    {
        public Engine(long id, string name, EngineType type, int horsePower): base(id)
        {
            Name = name;
            Type = type;
            HorsePower = horsePower;
        }
        public string Name { get; }
        public EngineType Type { get; }
        public int HorsePower { get; }

        public override string ToString() => 
            $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}," +
            $" {nameof(Type)}: {Type}, {nameof(HorsePower)}: {HorsePower}";
    }
}