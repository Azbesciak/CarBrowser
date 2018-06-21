using System.Collections.Generic;

namespace Kups.CarBrowser.BO
{
    public class Dealer : Entity
    {
        public Dealer(long id, string name, params string[] brands) : base(id)
        {
            Name = name;
            Brands = new List<string>(brands);
        }

        public string Name { get; }
        public List<string> Brands { get; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Brands)}: {string.Join(", ", Brands.ToArray())}";
    }
}