using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebEnterprise.Data.EF
{
    public class WebEnterpriseDbContextFactory : IDesignTimeDbContextFactory<WebEnterpriseDbContext>
    {
        public WebEnterpriseDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("WebEnterpriseDb");
            var optionsBuilder = new DbContextOptionsBuilder<WebEnterpriseDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new WebEnterpriseDbContext(optionsBuilder.Options);
        }
    }
}
