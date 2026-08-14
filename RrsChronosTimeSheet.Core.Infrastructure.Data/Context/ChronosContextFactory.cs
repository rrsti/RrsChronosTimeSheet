using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Context
{
    public class ChronosContextFactory : IDesignTimeDbContextFactory<ChronosContext>
    {
        public ChronosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChronosContext>();

            optionsBuilder.UseSqlServer("Data Source=PCRERUM\\SQLEXPRESS;Initial Catalog=CorporeChronosDB;MultipleActiveResultSets=true;User=sa;Password=TboMI6Z7@#$;TrustServerCertificate=True;");
            return new ChronosContext(optionsBuilder.Options);
        }
    }
}
