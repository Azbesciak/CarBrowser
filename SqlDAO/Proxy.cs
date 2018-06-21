using System.ComponentModel.DataAnnotations;

namespace Kups.CarBrowser.SqlDAO
{
    public abstract class Proxy
    {
        [Key]
        public long Id { get; set; }
    }
}
