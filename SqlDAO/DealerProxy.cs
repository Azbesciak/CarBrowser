using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Kups.CarBrowser.SqlDAO
{
    [Table("Dealers")]
    public class DealerProxy: Proxy
    {
        public string Name { get; set; }
        [NotMapped]
        public virtual List<string> Brands { get; set; }
        [Column("Brands")]
        public string BrandsString
        {
            get => string.Join(",", Brands.ToArray());
            set => Brands = value.Split(',').ToList();
        }
    }
}
