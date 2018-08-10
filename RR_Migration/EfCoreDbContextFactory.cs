using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RR_Migration
{
    public class EfCoreDbContextFactory : IDesignTimeDbContextFactory<EfCoreDbContext>
    {

        public EfCoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfCoreDbContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efCoreTest1;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true", x => x.MigrationsAssembly("RR_Migration"));
            optionsBuilder.EnableSensitiveDataLogging();

            return new EfCoreDbContext(optionsBuilder.Options);
        }
    }
}
