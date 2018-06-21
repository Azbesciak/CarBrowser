using System.Data.Entity;

namespace Kups.CarBrowser.SqlDAO
{
    public class CarBrowserModel : DbContext
    {
        public virtual DbSet<CarProxy> Cars { get; set; }
        public virtual DbSet<DealerProxy> Dealers { get; set; }

        public CarBrowserModel(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<CarBrowserModel>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<EngineProxy>();
            modelBuilder.Entity<CarProxy>().Property(c => c.Engine.HorsePower).HasColumnName("HorsePower");
            modelBuilder.Entity<CarProxy>().Property(c => c.Engine.Name).HasColumnName("EngineName");
            modelBuilder.Entity<CarProxy>().Property(c => c.Engine.Type).HasColumnName("EngineType");
            modelBuilder.Entity<CarProxy>().Property(c => c.Engine.Id).HasColumnName("EngineId");
        }
    }
}