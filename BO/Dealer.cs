using System.Collections.Generic;

namespace Kups.CarBrowser.BO
{
    public class Dealer
    {
        public Dealer(long id, string name, params string[] brands)
        {
            Id = id;
            Name = name;
            Brands = new List<string>(brands);
        }

        public long Id { get; }
        public string Name { get; }
        public List<string> Brands { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Brands)}: {string.Join(", ", Brands.ToArray())}";
        }
    }
}