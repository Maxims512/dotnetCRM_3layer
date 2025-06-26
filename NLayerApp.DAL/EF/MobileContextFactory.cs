using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace NLayerApp.DAL.EF
{
    public class MobileContextFactory : IDesignTimeDbContextFactory<MobileContext>
    {
        public MobileContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MobileContext>();   
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return new MobileContext(optionsBuilder.Options);
        }
    }
}