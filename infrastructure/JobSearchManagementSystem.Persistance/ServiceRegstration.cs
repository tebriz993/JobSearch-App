using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories;
using JobSearchManagementSystem.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance
{
    public static class ServiceRegstration
    {
        public static void AddPersistanceServices(this IServiceCollection services,
                                                       IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Local");

            services
                .AddDbContext<JobSearchDbContext>(options => options
                .UseSqlServer(connectionString).LogTo(x=>LogToText(x),Microsoft.Extensions.Logging.LogLevel.Information)
                .AddInterceptors(new UpdateBaseEntityInterceptor()));

            services.AddHttpContextAccessor();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }


        public static void LogToText(string message)
        {
            try
            {
                string filePath = "C:\\Users\\Baku\\Desktop\\Log.txt";

                using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(message);
                }
            }
            catch (IOException ex)
            {
                // Handle or log the exception
                Console.WriteLine($"File access error: {ex.Message}");
            }
        }

    }
}
