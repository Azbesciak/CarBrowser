namespace Kups.CarBrowser.Interfaces
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
    }
}