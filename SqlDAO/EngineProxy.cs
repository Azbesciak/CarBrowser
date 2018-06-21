using Kups.CarBrowser.BO;

namespace Kups.CarBrowser.SqlDAO
{
    public class EngineProxy
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EngineType Type { get; set; }
        public int HorsePower { get; set; }
    }
}