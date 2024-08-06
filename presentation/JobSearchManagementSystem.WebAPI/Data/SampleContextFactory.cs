using JobSearchManagementSystem.Persistance.EntityFrameworks;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BarrenSellTicket.WebApi.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<JobSearchDbContext>
    {
        public JobSearchDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<JobSearchDbContext>();
            var connectionString = configuration.GetConnectionString("Local");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("JobSearchManagementSystem.Persistance"));

            return new JobSearchDbContext(builder.Options);
        }
    }
}