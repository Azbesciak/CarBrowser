using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Kups.CarBrowser.BO;

namespace Kups.CarBrowser.SqlDAO
{
    [Table("Cars")]
    public class CarProxy : Proxy
    {
        public CarType CarType { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int ProductionYear { get; set; }
        public GearBox GearBox { get; set; }
        [NotMapped]
        public virtual Color Color { get; set; }
        [Column("Color")]
        public virtual int Argb
        {
            get => Color.ToArgb();
            set => Color = Color.FromArgb(value);
        }

        public virtual EngineProxy Engine { get; set; }
    }
}