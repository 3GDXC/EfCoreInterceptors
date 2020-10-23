/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// </summary>
    public class SampleContext : DbContext
    {
        public SampleContext() : base() { }
        public SampleContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarDriver> CarDriverRelationships { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
