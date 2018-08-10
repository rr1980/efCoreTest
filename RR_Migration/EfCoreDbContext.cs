using Microsoft.EntityFrameworkCore;
using RR_Models;

namespace RR_Migration
{
    public class EfCoreDbContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public virtual DbSet<Adresse> Adresse { get; set; }

        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasMany(x => x.Benutzer).WithOne(x => x.Person);
            });

            modelBuilder.Entity<Benutzer>(entity =>
            {
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasMany(x => x.Personen).WithOne(x => x.Adresse);
            });
        }
    }
}
